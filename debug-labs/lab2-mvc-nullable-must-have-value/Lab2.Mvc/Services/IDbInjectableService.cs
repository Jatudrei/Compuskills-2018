using Lab1.DataAccess.DataSource;

namespace Lab1.Mvc.Services
{
    public interface IDbInjectableService
    {
        Lab1Context Db { get; set; }
    }
}