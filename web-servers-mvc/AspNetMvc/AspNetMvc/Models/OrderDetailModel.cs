using System;

namespace AspNetMvc.Models
{
    public class OrderDetailModel
    {
        public int OrderID { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public Single Discount { get; set; }
    }
}