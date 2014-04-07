using System;
using FluentValidation;

namespace TMS.Validations
{
  public class BestTimeToCallValidator : StopOnFirstFailureValidator<DateTime>
  {
    public BestTimeToCallValidator()
    {
      RuleFor(call => call).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
    }
  }
}