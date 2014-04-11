using System;
using System.Collections.Generic;
using TMS.Entities;

namespace TMS.Web.UI.Service
{
  public class CoursesService : WebService<Course>
  {
    public override IEnumerable<Course> Get(string searchString, string searchField)
    {
      throw new NotImplementedException();
    }

    public override Course Get(string id)
    {
      throw new NotImplementedException();
    }

    public override Course Create(Course resource)
    {
      throw new NotImplementedException();
    }

    public override Course Update(Course resource)
    {
      throw new NotImplementedException();
    }

    public override void Delete(string id)
    {
      throw new NotImplementedException();
    }
  }
}