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
        public ActionResult Index()
        {
            return View();
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
    }
}