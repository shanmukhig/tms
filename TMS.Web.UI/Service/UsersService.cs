using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using TMS.Entities;
using TMS.Web.UI.Controllers;

namespace TMS.Web.UI.Service
{
  public class UsersService : WebService<User>
  {
    public override User Create(User resource)
    {
      throw new NotImplementedException();
    }

    public override User Update(User resource)
    {
      throw new NotImplementedException();
    }

    public override void Delete(string id)
    {
      throw new NotImplementedException();
    }
  }
}