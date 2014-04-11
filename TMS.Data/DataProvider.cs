using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TMS.Entities;
using TMS.Entities.Enum;

namespace TMS.Data
{
  public abstract class DataProvider<T> : IDataProvider<T> where T : class
  {
    //TODO: need to work on the authentication and authorization
    private const string ConnectionString = "mongodb://localhost/TMS";

    private readonly MongoDatabase mongoDatabase;

    protected DataProvider(string collectionName = null)
    {
      MongoUrl mongoUrl = new MongoUrl(ConnectionString);
      MongoClient mongoClient = new MongoClient(mongoUrl);
      mongoDatabase = mongoClient.GetServer().GetDatabase(mongoUrl.DatabaseName);
      collectionName = collectionName ?? typeof(T).Name.Replace("IData", string.Empty);

      if (mongoDatabase != null)
        SetupCollection(collectionName);
    }

    protected MongoCollection<T> Collection { get; private set; }

    protected bool IsOnline
    {
      get { return mongoDatabase.Server.State == MongoServerState.Connected; }
    }

    protected bool Store(IEnumerable<T> messages)
    {
      try
      {
        //this is an upsert
        foreach (T message in messages)
          Collection.Save(message);
        return true;
      }
      catch (WriteConcernException mongoSafeModeException)
      {
        LogSafeModeException(mongoSafeModeException, "BatchInsert");
      }
      catch (Exception)
      {
        //Log.IfError("Unable to store the objects in mongoDB", exception);
        throw;
      }
      return false;
    }

    protected bool Store(T message)
    {
      try
      {
        //this is an upsert
        Collection.Save(message);
        return true;
      }
      catch (WriteConcernException mongoSafeModeException)
      {
        LogSafeModeException(mongoSafeModeException, "Insert");
        throw;
      }
      catch (Exception)
      {
        //Log.IfError("Unable to store the object in mongoDB", exception);
        throw;
      }
    }

    #region Helper Methods

    public static void RegisterClassMap<TU>()
    {
      if (BsonClassMap.IsClassMapRegistered(typeof(TU)))
      {
        return;
      }

      BsonClassMap.RegisterClassMap<TU>(map =>
      {
        map.AutoMap();
        BsonMemberMap bsonMemberMap = map.GetMemberMap("Id");
        if (bsonMemberMap == null) return;
        map.SetIdMember(bsonMemberMap);
        map.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
      });
    }

    private void SetupCollection(string collectionName)
    {
      Type type = typeof(T);
      var method = typeof(DataProvider<T>).GetMethod("RegisterClassMap");
      MethodInfo methodInfo;

      while (true)
      {
        if (type   == null || type.BaseType == typeof(object)) break;
        type = type.BaseType;
        methodInfo = method.MakeGenericMethod(new[] { type });
        methodInfo.Invoke(null, null);
      }

      type = typeof (T);

      if (typeof(T).IsInterface)
        type = (from t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                where type.IsAssignableFrom(t) && t != typeof(object) && !t.IsInterface
                select t).Single();

      methodInfo = method.MakeGenericMethod(new[] { type });
      methodInfo.Invoke(null, null);

      try
      {
        Collection = mongoDatabase.GetCollection<T>(collectionName);
        ApplyIndexes();
      }
      catch (Exception)
      {
        Collection = null;
        throw;
      }
    }

    private void ApplyIndexes()
    {
      var t = typeof(T);
      var indexes = FindIndexAttributes(t);
      if (indexes.Count == 0)
        return;

      if (!Collection.IndexExists(indexes.ToArray()))
        Collection.EnsureIndex(indexes.ToArray());

      //Log.IfInfoFormat("Created MongoDB Index for Collection '{0}'", t.Title);
      //foreach (var index in indexes)
      //Log.IfInfoFormat("Index created: {0}", index);
    }

    private static IList<string> FindIndexAttributes(Type t)
    {
      var memberInfos = t.GetProperties();
      return (from t1 in memberInfos
              let att = (EnsureIndex)Attribute.GetCustomAttribute(t1, typeof(EnsureIndex))
              where att != null
              select t1.Name).ToList();
    }

    private void LogSafeModeException(WriteConcernException mongoSafeModeException, string exceptionIntroduction)
    {
      //Log.ErrorFormat("MongoDB {1} Error -> {0}", mongoSafeModeException.Message, exceptionIntroduction);
      //Log.ErrorFormat("Result -> {0}", mongoSafeModeException.CommandResult.ToJson());
      //Log.ErrorFormat("Data -> {0}", mongoSafeModeException.Data.ToJson());
    }

    #endregion

    public virtual IQueryable<T> Get(int? count)
    {
      var leads = Collection.FindAllAs<T>().SetSortOrder(SortBy.Descending("CreatedOn")).AsQueryable();
      return count.HasValue ? leads.Take(count.Value) : leads;
    }

    public virtual IQueryable<T> Get(string searchString, string searchFields)
    {
      string[] propNames = searchFields.Split(',');
      List<IMongoQuery> queryFields = new List<IMongoQuery>();

      PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

      foreach (var propertyInfo in propNames.Select(propName => propertyInfos.SingleOrDefault(x => x.Name == propName)).Where(propertyInfo => propertyInfo != null))
      {
        Type pi = propertyInfo.PropertyType.IsGenericType ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;

        if (pi.IsEnum)
        {
          IEnumerable<string> enumerable = Enum.GetNames(pi).Where(x => x.Contains(searchString));
          queryFields.AddRange(enumerable.Select(s => (int)Enum.Parse(pi, s, true)).Select(o => Query.EQ(propertyInfo.Name, o)));
        }
        else if (pi == typeof(string))
        {
          queryFields.Add(Query.Matches(propertyInfo.Name, string.Format("/.*{0}.*/i", searchString)));
        }
        else
        {
          queryFields.Add(Query.EQ(propertyInfo.Name, searchString));
        }
      }

      IMongoQuery query = Query.Or(queryFields);
      return Collection.FindAs<T>(query).AsQueryable();
    }

    public virtual T Get(string Id)
    {
      return Collection.FindOneByIdAs<T>(Id);
    }

    public virtual T Create(T resource)
    {
      Store(resource);
      return resource;
    }

    public virtual T Update(T resource)
    {
      return Create(resource);
    }

    public virtual void Delete(string Id)
    {
      BaseEntity baseEntity = Get(Id) as BaseEntity;
      baseEntity.Status = Status.Deleted;
      Store(baseEntity as T);
      //Collection.Remove(new QueryDocument("_id", Id));
    }
  }
}
