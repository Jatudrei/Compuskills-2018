using KosbieDb.BusinessLogic;

namespace KosbieDb.ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderManager = new OrderManager();
            orderManager.CreateOrder();
        }
    }
}
