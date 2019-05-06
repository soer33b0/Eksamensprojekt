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

        public void SaveInvoice(Invoice invoice)
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
                    saveInvoice.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine("Faktura gemt!");
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
                            Console.WriteLine(invoiceID + " " + customerID + " " + invoiceDate + " " + hoursWorked + " " + hourlySalary + " " + totalSalary);
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
                            string invoiceID = read["InvoiceID"].ToString();
                            string customerID = read["CustomerID"].ToString();
                            string invoiceDate = read["InvoiceDate"].ToString();
                            string hoursWorked = read["HoursWorked"].ToString();
                            string hourlySalary = read["HourlySalary"].ToString();
                            string totalSalary = read["TotalSalary"].ToString();
                            Console.WriteLine(invoiceID + " " + customerID + " " + invoiceDate + " " + hoursWorked + " " + hourlySalary + " " + totalSalary);
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
                    Console.Clear();
                    Console.WriteLine("Faktura gemt!");
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Fejl" + e.Message);
                }
            }
        }
    }
}
