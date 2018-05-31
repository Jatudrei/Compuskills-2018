using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMvc.Models
{
    public class ProductModel
    {
        [Display(Name = "Product Number")]
        public int ProductID { get; set; }
    }
}