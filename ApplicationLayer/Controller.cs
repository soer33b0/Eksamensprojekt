using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ApplicationLayer
{
    public class Controller
    {
        DBController Dbcontroller = new DBController();

        public void SaveInvoice(string invoiceDate, string invoiceNum, string invoiceTitle, int hoursWorked, double hourlySalary, double totalSalary)
        {
            Invoice invoice = new Invoice { InvoiceDate = invoiceDate, InvoiceNum = invoiceNum, InvoiceTitle = invoiceTitle, HoursWorked = hoursWorked, HourlySalary = hourlySalary, TotalSalary = totalSalary };
            Dbcontroller.SaveInvoice(invoice);
        }
        public List<Invoice> ShowInvoice()
        {
            return Dbcontroller.ShowInvoice();
        }
        public void AddCustomer(string customerName, string customerAddress, string customerZipCity, string customerEmail, string customerPhone)
        {
            Customer customer = new Customer { CustomerName= customerName, CustomerAddress = customerAddress, CustomerZipCity = customerZipCity, CustomerEmail = customerEmail, CustomerPhone = customerPhone };
            Dbcontroller.AddCustomer(customer);
        }
    }
}
