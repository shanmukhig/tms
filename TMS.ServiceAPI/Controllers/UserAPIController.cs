using System.Linq;
using System.Net;
using System.Net.Http;
using TMS.Business;
using TMS.Entities;

namespace TMS.ServiceAPI.Controllers
{
  public class UserAPIController : CustomController<User>
  {
    private readonly IDomainService<User> _userDomainService;

    public UserAPIController(DomainService<User> userDomainService)
    {
      _userDomainService = userDomainService;
    }

    //[HttpGet]
    public override HttpResponseMessage Get(int? count)
    {
      IQueryable<User> leads = _userDomainService.Get(count);

      if (leads == null || !leads.Any())
        Error(HttpStatusCode.NoContent, "No Leads found.");

      return Request.CreateResponse(HttpStatusCode.OK, leads);
    }

    //[HttpGet]
    public override HttpResponseMessage GetOne(string Id)
    {
      User lead = _userDomainService.Get(Id);

      if (lead == null)
        Error(HttpStatusCode.NotFound, "No Lead found for the given Id: {0}", new object[] { Id });

      return Request.CreateResponse(HttpStatusCode.OK, lead);
    }

    //[HttpPost]
    //[ValidationFilter]
    public override HttpResponseMessage Create(User resource)
    {
      User lead = _userDomainService.Create(resource);

      if (string.IsNullOrWhiteSpace(resource.Id))
        Error(HttpStatusCode.BadRequest, "Error while creating the Lead.");

      return Request.CreateResponse(HttpStatusCode.Created, lead);
    }

    //[HttpPut]
    //[ValidationFilter]
    public override HttpResponseMessage Update(User resource)
    {
      //TODO: need to find out a way how can fing update failure
      return Request.CreateResponse(HttpStatusCode.OK, _userDomainService.Update(resource));
    }

    //[HttpDelete]
    public override HttpResponseMessage Delete(string Id)
    {
      if (_userDomainService.Get(Id) == null)
        Error(HttpStatusCode.NotFound, "No Lead found for the given Id: {0}", new object[] { Id });

      _userDomainService.Delete(Id);
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}