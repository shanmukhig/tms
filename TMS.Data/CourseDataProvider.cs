using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TMS.Entities;

namespace TMS.Data
{
  public class CourseDataProvider : DataProvider<Course>
  {
    public override IQueryable<Course> Get(int? count)
    {
      IOrderedQueryable<Course> courses = Collection.AsQueryable().OrderByDescending(x => x.CreatedOn);
      return count.HasValue ? courses.Take(count.Value) : courses;
    }

    public override Course Get(string Id)
    {
      return Collection.FindOneByIdAs<Course>(Id);
    }

    public override Course Create(Course resource)
    {
      Store(resource);
      return resource;
    }

    public override Course Update(Course resource)
    {
      Store(resource);
      return resource;
    }

    public override void Delete(string Id)
    {
      Collection.Remove(new QueryDocument("_id", Id));
    }
  }
}