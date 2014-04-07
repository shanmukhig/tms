using StructureMap;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.DependencyResolution
{
  public static class IoC
  {
    public static IContainer Initialize()
    {
      return new Container(
        expression =>
        {
          expression.For<WebService<Lead>>().HybridHttpOrThreadLocalScoped().Use<LeadsService>();
          expression.For<WebService<User>>().HybridHttpOrThreadLocalScoped().Use<UsersService>();
          expression.For<WebService<Course>>().HybridHttpOrThreadLocalScoped().Use<CoursesService>();
          //expression.For<IValidator<Lead>>().Singleton().Use<LeadValidator>().Named(typeof(LeadValidator).Name);
          expression.For<WebService<Country>>().HybridHttpOrThreadLocalScoped().Use<CountryService>();
        });
    }
  }
}