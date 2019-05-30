using DomainLayer;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xceed.Words.NET;

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
        public void OpenDocx(string dir, string fileName)
        {
            if (dir == "")
            {
                string where = Filepath() + fileName;
                Process.Start(where);
            }
            else
            {
                string where = Filepath() + fileName;
                Process.Start(dir, @where);
            }
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
                string finalpath = ("\\faktura-" + invoice.InvoiceNum + "-" + DateTime.Now.ToString("dd-MM-yyyy") + ".docx");

                document.ReplaceText("%VAT%", VAT.ToString());
                document.ReplaceText("%totalPrice%", finalprice.ToString());
                document.ReplaceText("%netto%", invoice.TotalWithoutVAT.ToString());

                document.SaveAs(@Filepath() + finalpath);
                File.Delete((@Filepath() + "\\temp.docx"));

                return finalpath;
            }
        }
    }
}