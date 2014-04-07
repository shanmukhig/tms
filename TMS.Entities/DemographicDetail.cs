using System.Collections.Generic;

namespace TMS.Entities
{
  public class DemographicDetail : BaseEntity
  {
    //public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Salutation? Salutation { get; set; }
    public string ReferredBy { get; set; }
    public IEnumerable<CommunicationDetail> CommunicationDetails { get; set; }
    public CommunicationType? PreferredCommunicationType { get; set; }
  }
}