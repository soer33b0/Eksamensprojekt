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
        Invoice invoice = new Invoice("29-04-2019", 31, 100, 3100);
        private string connectionString = "Server = ealSQL1.eal.local; Database = A_DB30_2018 ; User Id = A_STUDENT30; Password=A_OPENDB30;";

        public void SaveInvoice(DateTime date, double hoursWorked, double hourlySalary, double totalSalary)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                try
                {
                    SqlCommand saveInvoice = new SqlCommand("SaveInvoice", conn);
                    saveInvoice.CommandType = CommandType.StoredProcedure;
                    saveInvoice.Parameters.Add(new SqlParameter("@InvoiceDate", date));
                    saveInvoice.Parameters.Add(new SqlParameter("@HoursWorked", hoursWorked));
                    saveInvoice.Parameters.Add(new SqlParameter("@HourlySalary", hourlySalary));
                    saveInvoice.Parameters.Add(new SqlParameter("@TotalSalary", totalSalary));
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
    }
}
