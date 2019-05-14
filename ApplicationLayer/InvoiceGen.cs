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

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public void OpenDocx(string dir, string fileName)
        {
            string lort = path + fileName;
            var doc = DocX.Load(lort);
        }

        public void SaveDocx(DocX doc, string dir, string fileName)
        {
            doc.SaveAs(dir + fileName);
        }

        public void ReplaceInvoiceText(Customer customer, Employee employee, Invoice invoice)
        {
            string fileName = path + "\\skabelon.docx";
            var doc = DocX.Load(@fileName);

            doc.ReplaceText("%customerName%", customer.CustomerName);
            doc.ReplaceText("%customerAddress%", customer.CustomerAddress);
            doc.ReplaceText("%customerZipCity%", customer.CustomerZipCity);

            doc.ReplaceText("%employeeName%", employee.EmployeeName);
            doc.ReplaceText("%employeeAddress%", employee.EmployeeAddress);
            doc.ReplaceText("%employeeZipCity%", employee.EmployeeZipCity);
            doc.ReplaceText("%seNum%", employee.EmployeeSeNum);
            doc.ReplaceText("%accountNum%", employee.EmployeeAccountNum);

            doc.ReplaceText("%title%", invoice.InvoiceTitle);

            doc.ReplaceText("%invoiceDate%", invoice.InvoiceDate);
            doc.ReplaceText("%invoiceNum%", invoice.InvoiceNum);

            doc.SaveAs(@path + "temp.docx");
        }

        
        public bool InvSave(double totalprice)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (DocX document = DocX.Load(@path + "\\temp.docx"))
            {
                var invoiceTable = document.Tables.FirstOrDefault(t => t.TableCaption == "INVOICE_TABLE");
                int count = (invoiceTable.RowCount - 2);
                double VAT = totalprice * 0.25;
                double finalprice = totalprice + VAT;

                document.ReplaceText("%VAT%", VAT.ToString());
                document.ReplaceText("%totalPrice%", finalprice.ToString());
                document.ReplaceText("%netto%", totalprice.ToString());

                document.SaveAs(@path + "\\temp.docx");
                return true;
            }
        }
    }
}
