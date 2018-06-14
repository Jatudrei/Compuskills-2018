using EfLinqDemo.DataAccess.DataSource;
using System;
using System.Linq;

namespace EfLinqDemo.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Lesson13_IEnumerableDemo.BasicWithLinq();
        }

        static void BasicEfExample()
        {
            using (NorthwindContext ctx = new NorthwindContext())
            {
                var input = Console.ReadLine();

                var matches = from p in ctx.Products
                              where p.ProductName.Contains(input)
                              select p;

                foreach (var product in matches)
                {
                    Console.WriteLine($"Product Name: {product.ProductName}");
                }
            }

            Console.ReadKey();
        }
    }
}
