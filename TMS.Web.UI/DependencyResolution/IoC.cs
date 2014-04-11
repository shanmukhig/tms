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
          expression.For(typeof (IWebService<>)).HybridHttpOrThreadLocalScoped().Use(typeof (WebService<>));
        });
    }
  }
}