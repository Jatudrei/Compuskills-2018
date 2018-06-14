using System.Collections.Generic;

namespace EfLinqDemo.DataAccess.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
