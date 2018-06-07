using System.Data.Entity;
using System.Linq;
using Lab1.DataAccess.DataSource;
using Lab1.DataAccess.Models;
using Lab1.Mvc.Models;

namespace Lab1.Mvc.Services
{
    public class BookService : IDbInjectableService
    {
        public Lab1Context Db { get; set; }

        public IQueryable<BookModel> Get()
        {
            return from book in Db.Books
                   select new BookModel
                   {
                       BookID = book.BookID,
                       Publisher = book.Publisher,
                       Title = book.Title,                       
                       AdvisoryID = book.AdvisoryID.HasValue ? book.AdvisoryID.Value : 0,
                       AdvisoryText = (book.Advisory != null) ? book.Advisory.AdvisoryText : ""
                   };
        }

        public BookModel GetById(int id)
        {
            return Get().FirstOrDefault(x => x.BookID == id);
        }

        public BookModel Create(BookModel model)
        {
            var book = new Book
            {
                AdvisoryID = model.AdvisoryID,
                Publisher = model.Publisher,
                Title = model.Title
            };

            Db.Books.Add(book);
            Db.SaveChanges();

            model.BookID = book.BookID;

            return model;
        }

        public BookModel Update(int id, BookModel model)
        {
            var book = Db.Books.Find(id);
            book.AdvisoryID = model.AdvisoryID;
            book.Title = model.Title;
            book.Publisher = model.Publisher;

            Db.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            var book = new Book
            {
                BookID = id
            };

            Db.Books.Attach(book);
            Db.Entry(book).State = EntityState.Deleted;
            Db.SaveChanges();
        }
    }
}