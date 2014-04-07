using FluentValidation;

namespace TMS.Validations
{
  public static class FluentExtension
  {
    public static IRuleBuilderOptions<T, TElement> ValidEnum<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
    {
      return ruleBuilder.SetValidator(new ValidEnumPropertyValidator(typeof(TElement)));
    }
  }
}