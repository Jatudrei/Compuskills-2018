using EfLinqDemo.DataAccess.DataSource;
using EfLinqDemo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLinqDemo.CLI
{
    class Lesson13_IQueryableDemo
    {
        public string CurrentCountry { get; set; } = "USA";

        public static void BasicExample()
        {
            using (NorthwindContext ctx = new NorthwindContext())
            {
                var products = ctx.Products;
                var count = products.Count();
            }
        }

        public IQueryable<Product> IncrementalQueryExample(bool includeDiscontinued)
        {
            using (NorthwindContext ctx = new NorthwindContext())
            {
                IQueryable<Product> products = ctx.Products;

                if (!includeDiscontinued)
                {
                    products = products.Where(x => !x.Discontinued);
                }

                if (CurrentCountry == "USA")
                {
                    products = products.Where(x => x.Supplier.CountryName != "USA");
                }

                return products;
            }
        }
    }
}
