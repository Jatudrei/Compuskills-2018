using Lab1.DataAccess.Models;
using Lab1.Mvc.Models;
using Lab1.Mvc.Services;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Lab1.Mvc.Controllers
{
    public class BookController : Lab1BaseController
    {
        // GET: Book
        public ActionResult Index()
        {
            var books = GetService<BookService>().Get();

            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = GetService<BookService>().GetById(id);

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookModel model)
        {
            if(ModelState.IsValid)
            {
                GetService<BookService>().Create(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = GetService<BookService>().GetById(id);

            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookModel model)
        {
            if(ModelState.IsValid)
            {
                GetService<BookService>().Update(id, model);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = GetService<BookService>().GetById(id);

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookModel model)
        {
            GetService<BookService>().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
