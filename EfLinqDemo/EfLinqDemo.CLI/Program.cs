using EfLinqDemo.DataAccess.DataSource;
using System;
using System.Linq;

namespace EfLinqDemo.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindContext ctx = new NorthwindContext())
            {
                foreach (var product in ctx.Products.Where(p => p.UnitsInStock.HasValue && p.UnitsInStock.Value >= 5))
                {
                    Console.WriteLine($"Product Name: {product.ProductName}, In Stock: {product.UnitsInStock ?? 0}");
                }

                var cntProducts = ctx.Products.Count();
                Console.WriteLine($"There {cntProducts} products in the Northwind DB.");
            }

            Console.ReadKey();
        }
    }
}
