﻿using System;
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

        public void InsertInvoiceTable()
        {
            Console.WriteLine("\tInsertRowAndImageTable()");

            using (DocX document = DocX.Load(path + "temp.docx"))
            {
                // Add a Table into the document and sets its values.
                var t = document.AddTable(2, 4);
                t.TableCaption = "INVOICE_TABLE";
                t.Design = TableDesign.ColorfulListAccent1;
                t.Alignment = Alignment.center;
                t.Rows[0].Cells[0].Paragraphs.First().Append("Beskrivelse");
                t.Rows[0].Cells[1].Paragraphs.First().Append("Enhedspris");
                t.Rows[0].Cells[2].Paragraphs.First().Append("Antal");
                t.Rows[0].Cells[3].Paragraphs.First().Append("Beløb").Bold();
                
                foreach (var paragraph in document.Paragraphs) 
                {
                    paragraph.FindAll("%TABLE%").ForEach(index => paragraph.InsertTableAfterSelf((t)));
                }
                document.ReplaceText("%TABLE%", t.TableCaption);

                document.SaveAs(@path+"\\temp.docx");
            }
        }
    }
}
