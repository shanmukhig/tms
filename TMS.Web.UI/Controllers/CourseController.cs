using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public class CourseController : Controller
  {
    private readonly IWebService<Course> _courseWebService;

    public CourseController(WebService<Course> courseWebService)
    {
      _courseWebService = courseWebService;
    }

    //
    // GET: /Course/

    public ActionResult Index()
    {
      ViewBag.Courses = _courseWebService.Get((int?) null);
      return View();
    }

    public ActionResult Search(string searchString, string searchFields)
    {
      if (string.IsNullOrWhiteSpace(searchString) || string.IsNullOrWhiteSpace(searchFields))
        RedirectToAction("Index");
      ViewBag.Courses = _courseWebService.Get(searchString, searchFields);
      return View("Index");
    }

    //
    // GET: /Course/Details/5

    public ActionResult Details(string id)
    {
      return View(_courseWebService.Get(id));
    }

    //
    // GET: /Course/Create

    public ActionResult Create()
    {
      return View(new Course());
    }

    //
    // POST: /Course/Create

    [HttpPost]
    public ActionResult CreateCourse(Course course)
    {
      try
      {
        _courseWebService.Create(course);
        return null;
      }
      catch
      {
        return View("Create", course);
      }
    }

    //
    // GET: /Course/Edit/5

    public ActionResult Edit(string id)
    {
      return View("Edit", _courseWebService.Get(id));
    }

    //
    // POST: /Course/Edit/5

    [HttpPost]
    public ActionResult EditCourse(Course course)
    {
      try
      {
        _courseWebService.Update(course);
        return null;
      }
      catch
      {
        return View("Edit", course);
      }
    }

    //
    // GET: /Course/Delete/5

    public ActionResult Delete(string id)
    {
      _courseWebService.Delete(id);
      return View("Index");
    }
  }
}
