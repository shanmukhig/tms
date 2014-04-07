using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TMS.ServiceAPI.Formatters
{
  public class JsonFormatter : JsonMediaTypeFormatter
  {
    //public JsonFormatter()
    //{
    //  SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/json"));
    //  SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
    //}

    public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
    {
      var task = new TaskCompletionSource<object>();

      using (var ms = new MemoryStream())
      {
        readStream.CopyTo(ms);
        //ms.Seek(0, SeekOrigin.Begin);

        //var result = JsonSchemaValidator.Instance().Validate(ms, type);

        //if (!string.IsNullOrWhiteSpace(result))
        //  task.SetResult(result);
        //else
        {
          ms.Seek(0, SeekOrigin.Begin);
          using (var reader = new JsonTextReader(new StreamReader(ms)))
          {
            var serializer = new JsonSerializer();
            task.SetResult(serializer.Deserialize(reader, type));
          }
        }
      }
      return task.Task;
    }

    public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    {
      var task = new TaskCompletionSource<object>();
      var serializer = new JsonSerializer();

      using (var sw = new StringWriter())
      {
        serializer.Serialize(sw, value);
        var bytes = Encoding.ASCII.GetBytes(sw.ToString());
        writeStream.Write(bytes, 0, bytes.Length);
      }
      task.SetResult(null);
      return task.Task;
    }
  }
}