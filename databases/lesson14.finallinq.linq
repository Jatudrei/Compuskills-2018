<Query Kind="Expression">
  <Connection>
    <ID>4100e8c5-1f7d-4d87-adc1-33ff590eede4</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

(from employee in Employees
//from order in employee.Orders
//group order by order.Customer.City into ordersByCity
//where ordersByCity.Count() > 1
//from order in ordersByCity
//group order by order.Employee into ordersByEmployee
//let employee = ordersByEmployee.Key
where employee.Orders.GroupBy(x => x.Customer.City).Count() > 1
where employee.Orders.Select(x => x.OrderDetails.Where(y => !y.Product.Discontinued && y.UnitPrice > 10)).Count() > 0
select new {
	employee,
	salesInPastYear = (from order in employee.Orders
					   where (DateTime.Now - order.OrderDate).Value.TotalDays <= 365
					   select order.OrderDetails.Where(x => !x.Product.Discontinued).Sum(x => x.UnitPrice))
					  .Sum()
} into employeeSales
orderby employeeSales.salesInPastYear descending
select employeeSales.employee)
.Take(3)