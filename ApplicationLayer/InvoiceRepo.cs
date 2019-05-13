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
        private List<Invoice> ListInvoice;

        public InvoiceRepo()
        {
            ListInvoice = new List<Invoice>();
        }

        public void AddInvoice(Invoice invoice)
        {
            ListInvoice.Add(invoice);
        }

        public List<Invoice> GetInvoice()
        {
            List<Invoice> showInvoice = new List<Invoice>();
            return showInvoice;
        }
    }
}
