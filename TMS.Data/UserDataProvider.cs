using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TMS.Entities;

namespace TMS.Data
{
  public class UserDataProvider : DataProvider<User>
  {
    public override User Create(User resource)
    {
      Store(resource);
      return resource;
    }

    public override void Delete(string Id)
    {
      Collection.Remove(new QueryDocument("_id", Id));
    }

    public override IQueryable<User> Get(int? count = 100)
    {
      IOrderedQueryable<User> users = Collection.AsQueryable().OrderByDescending(x => x.CreatedOn);
      return count.HasValue ? users.Take(count.Value) : users;
    }

    public override User Get(string Id)
    {
      return Collection.FindOneByIdAs<User>(Id);
    }

    public override User Update(User resource)
    {
      Store(resource);
      return resource;
    }
  }
}