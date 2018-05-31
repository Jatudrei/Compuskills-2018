using AspNetMvc.DataAccess.DataSource;
using AspNetMvc.Models;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult Details(int id)
        {
            var order = GetOrderById(id);
            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var order = GetOrderById(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(int id, OrderModel model)
        {
            return RedirectToAction("Details", new { id = id });
        }

        private OrderModel GetOrderById(int id)
        {
            using (var ctx = new NorthwindContext())
            {
                var order = ctx.Orders
                    .Where(x => x.OrderID == id)
                    .Select(x => new OrderModel
                    {
                        OrderID = x.OrderID,
                        CustomerID = x.CustomerID,
                        CustomerName = x.Customer.ContactName,
                        EmployeeID = x.EmployeeID,
                        EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,
                        Freight = x.Freight,
                        OrderDate = x.OrderDate,
                        RequiredDate = x.RequiredDate,
                        ShipAddress = x.ShipAddress,
                        ShipCity = x.ShipCity,
                        ShipCountry = x.ShipCountry,
                        ShipName = x.ShipName,
                        ShippedDate = x.ShippedDate,
                        ShipPostalCode = x.ShipPostalCode,
                        ShipRegion = x.ShipRegion
                    })
                    .SingleOrDefault();

                return order;
            }
        }
    }
}