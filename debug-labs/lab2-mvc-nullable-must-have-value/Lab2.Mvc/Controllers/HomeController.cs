using System.Web.Mvc;

namespace Lab1.Mvc.Controllers
{
    public class HomeController : Lab1BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BugDescription()
        {
            return View();
        }

        public ActionResult Hints()
        {
            return View();
        }

        public ActionResult Demo()
        {
            return View();
        }
    }
}