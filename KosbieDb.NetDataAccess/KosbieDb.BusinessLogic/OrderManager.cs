using KosbieDb.BusinessLogic.Models;
using KosbieDb.DataAccess.Models;
using KosbieDb.DataAccess.Repositories;

namespace KosbieDb.BusinessLogic
{
    public class OrderManager
    {
        public void CreateOrder(CreateOrderModel createOrderModel)
        {
            using (CustomersRepository repo = new CustomersRepository())
            {
                var existing = repo.GetCustomerByName(createOrderModel.CustomerName);
                if(existing == null)
                {
                    repo.CreateCustomer(new CustomerModel
                    {
                        CustomerName = createOrderModel.CustomerName
                    });
                }

                ordersRepo.CreateOrder(...);
            }
        }
    }
}
