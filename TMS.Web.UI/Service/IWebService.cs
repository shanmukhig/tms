using System.Collections.Generic;

namespace TMS.Web.UI.Service
{
  public interface IWebService<T> where T : class
  {
    IEnumerable<T> Get(int? count);
    IEnumerable<T> Get(string searchString, string searchField);
    T Get(string Id);
    T Create(T resource);
    T Update(T resource);
    void Delete(string Id);
  }
}