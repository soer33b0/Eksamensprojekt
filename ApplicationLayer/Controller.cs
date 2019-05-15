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

        public void SaveInvoice(string invoiceDate, string invoiceNum, string invoiceTitle, double hoursWorked, double hourlySalary, double totalSalary, string desription)
        {
            Invoice invoice = new Invoice { InvoiceDate = invoiceDate, InvoiceNum = invoiceNum, InvoiceTitle = invoiceTitle, HoursWorked = hoursWorked, HourlySalary = hourlySalary, TotalSalary = totalSalary, Desription = desription };
            dbController.SaveInvoice(invoice);
        }

        public Invoice GetInvoice()
        {
            return dbController.GetInvoice();
        }

        public void AddCustomer(string customerName, string customerAddress, string customerZipCity, string customerEmail, string customerPhone)
        {
            Customer customer = new Customer { CustomerName= customerName, CustomerAddress = customerAddress, CustomerZipCity = customerZipCity, CustomerEmail = customerEmail, CustomerPhone = customerPhone };
            dbController.AddCustomer(customer);
        }

        public Customer GetCustomer()
        {
            return dbController.GetCustomer();
        }

        public void AddEmployee(string employeeName, string employeeAddress, string employeeZipCity, string employeeSeNum, string employeeAccountNum)
        {
            Employee employee = new Employee { EmployeeName = employeeName, EmployeeAddress = employeeAddress, EmployeeZipCity = employeeZipCity, EmployeeSeNum = employeeSeNum, EmployeeAccountNum = employeeAccountNum };
            dbController.AddEmployee(employee);
        }

        public Employee GetEmployee()
        {
            return dbController.GetEmployee();
        }

        public void SaveFisheryRemuneration(double fishPrice, string fishType, double fishWeight, string saleDate, int customerID)
        {
            FisheryRemuneration fisheryRemuneration = new FisheryRemuneration { FishPrice = fishPrice, FishType = fishType, FishWeight = fishWeight, SaleDate = saleDate, CustomerID = customerID };
            dbController.SaveFisheryRemuneration(fisheryRemuneration);
        }

    }
}
