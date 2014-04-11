using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMS.Business;
using TMS.Entities;

namespace TMS.ServiceAPI.Controllers
{
  public class CourseAPIController : CustomController<Course>
  {
    private readonly IDomainService<Course> _courseDomainService;

    public CourseAPIController(DomainService<Course> courseDomainService)
    {
      _courseDomainService = courseDomainService;
    }

    public override HttpResponseMessage Get(string searchString, string searchFileds)
    {
      if (string.IsNullOrWhiteSpace(searchString) || string.IsNullOrWhiteSpace(searchFileds))
        return Get(null);
      IQueryable<Course> courses = _courseDomainService.Get(searchString, searchFileds);
      if (courses == null || !courses.Any())
        Error(HttpStatusCode.NoContent, "No Courses found for the given criteria");
      return Request.CreateResponse(HttpStatusCode.OK, courses);
    }

    public override HttpResponseMessage Get(int? count)
    {
      IQueryable<Course> courses = _courseDomainService.Get(count);

      if (courses == null || !courses.Any())
        Error(HttpStatusCode.NoContent, "No Courses found.");

      return Request.CreateResponse(HttpStatusCode.OK, courses);
    }

    public override HttpResponseMessage GetOne(string Id)
    {
      Course course = _courseDomainService.Get(Id);

      if (course == null)
        Error(HttpStatusCode.NotFound, "No Course found for the given Id: {0}.", new object[] {Id});

      return Request.CreateResponse(HttpStatusCode.OK, course);
    }

    public override HttpResponseMessage Create(Course resource)
    {
      if(resource == null)
        Error(HttpStatusCode.BadRequest, "Incorrect course details.");

      Course course = _courseDomainService.Create(resource);

      if (string.IsNullOrWhiteSpace(resource.Id))
        Error(HttpStatusCode.BadRequest, "Error while creating Course.");

      return Request.CreateResponse(HttpStatusCode.Created, course);
    }

    [HttpPut]
    public override HttpResponseMessage Update(Course resource)
    {
      //TODO: need to find out a way how can fing update failure
      return Request.CreateResponse(HttpStatusCode.OK, _courseDomainService.Update(resource));
    }

    public override HttpResponseMessage Delete(string Id)
    {
      if(_courseDomainService.Get(Id) == null)
          Error(HttpStatusCode.NotFound, "No Course found for the given Id: {0}", new object[] { Id });

      _courseDomainService.Delete(Id);
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}