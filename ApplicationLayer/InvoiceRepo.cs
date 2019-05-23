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

        /*public List<Invoice> GetInvoiceList()
        {
            UpdateInvoiceList();
            return invoices;
        }*/
        public string[] GetInvoiceList()
        {
            List<string> invoiceList = new List<String>();

            foreach (Invoice invoice in invoices)
            {
                invoiceList.Add(invoice.CustomerName);
                invoiceList.Add(invoice.InvoiceDate);
                invoiceList.Add(invoice.InvoiceNum);
                invoiceList.Add(invoice.InvoiceTitle);
                invoiceList.Add(invoice.HourlySalary);
                invoiceList.Add(invoice.HoursWorked);
                invoiceList.Add(invoice.TotalSalary);
                invoiceList.Add(invoice.Description);
                UpdateInvoiceList();
            }

            return invoiceList.ToArray();
        }
    }
}
