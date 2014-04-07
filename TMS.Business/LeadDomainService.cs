using System.Linq;
using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class LeadDomainService : IDomainService<Lead>
  {
    private readonly IDataProvider<Lead> _leadDataProvider;
    private readonly IDataProvider<Course> _courseDataProvider;

    public LeadDomainService(DataProvider<Lead> leadDataProvider, DataProvider<Course> courseDataProvider)
    {
      _leadDataProvider = leadDataProvider;
      _courseDataProvider = courseDataProvider;
    }

    public IQueryable<Lead> Get()
    {
      return Get((int?) null);
    }

    public IQueryable<Lead> Get(int? count)
    {
      IQueryable<Lead> leads = _leadDataProvider.Get(count);
      foreach (Lead lead in leads)
      {
        if(lead.Courses == null || !lead.Courses.Any())
          continue;
        foreach (CourseRequested courseRequested in lead.Courses)
        {
          courseRequested.CourseName = _courseDataProvider.Get(courseRequested.CourseId).Name;
        }
      }
      return leads;
    }

    public IQueryable<Lead> Get(string searchString, string searchFields)
    {
      return _leadDataProvider.Get(searchString, searchFields);
    }

    public Lead Get(string id)
    {
      Lead lead = _leadDataProvider.Get(id);
      if (lead.Courses == null || !lead.Courses.Any())
        return lead;

      foreach (CourseRequested courseRequested in lead.Courses)
      {
        courseRequested.CourseName = _courseDataProvider.Get(courseRequested.CourseId).Name;
      }
      return lead;
    }

    public Lead Create(Lead resource)
    {
      return _leadDataProvider.Create(resource);
    }

    public Lead Update(Lead resource)
    {
      return _leadDataProvider.Update(resource);
    }

    public void Delete(string Id)
    {
      _leadDataProvider.Delete(Id);
    }
  }
}