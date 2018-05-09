using EfLinqDemo.DataAccess.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLinqDemo.CLI
{
    class Lesson13_IQueryableDemo
    {
        public static void BasicExample()
        {
            using (NorthwindContext ctx = new NorthwindContext())
            {
                var products = ctx.Products.AsEnumerable();
            }
        }
    }
}
