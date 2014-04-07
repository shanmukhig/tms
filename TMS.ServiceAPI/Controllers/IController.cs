using System.Net.Http;

namespace TMS.ServiceAPI.Controllers
{
  public interface IController<in T> where T : class
  {
    HttpResponseMessage Get(int? count);
    HttpResponseMessage Get(string searchString, string searchFileds);
    HttpResponseMessage GetOne(string Id);
    HttpResponseMessage Create(T resource);
    HttpResponseMessage Update(T resource);
    HttpResponseMessage Delete(string Id);
  }
}