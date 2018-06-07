namespace Lab1.DataAccess.Models
{
    public class Book
    {
        public int BookID { get; set; }

        public int? AdvisoryID { get; set; }
        public virtual Advisory Advisory { get; set; }

        public string Title { get; set; }
        public string Publisher { get; set; }
    }
}
