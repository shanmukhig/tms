using System;
using FluentValidation.Validators;

namespace TMS.Validations
{
  public class ValidEnumPropertyValidator : PropertyValidator
  {
    private readonly Type tType;

    public ValidEnumPropertyValidator(Type type, string message) : base(message)
    {
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
      {
        tType = type.GenericTypeArguments[0];
      }
      else
      {
        tType = type;
      }

      if (!tType.IsEnum)
      {
        throw new ArgumentException("Type must be an enum");
      }
    }

    public ValidEnumPropertyValidator(Type type) : this(type, string.Format("Property {{PropertyName}} must be valid enum value for {0}", type.Name)) { }

    protected override bool IsValid(PropertyValidatorContext context)
    {
      return context.PropertyValue == null || Enum.IsDefined(tType, context.PropertyValue);
    }
  }
}