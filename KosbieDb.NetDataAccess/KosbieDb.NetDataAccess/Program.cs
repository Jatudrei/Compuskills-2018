using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace KosbieDb.NetDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("(S)how name, (B)enchmark, (U)pdate, (L)ist, or (E)nter Row Mode: ");
                var op = Console.ReadLine();

                if (op.ToLower() == "s")
                {
                    Console.WriteLine(ConfigurationManager.AppSettings["name"]);
                }
                else if(op.ToLower() == "b")
                {
                    RunBenchmark();
                }
                else if (op.ToLower() == "u")
                {
                    Console.Write("ID: ");
                    var customerId = Console.ReadLine();

                    Console.Write("New First Name: ");
                    var newFirst = Console.ReadLine();

                    UpdateCustomer(customerId, newFirst);
                }
                else if (op.ToLower() == "e")
                {
                    DataTable customers = GetAllCustomers();

                    while (true)
                    {
                        Console.Write("(R)ow #: ");
                        var rowNum = Console.ReadLine();

                        var asInt = int.Parse(rowNum);
                        Console.WriteLine($"Customer ID: {customers.Rows[asInt].Field<int>("CustomerID")}, First Name: {customers.Rows[asInt].Field<string>("FirstName")}, Last Name: {customers.Rows[asInt].Field<string>("LastName")}");
                    }
                }
                else
                {
                    WriteCustomers();
                }
            }
        }

        static void RunBenchmark()
        {
            const int PASSES = 100;
            var sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            for (var i = 0; i < PASSES; i++)
            {
                SortAndPrintTop1000InCSharp();
            }
            sw.Stop();
            var cSharpTime = sw.ElapsedMilliseconds;

            sw.Reset();
            sw.Start();
            for(var i = 0; i < PASSES; i++)
            {
                SortAndPrintTop1000InSql();
            }
            sw.Stop();
            var sqlTime = sw.ElapsedMilliseconds;

            Console.WriteLine($"C# Time Elapsed: {cSharpTime}, SQL Time Elapsed: {sqlTime}");
        }

        static void SortAndPrintTop1000InCSharp()
        {
            using(SqlConnection conn = new SqlConnection(@"Server=DESKTOP-TG040F0;Database=AdventureWorks2012;Integrated Security=true"))
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT BusinessEntityID, FirstName, LastName FROM Person.Person", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                var rows = dt.Select("", "LastName");
                for(var i=0; i<1000; i++)
                {
                    var row = rows[i];
                    Console.WriteLine($"B I ID: {row.Field<int>("BusinessEntityID")}, First: {row.Field<string>("FirstName")}, Last: {row.Field<string>("LastName")}");
                }
            }
        }

        static void SortAndPrintTop1000InCSharpMoreEfficient()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=DESKTOP-TG040F0;Database=AdventureWorks2012;Integrated Security=true"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT BusinessEntityID, FirstName, LastName FROM Person.Person", conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<Customer> customers = new List<Customer>()
                {
                    new Customer() { Lastname = "z" }
                };

                while (rdr.Read())
                {
                    var lastName = rdr.GetString(2);
                    for (int i = 0; i < customers.Count; i++)
                    {
                        if(customers[i].Lastname.CompareTo(lastName) > 0)
                        {
                            customers.Insert(i, new Customer
                            {
                                Id = rdr.GetInt32(0),
                                Firstname = rdr.GetString(1),
                                Lastname = rdr.GetString(2)
                            });

                            break;
                        }
                    }
                }

                for (var i = 0; i < 1000; i++)
                {
                    var row = customers[i];
                    Console.WriteLine($"B I ID: {row.Id}, First: {row.Firstname}, Last: {row.Lastname}");
                }
            }
        }

        static void SortAndPrintTop1000InSql()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=DESKTOP-TG040F0;Database=AdventureWorks2012;Integrated Security=true"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP 1000 PersonType, MAX(ModifiedDate) FROM Person.Person GROUP BY PersonType ", conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine($"B I ID: {rdr.GetInt32(0)}, First: {rdr.GetString(1)}, Last: {rdr.GetString(2)}");
                }
            }
        }

        static void WriteCustomers()
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                Console.WriteLine("Results");
                while (rdr.Read())
                {
                    Console.WriteLine("Customer ID: {0}, First Name: {1}, Last Name: {2}", rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                }
            }
        }

        static DataTable GetAllCustomers()
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers", conn);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                return dt;
            }
        }

        static DataTable GetAllCustomersViaRepo()
        {
            var repo = new CustomersRepository();
            return repo.GetCustomers();
        }

        static void WriteAllCustomersViaRepo()
        {
            using (var repo = new CustomersRepository())
            {
                var rdr = repo.ReadCustomers();

                while (rdr.Read())
                {

                }
            }
        }

        static void UpdateCustomer(string customerId, string firstName)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Customers SET FirstName=@p1 WHERE CustomerID=@p2", conn);
                cmd.Parameters.Add(new SqlParameter("p1", firstName));
                cmd.Parameters.Add(new SqlParameter("p2", int.Parse(customerId)));
                cmd.ExecuteNonQuery();
            }
        }

        private static SqlConnection CreateConnection()
        {
            var cstring = ConfigurationManager.ConnectionStrings["LocalSqlExpress"];
            return new SqlConnection(cstring.ConnectionString);
        }

        private class Customer
        {
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
        }
    }
}
