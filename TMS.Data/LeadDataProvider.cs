using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using TMS.Entities;

namespace TMS.Data
{
  public class LeadDataProvider : DataProvider<Lead>
  {
    public override Lead Get(string Id)
    {
      return Collection.FindOneByIdAs<Lead>(Id);
    }

    public override IQueryable<Lead> Get(string searchString, string searchFields)
    {
      string[] propNames = searchFields.Split(',');
      List<IMongoQuery> queryFields = new List<IMongoQuery>();

      PropertyInfo[] propertyInfos = typeof (Lead).GetProperties(BindingFlags.Instance | BindingFlags.Public);

      foreach (var propertyInfo in propNames.Select(propName => propertyInfos.SingleOrDefault(x => x.Name == propName)).Where(propertyInfo => propertyInfo != null))
      {
        Type pi = propertyInfo.PropertyType.IsGenericType ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;

        if (pi.IsEnum)
        {
          IEnumerable<string> enumerable = Enum.GetNames(pi).Where(x => x.Contains(searchString));
          queryFields.AddRange(enumerable.Select(s => (int) Enum.Parse(pi, s, true)).Select(o => Query.EQ(propertyInfo.Name, o)));
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
      return Collection.FindAs<Lead>(query).AsQueryable();
    }

    public override Lead Create(Lead resource)
    {
      Store(resource);
      return resource;
    }

    public override void Delete(string Id)
    {
      Collection.Remove(new QueryDocument("_id", Id));
    }

    public override IQueryable<Lead> Get(int? count)
    {
      var leads = Collection.AsQueryable().OrderByDescending(x => x.CreatedOn);
      return count.HasValue ? leads.Take(count.Value) : leads;
    }

    public override Lead Update(Lead resource)
    {
      Store(resource);
      return resource;
    }
  }
}