using System.Linq;
using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class UserDomainService : IDomainService<User>
  {
    private readonly DataProvider<User> _userDataProvider;

    public UserDomainService(DataProvider<User> userDataProvider)
    {
      _userDataProvider = userDataProvider;
    }

    public IQueryable<User> Get()
    {
      return Get((int?) null);
    }

    public IQueryable<User> Get(int? count)
    {
      return _userDataProvider.Get(count);
    }

    public IQueryable<User> Get(string searchString, string searchFields)
    {
      return _userDataProvider.Get(searchString, searchFields);
    }

    public User Get(string Id)
    {
      return _userDataProvider.Get(Id);
    }

    public User Create(User resource)
    {
      return _userDataProvider.Create(resource);
    }

    public User Update(User resource)
    {
      return _userDataProvider.Update(resource);
    }

    public void Delete(string Id)
    {
      _userDataProvider.Delete(Id);
    }
  }
}