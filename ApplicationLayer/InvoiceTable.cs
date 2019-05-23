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
    public class InvoiceTable
    {
        int rowCount = 1;
        double finalPrice = 0;

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
        public void InsertInvoiceTable()
        {
            using (DocX document = DocX.Load(@Directory.GetCurrentDirectory() + "\\skabelon.docx"))
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
                document.ReplaceText("%TABLE%", "");

                document.SaveAs(@Filepath() + "\\temp.docx");
            }
        }

        public string AddInvoiceLine(string description, string hourlySalary, string hoursWorked)
        {
            using (DocX document = DocX.Load(Filepath() + "\\temp.docx"))
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
                    double total = hourlySalaryDouble * hoursWorkedDouble;
                    finalPrice += total;

                    var rowPattern = invoiceTable.Rows[1];
                    var invoiceRow = invoiceTable.InsertRow(rowPattern, invoiceTable.RowCount);
                    invoiceRow.Cells[0].Paragraphs.First().Append(description.ToUpper()).Italic();
                    invoiceRow.Cells[1].Paragraphs.First().Append(hourlySalary+" DKK");
                    invoiceRow.Cells[2].Paragraphs.First().Append(hoursWorked);
                    invoiceRow.Cells[3].Paragraphs.First().Append(total.ToString()+" DKK").Bold();

                    document.SaveAs(Filepath() + "\\temp.docx");
                    rowCount++;
                    return total.ToString();
                }
            }
        }
    }
}
