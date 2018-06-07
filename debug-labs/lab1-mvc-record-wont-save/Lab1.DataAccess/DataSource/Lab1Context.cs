using System.Data.Entity;
using Lab1.DataAccess.Models;

namespace Lab1.DataAccess.DataSource
{
    public class Lab1Context : DbContext
    {
        public DbSet<Advisory> Advisories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
