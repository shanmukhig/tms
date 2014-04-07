using System.Linq;

namespace TMS.Data
{
  public interface IDataProvider<T> where T : class
  {
    IQueryable<T> Get(int? count = 100);
    IQueryable<T> Get(string searchString, string searchFields);
    T Get(string Id);
    T Create(T resource);
    T Update(T resource);
    void Delete(string Id);
  }
}