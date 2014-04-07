using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TMS.Web.UI.Controllers
{
  public static class EnumHelper
  {
    public static string PascalCaseToPrettyString<TEnum>(this HtmlHelper helper, TEnum s)
    {
      return PascalCaseToPrettyString(s.ToString());
    }

    public static string PascalCaseToPrettyString(this HtmlHelper helper, string s)
    {
      return PascalCaseToPrettyString(s);
    }

    public static string PascalCaseToPrettyString(this string s)
    {
      return Regex.Replace(s, @"(\B[A-Z]|[0-9]+)", " $1");
    }

    private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
    {
      Type realModelType = modelMetadata.ModelType;

      Type underlyingType = Nullable.GetUnderlyingType(realModelType);
      if (underlyingType != null)
      {
        realModelType = underlyingType;
      }
      return realModelType;
    }

    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
    {
      ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
      Type enumType = GetNonNullableModelType(metadata);
      IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

      TypeConverter converter = TypeDescriptor.GetConverter(enumType);

      IEnumerable<SelectListItem> items =
        from value in values
        select new SelectListItem
        {
          Text = converter.ConvertToString(value).PascalCaseToPrettyString(),
          Value = value.ToString(),
          Selected = value.Equals(metadata.Model)
        };
      return htmlHelper.DropDownListFor(expression, items, "Select One...",
        new
        {
          @class = "form-control",
        });
    }

    public static MvcHtmlString LabelForPascal<TModel, TProp>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProp>> expression, string propName = null)
    {
      ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
      //Type enumType = GetNonNullableModelType(metadata);

      return htmlHelper.LabelFor(expression, string.IsNullOrWhiteSpace(propName) ? metadata.PropertyName.PascalCaseToPrettyString() : propName);
    }
  }
}