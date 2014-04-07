using System;

namespace TMS.Entities
{
  public class Credentials
  {
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
  }
}