using EfLinqDemo.DataAccess.Models;
using System.Data.Entity;

namespace EfLinqDemo.DataAccess.DataSource
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
