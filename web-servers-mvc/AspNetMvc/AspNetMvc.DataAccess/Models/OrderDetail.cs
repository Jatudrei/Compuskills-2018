using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvc.DataAccess.Models
{
    [Table("Order Details")]
    public class OrderDetail
    {
        [Key, Column(Order=0)]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public Single Discount { get; set; }
    }
}