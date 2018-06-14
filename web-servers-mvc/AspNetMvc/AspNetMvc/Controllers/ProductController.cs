using AspNetMvc.DataAccess.DataSource;
using AspNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (var ctx = new NorthwindContext())
            {
                var products = (from p in ctx.Products
                                select new ProductModel
                                {
                                    ProductID = p.ProductID
                                })
                               .ToList();

                return View(products);
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (var ctx = new NorthwindContext())
            {
                var product = ctx.Products
                    .Where(x => x.ProductID == id)
                    .Select(x => new ProductModel {
                        ProductID = x.ProductID
                    })
                    .FirstOrDefault();

                return View(product);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
