using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using DomainLayer;
using System.IO;
using System.Windows;
using System.Threading;

namespace ApplicationLayer
{
    public class InvoiceGen
    {
        public string Filepath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            bool exists = System.IO.Directory.Exists(path + "\\Fakturaer");

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(path + "\\Fakturaer");
                return path + "\\Fakturaer";
            }
            else return path + "\\Fakturaer";
        }
        public void OpenDocxFromShow(string filePath)
        {
            Process.Start(filePath);
           
        }


        public void ReplaceInvoiceText(Customer customer, Employee employee, Invoice invoice)
        {
            var doc = DocX.Load(Filepath() + "\\temp.docx");
            doc.ReplaceText("%customerName%", customer.CustomerName);
            doc.ReplaceText("%customerAddress%", customer.CustomerAddress);
            doc.ReplaceText("%customerZipCity%", customer.CustomerZipCity);

            doc.ReplaceText("%employeeName%", employee.EmployeeName);
            doc.ReplaceText("%employeeAddress%", employee.EmployeeAddress);
            doc.ReplaceText("%employeeZipCity%", employee.EmployeeZipCity);
            doc.ReplaceText("%seNum%", employee.EmployeeSeNum);
            doc.ReplaceText("%accountNum%", employee.EmployeeAccountNum);

            doc.ReplaceText("%title%", invoice.InvoiceTitle);
            doc.ReplaceText("%invoiceDate%", "Dato: " + invoice.InvoiceDate.ToString());
            doc.ReplaceText("%invoiceNum%", "Faktura nummer: " + invoice.InvoiceNum);

            doc.SaveAs(@Filepath() + "\\temp.docx");
        }
        
        public string InvoiceCalc(Invoice invoice)
        {
            using (DocX document = DocX.Load(@Filepath() + "\\temp.docx"))
            {
                var invoiceTable = document.Tables.FirstOrDefault(t => t.TableCaption == "INVOICE_TABLE");
                int count = (invoiceTable.RowCount - 2);
                double VAT = Convert.ToDouble(invoice.TotalWithoutVAT) * 0.25;
                double finalprice = Convert.ToDouble(invoice.TotalWithoutVAT + VAT);
                string finalpath = (@Filepath() + "\\faktura-" + invoice.InvoiceNum + "-" + DateTime.Now.ToString("dd-MM-yyyy") + ".docx");

                document.ReplaceText("%VAT%", VAT.ToString());
                document.ReplaceText("%totalPrice%", finalprice.ToString());
                document.ReplaceText("%netto%", invoice.TotalWithoutVAT.ToString());

                document.SaveAs(finalpath);
                File.Delete((@Filepath() + "\\temp.docx"));

                return finalpath;
            }
        }
    }
}
