using System.ComponentModel.DataAnnotations;

namespace Lab1.Mvc.Models
{
    public class AdvisoryModel
    {
        public int AdvisoryID { get; set; }

        [Display(Name = "Advisory Text"), Required]
        public string AdvisoryText { get; set; }
    }
}