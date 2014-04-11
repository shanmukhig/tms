using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Web.UI.Controllers
{
    public class CourseTopicController : Controller
    {
        //
        // GET: /CourseTopic/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CourseTopic/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CourseTopic/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CourseTopic/Create

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
        // GET: /CourseTopic/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CourseTopic/Edit/5

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
        // GET: /CourseTopic/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CourseTopic/Delete/5

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
