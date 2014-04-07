using System.IO;
using System.Net;

namespace TMS.Web.UI.Controllers
{
  public class Response
  {
    public HttpStatusCode StatusCode { get; set; }
    public string StatusDescription { get; set; }
    public Stream Content;
    public string ContentType;
  }
}