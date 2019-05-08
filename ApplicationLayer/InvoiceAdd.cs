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
        public List<string> items = new List<string>();

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

                    newItem.Cells[3].Paragraphs.First().Append("Beløb");

                    document.SaveAs(@"C:\Users\Søren\Desktop\testlort\temp.docx");
                }
            }
        }

        public void arraylort()
        {
            using (DocX document = DocX.Load(@"C:\Users\Søren\Desktop\testlort\temp.docx"))
            {
                var invoiceTable = document.Tables.FirstOrDefault(t => t.TableCaption == "INVOICE_TABLE");

                string[] lineItems = items.ToArray();

                for (int i = 0; i < items.Count + 1; i++)
                {
                    string[] splitLineItems = lineItems[i].Split(',');
                    

                    Row totalRow = invoiceTable.InsertRow();
                    totalRow.Cells[0].Paragraphs.First().Append(splitLineItems[0]);
                    totalRow.Cells[1].Paragraphs.First().Append(splitLineItems[1]);
                    totalRow.Cells[2].Paragraphs.First().Append(splitLineItems[2]);

                    invoiceTable.Rows.Add(totalRow);
                }

               
                document.Save();
            }
        }
    }
}
