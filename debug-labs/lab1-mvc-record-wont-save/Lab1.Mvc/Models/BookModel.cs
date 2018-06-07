using System.ComponentModel.DataAnnotations;

namespace Lab1.Mvc.Models
{
    public class BookModel
    {
        public int BookID { get; set; }

        [Display(Name = "Advisory (optional)"), UIHint("AdvisorySelector")]
        public int AdvisoryID { get; set; }
        [Display(Name = "Advisory Text")]
        public string AdvisoryText { get; set; }

        public string Title { get; set; }
        public string Publisher { get; set; }
    }
}