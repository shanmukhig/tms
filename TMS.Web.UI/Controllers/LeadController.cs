using System.Collections.Generic;
using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public class LeadController : Controller
  {
    private readonly IWebService<Lead> _leadService;

    public LeadController(IWebService<Lead> leadService, IWebService<User> userService,
      IWebService<Course> courseWebService, IWebService<Country> countryWebService)
    {
      _leadService = leadService;
      IEnumerable<User> users = userService.Get((int?) null);
      IEnumerable<Country> countries = countryWebService.Get((int?) null);
      IEnumerable<Course> courses = courseWebService.Get((int?) null);
      ViewBag.Courses = courses;
      ViewBag.Users = users;
      ViewBag.Countries = countries;
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
      //ViewBag.ReferredBy = _userService.Get(lead.ReferredBy);
      return View("Details", lead);
    }

    //
    // GET: /Leads/Create

    public ActionResult Create()
    {
      Lead lead = new Lead();
      return View("Create", lead);
    }

    //
    // POST: /Leads/Create

    [HttpPost]
    public ActionResult CreateLead(Lead lead)
    {
      try
      {
        _leadService.Create(lead);
        return null;
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
      return View("Edit", lead);
    }

    //
    // POST: /Leads/Edit/5

    [HttpPost]
    public ActionResult EditLead(Lead lead)
    {
      try
      {
        _leadService.Update(lead);
        return null;
      }
      catch
      {
        return View("Edit", _leadService.Get(lead.Id));
      }
    }

    //
    // GET: /Leads/Delete/5

    public ActionResult Delete(string id)
    {
      _leadService.Delete(id);
      return null;
    }
  }
}
