using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class UserDomainService : DomainService<User>
  {
    public UserDomainService(DataProvider<User> userDataProvider) : base(userDataProvider)
    {
    }
  }
}