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
        int rowCount = 1;
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
                   
                    var rowPattern = invoiceTable.Rows[rowCount];

                    // Insert a copy of the rowPattern at the last index in the table.
                    
                    var pislort = invoiceTable.InsertRow(rowPattern, invoiceTable.RowCount);
                    pislort.Cells[0].Paragraphs.First().Append(description);
                    pislort.Cells[1].Paragraphs.First().Append(hourlySalary);
                    pislort.Cells[2].Paragraphs.First().Append(hoursWorked);
                    pislort.Cells[3].Paragraphs.First().Append("%PRODUCT_TOTALPRICE%");


                    document.SaveAs(@"C:\Users\Søren\Desktop\testlort\temp.docx");
                    rowCount++;
                }
            }
        }
    }
}
