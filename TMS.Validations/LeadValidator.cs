using System;
using System.Linq;
using FluentValidation;
using TMS.Data;
using TMS.Entities;

namespace TMS.Validations
{
  public class StopOnFirstFailureValidator<T> : AbstractValidator<T>
  {
    public StopOnFirstFailureValidator()
    {
      CascadeMode = CascadeMode.StopOnFirstFailure;
    }
  }

  public class BaseEntityValidator : StopOnFirstFailureValidator<Lead>
  {
    public BaseEntityValidator()
    {
      RuleFor(lead => lead.Status).ValidEnum();
    }
  }

  public class DemographicDetailValidator : BaseEntityValidator
  {
    public DemographicDetailValidator()
    {
      RuleFor(detail => detail.CommunicationDetails).SetCollectionValidator(new CommunicationValidator());
      RuleFor(detail => detail.FirstName).NotEmpty();
      RuleFor(detail => detail.LastName).NotEmpty();
      RuleFor(detail => detail.PreferredCommunicationType).ValidEnum().Equal(lead => PreferredCommunicationInCommunicationDetail(lead));
      RuleFor(detail => detail.ReferredBy).NotEmpty();
      RuleFor(detail => detail.Salutation).ValidEnum();
    }

    private static CommunicationType PreferredCommunicationInCommunicationDetail(Lead lead)
    {
      return lead.CommunicationDetails.Where(x => x.CommunicationType == lead.PreferredCommunicationType).Select(x => x.CommunicationType).SingleOrDefault();
    }
  }

  public class CommunicationValidator : StopOnFirstFailureValidator<CommunicationDetail>
  {
    public CommunicationValidator()
    {
      RuleFor(detail => detail.CommunicationType).ValidEnum();
      RuleFor(detail => detail.Uri).NotEmpty();
      RuleFor(detail => detail.Uri).EmailAddress().When(detail => detail.CommunicationType == CommunicationType.Email);
    }
  }

  public class LeadValidator : DemographicDetailValidator
  {
    private readonly DataProvider<User> _userDataProvider;

    public LeadValidator(DataProvider<User> userDataProvider, DataProvider<Course> courseDataProvider)
    {
      _userDataProvider = userDataProvider;

      RuleFor(Lead => Lead.LeadType).ValidEnum();
      RuleFor(Lead => Lead.LeadSource).ValidEnum();
      RuleFor(lead => lead.Courses).SetCollectionValidator(new CourseRequestedValidator(courseDataProvider));
      RuleFor(lead => lead.ExpectedDateOfJoin).GreaterThanOrEqualTo(DateTime.Today).When(lead => lead.ExpectedDateOfJoin.HasValue);
      RuleFor(client => client.DemoDateTime).GreaterThanOrEqualTo(DateTime.Today).When(client => client.DemoDateTime.HasValue);
      RuleFor(client => client.BestTimeToContact).SetCollectionValidator(new BestTimeToCallValidator());
      RuleFor(client => client.City).NotEmpty();
      RuleFor(client => client.Country).NotEmpty();
      RuleFor(client => client.ClientStatus).ValidEnum();
      RuleFor(client => client.Description).NotEmpty();
      RuleFor(client => client.AssignedTo).Equal(lead => UserIsValid(lead));
    }

    private string UserIsValid(Lead lead)
    {
      User user = _userDataProvider.Get(lead.AssignedTo);
      return user == null ? string.Empty : user.Id;
    }
  }

  public class CourseRequestedValidator : StopOnFirstFailureValidator<CourseRequested>
  {
    private readonly DataProvider<Course> _courseDataProvider;

    public CourseRequestedValidator(DataProvider<Course> courseDataProvider)
    {
      _courseDataProvider = courseDataProvider;

      RuleFor(requested => requested.ServiceRequired).ValidEnum();
      RuleFor(requested => requested.CourseId).Equal(requested => CourseValid(requested));
      RuleFor(requested => requested.AmountQuoted).NotEmpty().InclusiveBetween((decimal)1.0, (decimal)9999.0);
    }

    private string CourseValid(CourseRequested requested)
    {
      Course course = _courseDataProvider.Get(requested.CourseId);
      return course == null ? string.Empty : course.Id;
    }
  }

  public class CourseValidator : AbstractValidator<Course>
  {
    public CourseValidator()
    {
      RuleFor(course => course.Description).Length(1, 255);
      RuleFor(course => course.DurationInDays).NotEmpty().InclusiveBetween(1, 1000).When(course => course.DurationInDays.HasValue);
      RuleFor(course => course.Name).NotEmpty().Length(1, 255);
      RuleFor(course => course.Status).ValidEnum();
      RuleFor(course => course.CourseTopics).SetCollectionValidator(new CourseTopicsValidator());
      RuleFor(course => course.Price).NotEmpty().InclusiveBetween(0, 10000);
    }
  }

  public class CourseTopicsValidator : AbstractValidator<CourseTopic>
  {
    public CourseTopicsValidator()
    {
      RuleFor(topic => topic.Duration).NotEmpty().Length(1, 255);
      RuleFor(topic => topic.Progress).ValidEnum();
      RuleFor(topic => topic.Title).NotEmpty().Length(1, 255);
    }
  }

  public class ContactValidator : AbstractValidator<CommunicationDetail>
  {
    public ContactValidator()
    {
      RuleFor(detail => detail.CommunicationType).NotEmpty().ValidEnum();
      RuleFor(detail => detail.Uri).NotEmpty().Length(1, 255);
    }
  }
}
