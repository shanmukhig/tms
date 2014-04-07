using System.Web.Mvc;

namespace TMS.Web.UI.Controllers
{
    public class CommunicationDetailController : Controller
    {
        //
        // GET: /CommunicationDetail/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CommunicationDetail/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CommunicationDetail/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CommunicationDetail/Create

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
        // GET: /CommunicationDetail/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CommunicationDetail/Edit/5

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
        // GET: /CommunicationDetail/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CommunicationDetail/Delete/5

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
