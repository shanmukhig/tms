using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class CountryDomainService : DomainService<Country>
  {
    public CountryDomainService(DataProvider<Country> countryDataProvider) : base(countryDataProvider)
    {
    }
  }
}