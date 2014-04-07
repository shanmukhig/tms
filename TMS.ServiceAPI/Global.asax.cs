using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TMS.ServiceAPI.Formatters;

namespace TMS.ServiceAPI
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      //BundleConfig.RegisterBundles(BundleTable.Bundles);
      GlobalConfiguration.Configuration.Formatters.Clear();
      //for (int i = 0; i < mediaTypeFormatterCollection.Count; i++)
      //{
      //  GlobalConfiguration.Configuration.Formatters.Remove(mediaTypeFormatterCollection[i]);
      //}
      //foreach (MediaTypeFormatter mediaTypeFormatter in mediaTypeFormatterCollection)
      //{
      //  GlobalConfiguration.Configuration.Formatters.Remove(mediaTypeFormatter);
      //}
      GlobalConfiguration.Configuration.Formatters.Add(new XmlFormatter());
      GlobalConfiguration.Configuration.Formatters.Add(new JsonFormatter());
    }
  }
}