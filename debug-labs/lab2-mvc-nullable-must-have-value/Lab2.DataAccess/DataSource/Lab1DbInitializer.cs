using System.Data.Entity;
using Lab1.DataAccess.Models;

namespace Lab1.DataAccess.DataSource
{
    public class Lab1DbInitializer : DropCreateDatabaseIfModelChanges<Lab1Context>
    {
        protected override void Seed(Lab1Context context)
        {
            base.Seed(context);

            var adv13 = context.Advisories.Add(new Advisory
            {
                AdvisoryText = "13+"
            });

            var advFantasy = context.Advisories.Add(new Advisory
            {
                AdvisoryText = "Contains Fantasy Elements"
            });

            context.SaveChanges();

            context.Books.Add(new Book
            {
                Advisory = adv13,
                Title = "Where The Wild Things Are",
                Publisher = "Harper & Row"
            });

            context.Books.Add(new Book
            {
                Title = "Very Far Away",
                Publisher = "Harper & Row"
            });

            context.Books.Add(new Book
            {
                Title = "The Rainbow Fish",
                Publisher = "NordSud Verlag"
            });

            context.Books.Add(new Book
            {
                Advisory = advFantasy,
                Title = "Harry Potter and The Prisoner of Azkaban",
                Publisher = "Scholastic Corporation"
            });

            context.SaveChanges();
        }
    }
}
