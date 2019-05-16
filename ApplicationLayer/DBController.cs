using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ApplicationLayer
{
    public class DBController
    {

        private string connectionString = "Server = ealSQL1.eal.local; Database = A_DB30_2018 ; User Id = A_STUDENT30; Password=A_OPENDB30;";

        public void  SaveInvoice(Invoice invoice)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand saveInvoice = new SqlCommand("SaveInvoice", conn);
                    saveInvoice.CommandType = CommandType.StoredProcedure;
                    saveInvoice.Parameters.Add(new SqlParameter("@InvoiceDate", invoice.InvoiceDate));
                    saveInvoice.Parameters.Add(new SqlParameter("@InvoiceNum", invoice.InvoiceNum));
                    saveInvoice.Parameters.Add(new SqlParameter("@InvoiceTitle", invoice.InvoiceTitle));
                    saveInvoice.Parameters.Add(new SqlParameter("@HoursWorked", invoice.HoursWorked));
                    saveInvoice.Parameters.Add(new SqlParameter("@HourlySalary", invoice.HourlySalary));
                    saveInvoice.Parameters.Add(new SqlParameter("@TotalSalary", invoice.TotalSalary));
                    saveInvoice.Parameters.Add(new SqlParameter("@InvoiceDesription", invoice.Desription));
                    saveInvoice.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl" + e.Message);
                }
            }
        }

        public List<Invoice> ShowInvoice()
        {
            List<Invoice> invoice = new List<Invoice>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand showInvoice = new SqlCommand("ShowInvoice", conn);
                    showInvoice.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = showInvoice.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            string invoiceID = read["InvoiceID"].ToString();
                            string customerID = read["CustomerID"].ToString();
                            string invoiceDate = read["InvoiceDate"].ToString();
                            string hoursWorked = read["HoursWorked"].ToString();
                            string hourlySalary = read["HourlySalary"].ToString();
                            string totalSalary = read["TotalSalary"].ToString();
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return invoice;
            }
        }

        public Invoice GetInvoice()
        {
            Invoice invoice = new Invoice();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand getInvoice = new SqlCommand("GetInvoice", conn);
                    getInvoice.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = getInvoice.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            invoice.InvoiceDate = read["InvoiceDate"].ToString();
                            invoice.InvoiceNum = read["InvoiceNum"].ToString();
                            invoice.InvoiceTitle = read["InvoiceTitle"].ToString();
                            invoice.HoursWorked = read["HoursWorked"].ToString();
                            invoice.HourlySalary = read["HourlySalary"].ToString();
                            invoice.TotalSalary = read["TotalSalary"].ToString();
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return invoice;
            }

        }

        public void AddCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                try
                {
                    SqlCommand addCustomer = new SqlCommand("AddCustomer", conn);
                    addCustomer.CommandType = CommandType.StoredProcedure;
                    addCustomer.Parameters.Add(new SqlParameter("@CustomerName", customer.CustomerName));
                    addCustomer.Parameters.Add(new SqlParameter("@CustomerAddress", customer.CustomerAddress));
                    addCustomer.Parameters.Add(new SqlParameter("@CustomerZipZity", customer.CustomerZipCity));
                    addCustomer.Parameters.Add(new SqlParameter("@CustomerEmail", customer.CustomerEmail));
                    addCustomer.Parameters.Add(new SqlParameter("@CustomerPhone", customer.CustomerPhone));
                    addCustomer.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl" + e.Message);
                }
            }
        }

        public Customer GetCustomer()
        {
            Customer customer = new Customer();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand getCustomer = new SqlCommand("GetCustomer", conn);
                    getCustomer.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = getCustomer.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            customer.CustomerAddress = read["CustomerAddress"].ToString();
                            customer.CustomerEmail = read["CustomerEmail"].ToString();
                            customer.CustomerName = read["CustomerName"].ToString();
                            customer.CustomerPhone = read["CustomerPhone"].ToString();
                            customer.CustomerZipCity = read["CustomerZipCity"].ToString();
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return customer;
            }

        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                try
                {
                    SqlCommand addEmployee = new SqlCommand("AddEmployee", conn);
                    addEmployee.CommandType = CommandType.StoredProcedure;
                    addEmployee.Parameters.Add(new SqlParameter("@EmployeeName", employee.EmployeeName));
                    addEmployee.Parameters.Add(new SqlParameter("@EmployeeAddress", employee.EmployeeAddress));
                    addEmployee.Parameters.Add(new SqlParameter("@EmployeeZipZity", employee.EmployeeZipCity));
                    addEmployee.Parameters.Add(new SqlParameter("@EmployeeSeNum", employee.EmployeeSeNum));
                    addEmployee.Parameters.Add(new SqlParameter("@EmployeeAccountNum", employee.EmployeeAccountNum));
                    addEmployee.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl" + e.Message);
                }
            }
        }

        public Employee GetEmployee()
        {
            Employee employee = new Employee();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand getEmployee = new SqlCommand("GetEmployee", conn);
                    getEmployee.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = getEmployee.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            employee.EmployeeName = read["EmployeeName"].ToString();
                            employee.EmployeeAddress = read["EmplyeeAddress"].ToString();
                            employee.EmployeeZipCity = read["EmployeeZipCity"].ToString();
                            employee.EmployeeSeNum = read["EmployeeSeNum"].ToString();
                            employee.EmployeeAccountNum = read["EmployeeAccountNum"].ToString();
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return employee;
            }

        }

        public void SaveFisheryRemuneration(FisheryRemuneration fisheryRemuneration)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand saveFisheryRemuneration = new SqlCommand("SaveFisheryRemuneration", conn);
                    saveFisheryRemuneration.CommandType = CommandType.StoredProcedure;
                    saveFisheryRemuneration.Parameters.Add(new SqlParameter("@FishPrice", fisheryRemuneration.FishPrice));
                    saveFisheryRemuneration.Parameters.Add(new SqlParameter("@FishType", fisheryRemuneration.FishType));
                    saveFisheryRemuneration.Parameters.Add(new SqlParameter("@FishWeight", fisheryRemuneration.FishWeight));
                    saveFisheryRemuneration.Parameters.Add(new SqlParameter("@SaleDate", fisheryRemuneration.SaleDate));
                    saveFisheryRemuneration.Parameters.Add(new SqlParameter("@CustomerID", fisheryRemuneration.CustomerID));
                    saveFisheryRemuneration.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl" + e.Message);
                }
            }
        }
        public FisheryRemuneration GetFisheryRemuneration()
        {
            FisheryRemuneration fisheryRemuneration = new FisheryRemuneration();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand getFisheryRemuneration = new SqlCommand("GetFisheryRemuneration", conn);
                    getFisheryRemuneration.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = getFisheryRemuneration.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            fisheryRemuneration.FishPrice = Convert.ToDouble(read["FishPrice"]);
                            fisheryRemuneration.FishType = read["FishType"].ToString();
                            fisheryRemuneration.FishWeight = Convert.ToDouble(read["FishWeight"]);
                            fisheryRemuneration.SaleDate = read["SaleDate"].ToString();
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return fisheryRemuneration;
            }
        }
    }
}
