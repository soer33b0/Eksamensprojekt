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
                    saveInvoice.Parameters.Add(new SqlParameter("@TotalSalary", invoice.TotalWithoutVAT));
                    saveInvoice.Parameters.Add(new SqlParameter("@InvoiceDesription", invoice.Description));
                    saveInvoice.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl" + e.Message);
                }
            }
        }

        public List<Invoice> GetInvoiceList()
        {
            List<Invoice> invoices = new List<Invoice>();
            Invoice invoice = new Invoice();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {

                    conn.Open();

                    SqlDataAdapter getInvoice = new SqlDataAdapter("SELECT CustomerName, InvoiceDate, InvoiceNum, InvoiceTitle, HoursWorked, HourlySalary, TotalSalary, InvoiceDescription FROM INVOICE AS I JOIN CUSTOMER AS C ON I.CustomerID = C.CustomerID", conn);

                    DataTable dt = new DataTable();
                    getInvoice.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        invoice.InvoiceDate = row["InvoiceDate"].ToString();
                        invoice.InvoiceNum = Convert.ToInt32(row["InvoiceNum"]);
                        invoice.InvoiceTitle = row["InvoiceTitle"].ToString();
                        invoice.HoursWorked = row["HoursWorked"].ToString();
                        invoice.HourlySalary = row["HourlySalary"].ToString();
                        invoice.TotalWithoutVAT = Convert.ToDouble(row["TotalSalary"]);
                        invoice.Description = row["InvoiceDescription"].ToString();
                        invoices.Add(invoice);
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return invoices;
            }
        }

        
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand addCustomer = new SqlCommand("AddCustomer", conn);
                    addCustomer.CommandType = CommandType.StoredProcedure;
                    addCustomer.Parameters.Add(new SqlParameter("@CustomerName", customer.CustomerName));
                    addCustomer.Parameters.Add(new SqlParameter("@CustomerAddress", customer.CustomerAddress));
                    addCustomer.Parameters.Add(new SqlParameter("@CustomerZipCity", customer.CustomerZipCity));
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

        public List<Customer> GetCustomerList()
        {
            Customer customer = new Customer();
            List<Customer> customers = new List<Customer>();

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
                            customers.Add(customer);
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return customers;
            }
        }

        public string[] GetCustomerNames()
        {
            List<string> templist = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand getCustomerNames = new SqlCommand("GetCustomerNames", conn);
                    getCustomerNames.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = getCustomerNames.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            templist.Add(read.GetString(0));
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }

                string[] customerNames = templist.ToArray();
                return customerNames;
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
                    addEmployee.Parameters.Add(new SqlParameter("@EmployeeZipCity", employee.EmployeeZipCity));
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

        public List<Employee> GetEmployeeList()
        {
            Employee employee = new Employee();
            List<Employee> employees = new List<Employee>();

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
                            employee.EmployeeAddress = read["EmployeeAddress"].ToString();
                            employee.EmployeeName = read["EmployeeName"].ToString();
                            employee.EmployeeZipCity = read["EmployeeZipCity"].ToString();
                            employee.EmployeeSeNum = read["EmployeeSeNum"].ToString();
                            employee.EmployeeAccountNum = read["EmployeeAccountNum"].ToString();
                            employees.Add(employee);
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl " + e.Message);
                }
                return employees;
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
