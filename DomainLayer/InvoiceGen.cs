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
            string fileName = @"C:\Users\Søren\Desktop\testlort\skabelon.docx";
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

            doc.SaveAs(@"C:\Users\Søren\Desktop\testlort\temp.docx");
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

        public void InsertTable()
        {
            Console.WriteLine("\tInsertRowAndImageTable()");

            using (DocX document = DocX.Load(@"C:\Users\Søren\Desktop\testlort\skabelon.docx"))
            {
                // Add a Table into the document and sets its values.
                var t = document.AddTable(2, 4);
                t.Design = TableDesign.ColorfulListAccent1;
                t.Alignment = Alignment.center;
                t.Rows[0].Cells[0].Paragraphs[0].Append("Mike");
                t.Rows[0].Cells[1].Paragraphs[0].Append("65");
                t.Rows[0].Cells[2].Paragraphs[0].Append("Kevin");
                t.Rows[0].Cells[3].Paragraphs[0].Append("62");
                t.Rows[1].Cells[0].Paragraphs[0].Append("Carl");
                t.Rows[1].Cells[1].Paragraphs[0].Append("60");
                t.Rows[1].Cells[2].Paragraphs[0].Append("Michael");
                t.Rows[1].Cells[3].Paragraphs[0].Append("59");

                document.InsertTable(t);

                // Add a row at the end of the table and sets its values.
                var r = t.InsertRow();
                r.Cells[0].Paragraphs[0].Append("Mario");
                r.Cells[1].Paragraphs[0].Append("Kart");
                r.Cells[1].Paragraphs[0].Append("Nigga");
                r.Cells[1].Paragraphs[0].Append("!");

                document.SaveAs(@"C:\Users\Søren\Desktop\testlort\temp.docx");
            }
        }
    }
}
