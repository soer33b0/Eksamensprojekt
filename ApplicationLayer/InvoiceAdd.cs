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
    public class InvoiceAdd
    {
        public void AddInvoiceLine(string description, string hourlySalary, string hoursWorked)
        {
            using (DocX document = DocX.Load(@"C:\Users\Søren\Desktop\testlort\temp.docx"))
            {
                var invoiceTable = document.Tables.FirstOrDefault(t => t.TableCaption == "INVOICE_TABLE");

                if (invoiceTable == null)
                {
                    Console.WriteLine("\tError, couldn't find table with caption INVOICE_TABLE in current document.");
                }
                else
                {
                    Invoice invoice = new Invoice();
                    InvoiceGen invoiceGen = new InvoiceGen();
                    var rowPattern = invoiceTable.Rows[1];

                    // Insert a copy of the rowPattern at the last index in the table.
                    var newItem = invoiceTable.InsertRow(rowPattern, invoiceTable.RowCount - 1);

                    // Replace the default values of the newly inserted row.
                    newItem.ReplaceText("%PRODUCT_NAME%", description);
                    newItem.ReplaceText("%PRODUCT_UNITPRICE%", "$ " + hourlySalary);
                    newItem.ReplaceText("%PRODUCT_QUANTITY%", hoursWorked);
                    newItem.ReplaceText("%PRODUCT_TOTALPRICE%", "$ " + (Convert.ToDouble(hourlySalary) * Convert.ToDouble(hoursWorked)).ToString("N2"));

                    document.SaveAs(@"C:\Users\Søren\Desktop\testlort\temp.docx");
                }
            }
        }
    }
}
