using System.Data.Entity;
using System.Linq;
using Lab1.DataAccess.DataSource;
using Lab1.DataAccess.Models;
using Lab1.Mvc.Models;

namespace Lab1.Mvc.Services
{
    public class AdvisoryService : IDbInjectableService
    {
        public Lab1Context Db { get; set; }

        public IQueryable<AdvisoryModel> Get()
        {
            return from advisory in Db.Advisories
                   select new AdvisoryModel
                   {
                       AdvisoryID = advisory.AdvisoryID,
                       AdvisoryText = advisory.AdvisoryText
                   };
        }

        public AdvisoryModel GetById(int id)
        {
            return Get().FirstOrDefault(x => x.AdvisoryID == id);
        }

        public AdvisoryModel Create(AdvisoryModel model)
        {
            var advisory = new Advisory
            {
                AdvisoryText = model.AdvisoryText
            };

            Db.Advisories.Add(advisory);
            Db.SaveChanges();

            model.AdvisoryID = advisory.AdvisoryID;

            return model;
        }

        public AdvisoryModel Update(int id, AdvisoryModel model)
        {
            var advisory = Db.Advisories.Find(id);
            advisory.AdvisoryText = model.AdvisoryText;

            Db.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            var advisory = new Advisory
            {
                AdvisoryID = id
            };

            Db.Advisories.Attach(advisory);
            Db.Entry(advisory).State = EntityState.Deleted;
            Db.SaveChanges();
        }
    }
}