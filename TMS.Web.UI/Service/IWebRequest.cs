using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using TMS.Web.UI.Controllers;

namespace TMS.Web.UI.Service
{
  public interface IWebRequest
  {
    WebRequest Url(string url);
    WebRequest HttpMethod(HttpMethod httpMethod);
    WebRequest QueryParams(IEnumerable<KeyValuePair<string, string>> queryParams);
    WebRequest Headers(IEnumerable<KeyValuePair<string, string>> headers);
    WebRequest PostBody(string postBody);
    WebRequest PostBody(Stream stream);
    Response PostResponse();
    Response GetResponse();
    HttpWebRequest PostRequest();
    HttpWebRequest GetRequest();
    WebRequest ContentType(ContentType contentType);
  }
}