using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace DomainLayer
{
    public class InvoiceSave
    {
        public string InvSave()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (DocX document = DocX.Load(@path + "\\temp.docx"))
            {
                var invoiceTable = document.Tables.FirstOrDefault(t => t.TableCaption == "INVOICE_TABLE");
                int count = (invoiceTable.RowCount - 2);
                document.ReplaceText("INVOICE_TABLE", "");
                document.Save();
                if (count == 1)
                {
                    return (invoiceTable.RowCount - 2).ToString() + " punkt blev tilføjet. Faktura er gemt.";
                }
                else
                    document.Save();
                    return count.ToString()+" punkter blev tilføjet. Faktura er gemt.";
                
            }
        }
    }
}
