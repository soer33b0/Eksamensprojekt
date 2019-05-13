using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ApplicationLayer
{
    public class InvoiceRepo
    {
        private List<Invoice> invoices = new List<Invoice>();

        public void AddInvoice(Invoice invoice)
        {
            invoices.Add(invoice);
        }

        public List<Invoice> GetInvoice()
        {
            List<Invoice> showInvoice = new List<Invoice>();
            return showInvoice;
        }
    }
}
