using AspNetMvc.Attributes;
using AspNetMvc.DataAccess.DataSource;
using AspNetMvc.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc.Controllers
{
    [Authorize(Roles = "Technician,Manager,Accounting")]
    public class OrderController : Controller
    {
        [HttpGet]
        [AuthorizeRequestAccessType(AccessTypes = RequestAccessType.Local | RequestAccessType.VPN)]
        public ActionResult OrderDetails(int id, string sortby)
        {
            using (var ctx = new NorthwindContext())
            {
                var lines = ctx.OrderDetails
                    .Where(x => x.OrderID == id)
                    .Select(x => new OrderDetailModel
                    {
                        OrderID = x.OrderID,
                        Discount = x.Discount,
                        ProductName = x.Product.ProductName,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice
                    });

                if(sortby == "name")
                {
                    lines = lines.OrderBy(x => x.ProductName);
                }

                return PartialView(lines.ToList());
            }
        }

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