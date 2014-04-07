using System.Linq;

namespace TMS.Business
{
  public interface IDomainService<T> where T : class
  {
    IQueryable<T> Get(int? count);
    IQueryable<T> Get(string searchString, string searchFields);
    T Get(string Id);
    T Create(T resource);
    T Update(T resource);
    //T Delete(T resource);
    void Delete(string Id);
  }
}
