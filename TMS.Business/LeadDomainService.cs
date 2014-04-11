using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class LeadDomainService : DomainService<Lead>
  {
    public LeadDomainService(DataProvider<Lead> leadDataProvider) : base(leadDataProvider)
    {
    }
  }
}