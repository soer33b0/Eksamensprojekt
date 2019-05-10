using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace ApplicationLayer
{
    public class InvoiceSave
    {
        public bool InvSave(double totalprice)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (DocX document = DocX.Load(@path + "\\temp.docx"))
            {
                var invoiceTable = document.Tables.FirstOrDefault(t => t.TableCaption == "INVOICE_TABLE");
                int count = (invoiceTable.RowCount - 2);
                double VAT = totalprice * 0.25;
                double finalprice = totalprice + VAT;

                document.ReplaceText("INVOICE_TABLE", "FAKTURA");
                document.ReplaceText("%VAT%", VAT.ToString());
                document.ReplaceText("%totalPrice%", finalprice.ToString());
                document.ReplaceText("%netto%", totalprice.ToString());

                document.Save();
                return true;
            }
        }
    }
}
