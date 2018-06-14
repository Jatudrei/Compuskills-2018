using KosbieDb.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace KosbieDb.DataAccess.Repositories
{
    public class CustomersRepository : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public CustomersRepository()
        {
            Connection = CreateConnection();
            Connection.Open();
        }

        public CustomerModel GetCustomerByName(string name)
        {
            return null;
        }

        public void CreateCustomer(CustomerModel model)
        {

        }

        public List<CustomerModel> GetCustomers()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", Connection);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<CustomerModel> result = new List<CustomerModel>();
            while (rdr.Read())
            {
                result.Add(new CustomerModel
                {
                    CustomerID = rdr.GetInt32(0),
                    CustomerName = rdr.GetString(1)
                });
            }

            return result;
        }

        public SqlDataReader ReadCustomers()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void UpdateCustomer()
        {

        }

        private SqlConnection CreateConnection()
        {
            var cstring = ConfigurationManager.ConnectionStrings["LocalSqlExpress"];
            return new SqlConnection(cstring.ConnectionString);
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
