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
        Controller controller = new Controller();
        private List<Invoice> invoices = new List<Invoice>();

        public void AddInvoice(Invoice invoice)
        {
            invoices.Add(invoice);
        }

        public void UpdateInvoiceList()
        {
            invoices = controller.GetInvoiceList();
        }

        public List<Invoice> GetInvoiceList()
        {
            UpdateInvoiceList();
            return invoices;
        }

        
        
    }
}
