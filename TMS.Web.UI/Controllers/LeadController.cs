using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  //public static class CustomHelpers
  //{
  //  public static MvcHtmlString CustomDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> list, string selectedValue, string optionLabel, object htmlAttributes = null)
  //  {
  //    if (expression == null)
  //    {
  //      throw new ArgumentNullException("expression");
  //    }
  //    ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
  //    string name = ExpressionHelper.GetExpressionText((LambdaExpression)expression);
  //    return CustomDropdownList(htmlHelper, metadata, name, optionLabel, list, selectedValue, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
  //  }

  //  private static MvcHtmlString CustomDropdownList(this HtmlHelper htmlHelper, ModelMetadata metadata, string name, string optionLabel, IEnumerable<SelectListItem> list, string selectedValue, IDictionary<string, object> htmlAttributes)
  //  {
  //    string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
  //    if (String.IsNullOrEmpty(fullName))
  //    {
  //      throw new ArgumentException("name");
  //    }

  //    TagBuilder dropdown = new TagBuilder("select");
  //    dropdown.Attributes.Add("name", fullName);
  //    dropdown.Attributes.Add("id", fullName);
  //    dropdown.Attributes.Add("class", "form-control");
  //    //dropdown.MergeAttribute("data-val", "true");
  //    //dropdown.MergeAttribute("data-val-required", "Mandatory field.");
  //    //dropdown.MergeAttribute("data-val-number", "The field must be a number.");
  //    dropdown.MergeAttributes(htmlAttributes); //dropdown.MergeAttributes(new RouteValueDictionary(htmlAttributes));
  //    //dropdown.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

  //    StringBuilder options = new StringBuilder();

  //    // Make optionLabel the first item that gets rendered.
  //    if (optionLabel != null)
  //      options = options.Append("<option class='flag' value='" + String.Empty + "'>" + optionLabel + "</option>");

  //    foreach (SelectListItem item in list)
  //    {
  //      options.AppendFormat(
  //        "<option value='{0}' {1} data-imagecss='flag flag-{0}' data-image='../../images/blank.png' data-title='{2}'>{2}</option>",
  //        item.Value.ToLower(), item.Selected ? "selected='selected'" : string.Empty, item.Text);
  //    }


  //    //options = list.Aggregate(options,
  //    //  (current, item) =>
  //    //    current.Append(
  //    //      string.Format(
  //    //        "<option value='{0}' {1}><img src='../images/blank.png' class='flag flag-{3}' alt='{4}'/><span>{2}</span></option>",
  //    //        item.Value, item.Selected ? "selected='selected'" : string.Empty, item.Text, item.Value.ToLower(),
  //    //        item.Text)));
  //    dropdown.InnerHtml = options.ToString();
  //    return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
  //  }
  //}

  public class LeadController : Controller
  {
    private readonly IWebService<Lead> _leadService;
    private readonly IWebService<User> _userService;
    private readonly IWebService<Course> _courseWebService;
    private readonly WebService<Country> _countryWebService;

    public LeadController(WebService<Lead> leadService, WebService<User> userService, WebService<Course> courseWebService, WebService<Country> countryWebService)
    {
      _leadService = leadService;
      _userService = userService;
      _courseWebService = courseWebService;
      _countryWebService = countryWebService;
    }

    public ActionResult Search(string searchString, string searchFields)
    {
      ViewBag.Leads = _leadService.Get(searchString, searchFields);
      return View("Index");
    }

    //
    // GET: /Leads/

    public ActionResult Index()
    {
      ViewBag.Leads = _leadService.Get(100);
      return View("Index");
    }

    //
    // GET: /Leads/Details/5

    public ActionResult Details(string id)
    {
      Lead lead = _leadService.Get(id);
      ViewBag.Country = _countryWebService.Get(lead.Country, "Name").Single();
      ViewBag.ReferredBy = _userService.Get(lead.ReferredBy);
      return View("Details", lead);
    }

    //
    // GET: /Leads/Create

    public ActionResult Create()
    {
      Lead lead = new Lead();
      GetUsers(lead);
      GetCourses();
      GetCountries(lead);
      return View("Create", lead);
    }

    private void GetCountries(Lead lead)
    {
      IEnumerable<SelectListItem> selectListItems = from c in _countryWebService.Get((int?)null)
                                                    select new SelectListItem
                                                    {
                                                      Selected = c.Name == lead.Country,
                                                      Text = c.Name,
                                                      Value = c.Code
                                                    };
      if (!string.IsNullOrWhiteSpace(lead.Country))
        lead.Country = selectListItems.Single(x => x.Text.Equals(lead.Country, StringComparison.InvariantCultureIgnoreCase)).Value;
      ViewBag.Countries = selectListItems;
    }

    //
    // POST: /Leads/Create

    [HttpPost]
    public ActionResult CreateLead(FormCollection collection)
    {
      Lead lead = new Lead();
      try
      {
        return RedirectToAction("Index");
      }


      catch
      {
        return View("Create", lead);
      }
    }

    //
    // GET: /Leads/Edit/5

    public ActionResult Edit(string id)
    {
      Lead lead = _leadService.Get(id);
      GetCountries(lead);
      GetUsers(lead);
      GetCourses();
      return View("Edit", lead);
    }

    private void GetUsers(Lead lead)
    {
      IEnumerable<SelectListItem> selectListItems = from u in _userService.Get((int?)null)
                                                    select new SelectListItem
                                                    {
                                                      Text = u.Name,
                                                      Value = u.Id,
                                                      Selected = lead.ReferredBy == u.Id
                                                    };
      SelectList selectList = new SelectList(selectListItems, "Value", "Text", lead.ReferredBy);
      ViewBag.Users = selectList;
    }

    private void GetCourses()
    {
      IEnumerable<SelectListItem> selectListItems = from c in _courseWebService.Get((int?) null)
        select new SelectListItem
        {
          Selected = false,
          Value = c.Id,
          Text = string.Format("Name - {0}, Duration(days): {1}, Price: {2}", c.Name, c.DurationInDays, c.Price)
        };
      ViewBag.Courses = selectListItems;
      //ViewBag.Courses = _courseWebService.Get((int?)null).Select(x => new KeyValuePair<string, string>(x.Id, string.Format("Name - {0}, Duration(days): {1}, Price: {2}", x.Name, x.DurationInDays, x.Price)));
    }

    //
    // POST: /Leads/Edit/5

    [HttpPost]
    public ActionResult EditLead(string id, FormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View("Edit", _leadService.Get(id));
      }
    }

    //
    // GET: /Leads/Delete/5

    public ActionResult Delete(string id)
    {
      return View();
    }

    //
    // POST: /Leads/Delete/5

    [HttpPost]
    public ActionResult Delete(string id, FormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}
