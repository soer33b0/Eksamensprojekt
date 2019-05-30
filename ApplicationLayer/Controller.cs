using DomainLayer;
using System.Collections.Generic;

namespace ApplicationLayer
{
    public class Controller
    {

        DBController Dbcontroller = new DBController();
        public bool SaveInvoice(string invoiceDate, int invoiceNum, string invoiceTitle, string hoursWorked, string hourlySalary, double totalSalary, string description, string filepath, int count)
        {
            Invoice invoice = new Invoice
            {
                InvoiceDate = invoiceDate,
                InvoiceNum = invoiceNum,
                InvoiceTitle = invoiceTitle,
                HoursWorked = hoursWorked,
                HourlySalary = hourlySalary,
                TotalWithoutVAT = totalSalary,
                Description = description,
                Filepath = filepath,
                Count = count
            };
            if (Dbcontroller.SaveInvoice(invoice) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Invoice> GetInvoiceList()
        {
            return Dbcontroller.GetInvoiceList();
        }

        public string[] GetCustomerNames()
        {

            return Dbcontroller.GetCustomerNames();
        }

        public void AddCustomer(string customerName, string customerAddress, string customerZipCity, string customerEmail, string customerPhone)
        {
            Customer customer = new Customer
            {
                CustomerName = customerName,
                CustomerAddress = customerAddress,
                CustomerZipCity = customerZipCity,
                CustomerEmail = customerEmail,
                CustomerPhone = customerPhone
            };
            Dbcontroller.AddCustomer(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return Dbcontroller.GetCustomerList();
        }

        public void AddEmployee(string employeeName, string employeeAddress, string employeeZipCity, string employeeSeNum, string employeeAccountNum)
        {
            Employee employee = new Employee
            {
                EmployeeName = employeeName,
                EmployeeAddress = employeeAddress,
                EmployeeZipCity = employeeZipCity,
                EmployeeSeNum = employeeSeNum,
                EmployeeAccountNum = employeeAccountNum
            };
            Dbcontroller.AddEmployee(employee);
        }

        public List<Employee> GetEmployeeList()
        {
            return Dbcontroller.GetEmployeeList();
        }

        public void SaveFisheryRemuneration(double fishPrice, string fishType, double fishWeight, string saleDate, int customerID)
        {
            FisheryRemuneration fisheryRemuneration = new FisheryRemuneration
            {
                FishPrice = fishPrice,
                FishType = fishType,
                FishWeight = fishWeight,
                SaleDate = saleDate,
                CustomerID = customerID
            };
            Dbcontroller.SaveFisheryRemuneration(fisheryRemuneration);
        }

    }
}