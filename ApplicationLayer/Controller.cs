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
        public void SaveInvoice(string invoiceDate, string invoiceNum, string invoiceTitle, string hoursWorked, string hourlySalary, string totalSalary, string desription)
        {
            DBController dbController = new DBController();
            Invoice invoice = new Invoice { InvoiceDate = invoiceDate, InvoiceNum = invoiceNum, InvoiceTitle = invoiceTitle, HoursWorked = hoursWorked, HourlySalary = hourlySalary, TotalSalary = totalSalary, Desription = desription };
            dbController.SaveInvoice(invoice);
        }

        public void CreateInvoice(Customer customer, Employee employee)
        {
            DBController dbController = new DBController();
            InvoiceGen invoiceGen = new InvoiceGen();
            Invoice invoice = new Invoice();
            InvoiceTable invoiceTable = new InvoiceTable();

            invoiceGen.ReplaceInvoiceText(customer, employee, invoice);
            invoiceTable.InsertInvoiceTable();
        }

        public List<Invoice> GetInvoiceList()
        {
            DBController dbController = new DBController();
            return dbController.GetInvoiceList();
        }

        public void AddCustomer(string customerName, string customerAddress, string customerZipCity, string customerEmail, string customerPhone)
        {
            DBController dbController = new DBController();
            Customer customer = new Customer { CustomerName= customerName, CustomerAddress = customerAddress, CustomerZipCity = customerZipCity, CustomerEmail = customerEmail, CustomerPhone = customerPhone };
            dbController.AddCustomer(customer);
        }

        public List<Customer> GetCustomerList()
        {
            DBController dbController = new DBController();
            return dbController.GetCustomerList();
        }

        public void AddEmployee(string employeeName, string employeeAddress, string employeeZipCity, string employeeSeNum, string employeeAccountNum)
        {
            DBController dbController = new DBController();
            Employee employee = new Employee { EmployeeName = employeeName, EmployeeAddress = employeeAddress, EmployeeZipCity = employeeZipCity, EmployeeSeNum = employeeSeNum, EmployeeAccountNum = employeeAccountNum };
            dbController.AddEmployee(employee);
        }

        public List<Employee> GetEmployeeList()
        {
            DBController dbController = new DBController();
            return dbController.GetEmployeeList();
        }

        public void SaveFisheryRemuneration(double fishPrice, string fishType, double fishWeight, string saleDate, int customerID)
        {
            DBController dbController = new DBController();
            FisheryRemuneration fisheryRemuneration = new FisheryRemuneration { FishPrice = fishPrice, FishType = fishType, FishWeight = fishWeight, SaleDate = saleDate, CustomerID = customerID };
            dbController.SaveFisheryRemuneration(fisheryRemuneration);
        }

    }
}
