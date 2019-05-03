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

namespace DomainLayer
{
    public class InvoiceGen
    {
            public void OpenDocx(string dir, string fileName)
        {
            string lort = dir + fileName;
            var doc = DocX.Load(lort);

            //Process.Start("WINWORD.EXE", @"C:\Users\Søren\source\repos\Eksamensprojekt\UI\bin\Debug\temp.docx");
        }

        public void SaveDocx(DocX doc, string dir, string fileName)
        {
            doc.SaveAs(dir + fileName);
        }

        public void ReplaceInvoiceText(Customer customer, Employee employee, Invoice invoice)
        {
            string fileName = @"C:\Users\Søren\Desktop\Eksamensprojekt\Fakturaskabelon.docx";
            var doc = DocX.Load(fileName);

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

            doc.SaveAs(@"C:\Users\Søren\source\repos\Eksamensprojekt\UI\bin\Debug\temp.docx");
        }

        public static void AddItemToTable(Table table, Row rowPattern, string productName)
        {
            Invoice invoice = new Invoice("22/11/2018", "333221", "Mathias r dåm", 200, 250, 331123);

            var unitPrice = invoice.HourlySalary;
            var unitQuantity = invoice.HoursWorked;

            // Insert a copy of the rowPattern at the last index in the table.
            var newItem = table.InsertRow(rowPattern, table.RowCount - 1);

            // Replace the default values of the newly inserted row.
            newItem.ReplaceText("%PRODUCT_NAME%", productName);
            newItem.ReplaceText("%PRODUCT_UNITPRICE%", "$ " + unitPrice.ToString("N2"));
            newItem.ReplaceText("%PRODUCT_QUANTITY%", unitQuantity.ToString());
            newItem.ReplaceText("%PRODUCT_TOTALPRICE%", "$ " + (unitPrice * unitQuantity).ToString("N2"));


        }

        public void InvoiceTableGen(/*string description, double unitPrice, double hourlySalary, double totalSalary*/)
        {
            using (DocX doc = DocX.Load(@"C:\Users\Søren\source\repos\Eksamensprojekt\UI\bin\Debug\temp.docx"))
            {
                var invoiceTable = doc.Tables.FirstOrDefault(t => t.TableCaption == "1INVOICE");
                if (invoiceTable == null)
                {
                    MessageBox.Show("\tError, couldn't find table with caption InvoiceTable in current document.");
                }
                else
                {
                    if (invoiceTable.RowCount > 1)
                    {
                        // Get the row pattern of the second row.
                        var rowPattern = invoiceTable.Rows[1];
                        MessageBox.Show(rowPattern.ToString());
                        // Add items (rows) to the grocery list.
                        InvoiceGen.AddItemToTable(invoiceTable, rowPattern, "Banana");
                        InvoiceGen.AddItemToTable(invoiceTable, rowPattern, "Strawberry");
                        InvoiceGen.AddItemToTable(invoiceTable, rowPattern, "Chicken");
                        InvoiceGen.AddItemToTable(invoiceTable, rowPattern, "Bread");
                        InvoiceGen.AddItemToTable(invoiceTable, rowPattern, "Eggs");
                        InvoiceGen.AddItemToTable(invoiceTable, rowPattern, "Salad");

                        // Remove the pattern row.
                        rowPattern.Remove();

                        doc.SaveAs(@"C:\Users\Søren\source\repos\Eksamensprojekt\UI\bin\Debug\temp.docx");
                    }
                }
            }
        }
    }
}