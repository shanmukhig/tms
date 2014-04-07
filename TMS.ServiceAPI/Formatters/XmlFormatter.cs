using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Xml.Serialization;

namespace TMS.ServiceAPI.Formatters
{

  public class ValidationFilterAttribute : AsyncFilter
  {
    public override Task InternalActionExecuting(HttpActionContext actionContext, CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested || 
          actionContext.Request.Method == HttpMethod.Get ||
          !actionContext.ActionArguments.ContainsKey("resource"))
        return null;

      return null;
    }
  }

  public class AsyncFilter : FilterAttribute, IActionFilter
  {
    public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken,
        Func<Task<HttpResponseMessage>> continuation)
    {
      await InternalActionExecuting(actionContext, cancellationToken);

      if (actionContext.Response != null)
      {
        return actionContext.Response;
      }

      HttpActionExecutedContext executedContext;

      try
      {
        var response = await continuation();
        executedContext = new HttpActionExecutedContext(actionContext, null)
        {
          Response = response
        };
      }
      catch (Exception exception)
      {
        executedContext = new HttpActionExecutedContext(actionContext, exception);
      }

      await InternalActionExecuted(executedContext, cancellationToken);
      return executedContext.Response;
    }

    public virtual Task InternalActionExecuting(HttpActionContext actionContext, CancellationToken cancellationToken)
    {
      return null;
    }

    public virtual Task InternalActionExecuted(HttpActionExecutedContext actionExecutedContext,
        CancellationToken cancellationToken)
    {
      return null;
    }
  }

  public class XmlFormatter : XmlMediaTypeFormatter
  {
    //private readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    //public XmlFormatter()
    //{
    //  SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
    //  SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
    //}

    public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
    {
      var task = new TaskCompletionSource<object>();
      var serializer = new XmlSerializer(type);

      using (var ms = new MemoryStream())
      {
        readStream.CopyTo(ms);

        //ms.Seek(0, SeekOrigin.Begin);

        //Log.IfDebugFormat("Content Length: {0}", ms.Length);
        //Log.IfDebugFormat("Content: {0}", new StreamReader(ms).ReadToEnd());

        //var result = XmlSchemaValidator.Instance().Validate(ms, type);

        //if (!string.IsNullOrWhiteSpace(result))
        //task.SetResult(result);
        //else
        {
          ms.Seek(0, SeekOrigin.Begin);
          var obj = serializer.Deserialize(ms);
          task.SetResult(obj);
        }
      }
      return task.Task;
    }

    public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
    {
      var task = new TaskCompletionSource<object>();
      var serializer = new XmlSerializer(type);

      var regEx = new Regex(@"<\?xml version=""1.0""\?>|<\?xml version=""1.0"" encoding=""utf\-16""\?>|^\\r\\n",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

      using (var sw = new StringWriter())
      {
        serializer.Serialize(sw, value);
        //, new XmlSerializerNamespaces(new[] { new System.Xml.XmlQualifiedName(string.Empty, string.Empty) }));
        var replace = regEx.Replace(sw.ToString(), string.Empty);
        writeStream.Write(Encoding.ASCII.GetBytes(replace), 0, replace.Length);
      }

      task.SetResult(null);
      return task.Task;
    }
  }
}