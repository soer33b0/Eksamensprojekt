using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public class DBController
    {
        Invoice invoice = new Invoice();
        private string connectionString = "Server = ealSQL1.eal.local; Database = A_DB30_2018 ; User Id = A_STUDENT30; Password=A_OPENDB30;";

        public void SaveInvoice()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                try
                {
                    string filepath = "";
                    FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(stream);
                    Byte[] file = reader.ReadBytes((int)stream.Length);
                    reader.Close();
                    stream.Close();

                    SqlCommand command;
                    SqlConnection connection = new SqlConnection(connectionString);
                    command = new SqlCommand("INSERT INTO FileTable (File) Values(@file)", connection);
                    command.Parameters.Add("file", SqlDbType.Binary, file.Length).Value = file;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Fejl" + e.Message);
                }
            }
        }
    }
}
