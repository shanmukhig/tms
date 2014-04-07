using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TMS.Entities;

namespace TMS.Data
{
  public class CountryDataProvider : DataProvider<Country>
  {
    public override IQueryable<Country> Get(int? count)
    {
      return Collection.FindAllAs<Country>().AsQueryable();
    }

    public override IQueryable<Country> Get(string searchString, string searchFields)
    {
      string[] propNames = searchFields.Split(',');
      List<IMongoQuery> queryFields = new List<IMongoQuery>();

      PropertyInfo[] propertyInfos = typeof (Country).GetProperties(BindingFlags.Instance | BindingFlags.Public);

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
      return Collection.FindAs<Country>(query).AsQueryable();
    }

    public override Country Create(Country resource)
    {
      //throw new NotImplementedException();
      Store(resource);
      return resource;
    }
  }
}