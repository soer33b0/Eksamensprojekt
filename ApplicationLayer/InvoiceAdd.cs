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
        double finalPrice = 0;
        public string AddInvoiceLine(string description, string hourlySalary, string hoursWorked)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (DocX document = DocX.Load(path + "\\temp.docx"))
            {
                var invoiceTable = document.Tables.FirstOrDefault(t => t.TableCaption == "INVOICE_TABLE");

                if (invoiceTable == null)
                {
                    return "\tError, couldn't find table with caption INVOICE_TABLE in current document.";
                }
                else
                {
                    double hourlySalaryDouble = Convert.ToDouble(hourlySalary);
                    double hoursWorkedDouble = Convert.ToDouble(hoursWorked);
                    double total = hourlySalaryDouble + hoursWorkedDouble;
                    finalPrice += total;
                    var rowPattern = invoiceTable.Rows[rowCount];

                    // Insert a copy of the rowPattern at the last index in the table.
                    
                    var pislort = invoiceTable.InsertRow(rowPattern, invoiceTable.RowCount);
                    pislort.Cells[0].Paragraphs.First().Append(description.ToUpper()).Italic();
                    pislort.Cells[1].Paragraphs.First().Append(hourlySalary+" DKK");
                    pislort.Cells[2].Paragraphs.First().Append(hoursWorked);
                    pislort.Cells[3].Paragraphs.First().Append(total.ToString()+" DKK").Bold();


                    document.SaveAs(@path+"\\temp.docx");
                    rowCount++;
                    return total.ToString();
                }
            }
        }
    }
}
