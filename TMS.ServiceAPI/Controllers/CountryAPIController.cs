using System.Linq;
using System.Net;
using System.Net.Http;
using TMS.Business;
using TMS.Entities;

namespace TMS.ServiceAPI.Controllers
{
  public class CountryAPIController : CustomController<Country>
  {
    private readonly IDomainService<Country> _countryDomainService;

    public CountryAPIController(IDomainService<Country> countryDomainService)
    {
      _countryDomainService = countryDomainService;
    }

    public override HttpResponseMessage Get(int? count)
    {
      return Request.CreateResponse(HttpStatusCode.OK, _countryDomainService.Get(count));
    }

    public override HttpResponseMessage Get(string searchString, string searchFileds)
    {
      return Request.CreateResponse(HttpStatusCode.OK, _countryDomainService.Get(searchString, searchFileds));
    }

    public override HttpResponseMessage Create(Country resource)
    {
      if (resource == null)
        Error(HttpStatusCode.NoContent, "Country can't be null.");

      Country country = _countryDomainService.Create(resource);

      if (string.IsNullOrWhiteSpace(resource.Code))
        Error(HttpStatusCode.BadRequest, "Error while creating the County.");

      return Request.CreateResponse(HttpStatusCode.Created, country);
    }

    //public override HttpResponseMessage Delete(string id)
    //{
    //  return base.Delete(id);
    //}

    //public override HttpResponseMessage Get(string searchString, string searchFileds)
    //{
    //  return base.Get(searchString, searchFileds);
    //}

    //public override HttpResponseMessage GetOne(string id)
    //{
    //  return base.GetOne(id);
    //}

    //public override HttpResponseMessage Update(Country resource)
    //{
    //  return base.Update(resource);
    //}
  }
}