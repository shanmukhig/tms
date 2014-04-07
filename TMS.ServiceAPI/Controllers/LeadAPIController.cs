using System.Linq;
using System.Net;
using System.Net.Http;
using TMS.Business;
using TMS.Entities;

namespace TMS.ServiceAPI.Controllers
{
  public class LeadAPIController : CustomController<Lead>
  {
    private readonly IDomainService<Lead> _leadDomainService;

    public LeadAPIController(IDomainService<Lead> leadDomainService)
    {
      _leadDomainService = leadDomainService;
    }

    public override HttpResponseMessage Get(int? count)
    {
      IQueryable<Lead> leads = _leadDomainService.Get(count);

      if(leads == null || !leads.Any())
        Error(HttpStatusCode.NoContent, "No Leads found.");

      return Request.CreateResponse(HttpStatusCode.OK, leads);
    }

    public override HttpResponseMessage Get(string searchString, string searchFileds)
    {
      if (string.IsNullOrWhiteSpace(searchString) || string.IsNullOrWhiteSpace(searchFileds))
        return Get(null);
      IQueryable<Lead> leads = _leadDomainService.Get(searchString, searchFileds);
      if (leads == null || !leads.Any())
        Error(HttpStatusCode.NoContent, "No Leads found for the given search criteria.");
      return Request.CreateResponse(HttpStatusCode.OK, leads);
    }

    public override HttpResponseMessage GetOne(string Id)
    {
      Lead lead = _leadDomainService.Get(Id);

      if (lead == null)
        Error(HttpStatusCode.NotFound, "No Lead found for the given Id: {0}", new object[] {Id});

      return Request.CreateResponse(HttpStatusCode.OK, lead);
    }

    public override HttpResponseMessage Create(Lead resource)
    {
      if(resource == null)
        Error(HttpStatusCode.NoContent, "Lead can't be null.");

      Lead lead = _leadDomainService.Create(resource);

      if(string.IsNullOrWhiteSpace(resource.Id))
        Error(HttpStatusCode.BadRequest, "Error while creating the Lead.");

      return Request.CreateResponse(HttpStatusCode.Created, lead);
    }

    public override HttpResponseMessage Update(Lead resource)
    {
      //TODO: need to find out a way how can fing update failure
      return Request.CreateResponse(HttpStatusCode.OK, _leadDomainService.Update(resource));
    }

    public override HttpResponseMessage Delete(string Id)
    {
      if (_leadDomainService.Get(Id) == null)
        Error(HttpStatusCode.NotFound, "No Lead found for the given Id: {0}", new object[] {Id});

      _leadDomainService.Delete(Id);
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}