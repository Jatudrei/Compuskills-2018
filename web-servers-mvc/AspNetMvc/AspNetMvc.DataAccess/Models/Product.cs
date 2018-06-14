namespace AspNetMvc.DataAccess.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public string ProductName { get; set; }
    }
}