using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace DomainLayer
{
    public class InvoiceGen
    {
        public void OpenDocx()
        {
            string fileName = @"C:\Users\Søren\Desktop\Eksamensprojekt\Fakturaskabelon.docx";

            var doc = DocX.Load(fileName);

            doc.SaveAs("temp.docx");

            //Process.Start("WINWORD.EXE", @"C:\Users\Søren\source\repos\Eksamensprojekt\UI\bin\Debug\test.docx");
        }

        public void ReplaceInvoiceText(string customerName, string customerAddress, string customerZipCity, string employeeName, string employeeAddress, string employeeZipCity)
        {

        }
        

    }

    
}