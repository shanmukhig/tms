using System.Linq;
using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class CourseDomainSource : IDomainService<Course>
  {
    private readonly DataProvider<Course> _courseDataProvider;

    public CourseDomainSource(DataProvider<Course> courseDataProvider)
    {
      _courseDataProvider = courseDataProvider;
    }

    public IQueryable<Course> Get()
    {
      return Get((int?) null);
    }

    public IQueryable<Course> Get(int? count)
    {
      return _courseDataProvider.Get(count);
    }

    public IQueryable<Course> Get(string searchString, string searchFields)
    {
      return _courseDataProvider.Get(searchString, searchFields);
    }

    public Course Get(string Id)
    {
      return _courseDataProvider.Get(Id);
    }

    public Course Create(Course resource)
    {
      return _courseDataProvider.Create(resource);
    }

    public Course Update(Course resource)
    {
      return _courseDataProvider.Update(resource);
    }

    public void Delete(string Id)
    {
      _courseDataProvider.Delete(Id);
    }
  }
}