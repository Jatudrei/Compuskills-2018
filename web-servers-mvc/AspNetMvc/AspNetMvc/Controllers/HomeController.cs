using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMvc.Models;

namespace AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        public static int NumberOfTimesAccessed { get; set; } = 0;

        public ActionResult Index()
        {
            NumberOfTimesAccessed++;

            return View(NumberOfTimesAccessed);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult HelloWorld()
        {
            return View();
        }

        public ActionResult AboutYou()
        {
            return View();
        }

        //In a full-fledged app, this would be a generic view which could be used with any person;
        //Data would come from the DB
        public ActionResult AboutYyKosbie()
        {
            var yyKosbie = new PersonModel
            {
                Name = "YY Kosbie",
                JobTitle = "Teacher",
                YearsExperience = 13
            };

            return View(yyKosbie);
        }

        public ActionResult AboutYehoshuaKahan()
        {
            var yehoshua = new PersonModel
            {
                Name = "Yehoshua Kahan",
                JobTitle = "Student",
                YearsExperience = 1
            };

            return View("AboutYyKosbie", yehoshua);
        }

        [HttpPost]
        public ActionResult UrlParamDemo(int id, int? age, string name)
        {
            return Json(new { Id = id, Age = age, Name = name }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UrlParamDemo(int id)
        {
            return Json(new { Id = id }, JsonRequestBehavior.AllowGet);
        }
    }
}