using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TMS.Web.UI.Controllers
{
  public static class RenderView
  {
    public static string RenderViewToString(string controllerName, string viewName, object viewData, KeyValuePair<string, object>? additionalData)
    {
      var context = HttpContext.Current;
      var contextBase = new HttpContextWrapper(context);
      var routeData = new RouteData();
      routeData.Values.Add("controller", controllerName);

      var controllerContext = new ControllerContext(contextBase,
        routeData,
        new EmptyController());

      var razorViewEngine = new RazorViewEngine();
      var razorViewResult = razorViewEngine.FindView(controllerContext,
        viewName,
        "",
        false);

      ViewDataDictionary vdd = new ViewDataDictionary(viewData);
      if(additionalData.HasValue)
        vdd.Add(additionalData.Value);

      var writer = new StringWriter();
      var viewContext = new ViewContext(controllerContext,
        razorViewResult.View,
        vdd,
        new TempDataDictionary(),
        writer);
      razorViewResult.View.Render(viewContext, writer);

      return writer.ToString();
    }
  }
}