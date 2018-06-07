using Lab1.Mvc.Models;
using Lab1.Mvc.Services;
using System.Web.Mvc;

namespace Lab1.Mvc.Controllers
{
    public class AdvisoryController : Lab1BaseController
    {
        // GET: Advisory/GetAdvisories
        public ActionResult GetAdvisories()
        {
            var advisories = GetService<AdvisoryService>().Get();

            return Json(advisories, JsonRequestBehavior.AllowGet);
        }

        // GET: Advisory
        public ActionResult Index()
        {
            var advisories = GetService<AdvisoryService>().Get();

            return View(advisories);
        }

        // GET: Advisory/Details/5
        public ActionResult Details(int id)
        {
            var advisory = GetService<AdvisoryService>().GetById(id);

            return View(advisory);
        }

        // GET: Advisory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advisory/Create
        [HttpPost]
        public ActionResult Create(AdvisoryModel model)
        {
            if (ModelState.IsValid)
            {
                GetService<AdvisoryService>().Create(model);                

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Advisory/Edit/5
        public ActionResult Edit(int id)
        {
            var advisory = GetService<AdvisoryService>().GetById(id);

            return View(advisory);
        }

        // POST: Advisory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AdvisoryModel model)
        {
            if(ModelState.IsValid)
            {
                GetService<AdvisoryService>().Update(id, model);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Advisory/Delete/5
        public ActionResult Delete(int id)
        {
            var advisory = GetService<AdvisoryService>().GetById(id);

            return View(advisory);
        }

        // POST: Advisory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AdvisoryModel model)
        {
            GetService<AdvisoryService>().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
