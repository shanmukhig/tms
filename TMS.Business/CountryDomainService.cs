using System;
using System.Linq;
using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class CountryDomainService : IDomainService<Country>
  {
    private readonly DataProvider<Country> _countryDataProvider;

    public CountryDomainService(DataProvider<Country> countryDataProvider)
    {
      _countryDataProvider = countryDataProvider;
    }

    public IQueryable<Country> Get(int? count)
    {
      return _countryDataProvider.Get(count);
    }

    public IQueryable<Country> Get(string searchString, string searchFields)
    {
      return _countryDataProvider.Get(searchString, searchFields);
    }

    public Country Get(string Id)
    {
      throw new System.NotImplementedException();
    }

    public Country Create(Country resource)
    {
      //throw new NotImplementedException();
      return _countryDataProvider.Create(resource);
    }

    public Country Update(Country resource)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(string Id)
    {
      throw new System.NotImplementedException();
    }
  }
}