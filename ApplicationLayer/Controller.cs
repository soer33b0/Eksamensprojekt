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
        DBController dbController = new DBController();
        InvoiceGen invoiceGen = new InvoiceGen();
        InvoiceTable invoiceTable = new InvoiceTable();
        CustomerRepo customerRepo = new CustomerRepo();

        public void SaveInvoice(string invoiceDate, string invoiceNum, string invoiceTitle, string hoursWorked, string hourlySalary, string totalSalary, string desription)
        {
            Invoice invoice = new Invoice { InvoiceDate = invoiceDate, InvoiceNum = invoiceNum, InvoiceTitle = invoiceTitle, HoursWorked = hoursWorked, HourlySalary = hourlySalary, TotalSalary = totalSalary, Desription = desription };
            dbController.SaveInvoice(invoice);
        }

        public void CreateInvoice(Customer customer, Employee employee)
        {
            Invoice invoice = new Invoice();

            invoiceGen.ReplaceInvoiceText(customer, employee, invoice);
            invoiceTable.InsertInvoiceTable();
        }

        public List<Invoice> GetInvoiceList()
        {
            return dbController.GetInvoiceList();
        }

        public void AddCustomer(string customerName, string customerAddress, string customerZipCity, string customerEmail, string customerPhone)
        {
            Customer customer = new Customer { CustomerName= customerName, CustomerAddress = customerAddress, CustomerZipCity = customerZipCity, CustomerEmail = customerEmail, CustomerPhone = customerPhone };
            dbController.AddCustomer(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return dbController.GetCustomerList();
        }

        public void AddEmployee(string employeeName, string employeeAddress, string employeeZipCity, string employeeSeNum, string employeeAccountNum)
        {
            Employee employee = new Employee { EmployeeName = employeeName, EmployeeAddress = employeeAddress, EmployeeZipCity = employeeZipCity, EmployeeSeNum = employeeSeNum, EmployeeAccountNum = employeeAccountNum };
            dbController.AddEmployee(employee);
        }

        public List<Employee> GetEmployeeList()
        {
            return dbController.GetEmployeeList();
        }

        public void SaveFisheryRemuneration(double fishPrice, string fishType, double fishWeight, string saleDate, int customerID)
        {
            FisheryRemuneration fisheryRemuneration = new FisheryRemuneration { FishPrice = fishPrice, FishType = fishType, FishWeight = fishWeight, SaleDate = saleDate, CustomerID = customerID };
            dbController.SaveFisheryRemuneration(fisheryRemuneration);
        }

    }
}
