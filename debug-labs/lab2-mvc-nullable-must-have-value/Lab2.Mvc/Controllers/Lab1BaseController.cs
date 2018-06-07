using System.Web.Mvc;
using Lab1.DataAccess.DataSource;
using Lab1.Mvc.Services;

namespace Lab1.Mvc.Controllers
{
    public class Lab1BaseController : Controller
    {
        private Lab1Context _Db;
        protected Lab1Context Db {
            get
            {
                if(_Db == null)
                {
                    _Db = new Lab1Context();
                }

                return _Db;
            }
        }

        protected TService GetService<TService>() where TService : IDbInjectableService, new()
        {
            var service = new TService();
            service.Db = Db;

            return service;
        }

        protected override void Dispose(bool disposing)
        {
            if (_Db != null) _Db.Dispose();

            base.Dispose(disposing);
        }
    }
}