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
      _courseWebService.Get((int?)null);
      return View();
    }

    //
    // GET: /Course/Details/5

    public ActionResult Details(int id)
    {
      return View();
    }

    //
    // GET: /Course/Create

    public ActionResult Create()
    {
      return View();
    }

    //
    // POST: /Course/Create

    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Course/Edit/5

    public ActionResult Edit(int id)
    {
      return View();
    }

    //
    // POST: /Course/Edit/5

    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Course/Delete/5

    public ActionResult Delete(int id)
    {
      return View();
    }

    //
    // POST: /Course/Delete/5

    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
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
