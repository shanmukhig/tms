using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class CourseDomainSource : DomainService<Course>
  {
    public CourseDomainSource(DataProvider<Course> courseDataProvider) : base(courseDataProvider)
    {

    }
  }
}