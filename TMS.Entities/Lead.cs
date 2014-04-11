using System;
using System.Collections.Generic;

namespace TMS.Entities
{
  public class User : BaseEntity
  {
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
  }

  public class Lead : DemographicDetail
  {
    public LeadType? LeadType { get; set; }
    public LeadSource? LeadSource { get; set; }
    public IEnumerable<CourseRequested> Courses { get; set; }
    public DateTime? ExpectedDateOfJoin { get; set; }
    public DateTime? DemoDateTime { get; set; }
    public IEnumerable<DateTime> BestTimeToContact { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public ClientStatus? ClientStatus { get; set; }
    public string Description { get; set; }
    public string AssignedTo { get; set; }
    public bool IsQualified { get; set; }
  }

  public class CourseRequested
  {
    public string CourseId { get; set; }
    //public string CourseName { get; set; }
    public decimal? AmountQuoted { get; set; }
    public ServiceRequired? ServiceRequired { get; set; }
  }

//  public class Client : DemographicDetail
//  {
//    public Credentials VpnCredentials { get; set; }
//    public Credentials PortalCredentials { get; set; }
//    public Credentials ServerCredentials { get; set; }
//    public CourseDetail CourseDetail { get; set; }
//    public Lead Lead { get; set; }
//    public Employee Employee { get; set; }


//Reference
//BatchTimings
//ConsultantNo
//CourseTimeTable

//ClientType
//Website
//Fax
//CompanyName
//TicketRaised
//AmountPaid
//Installments
//ModeOfPayment
//DemosAttended
//TrainingAgreement

//  }
}
