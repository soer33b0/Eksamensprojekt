using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Employee
    {
        public string EmployeeName
        {
            get;
            set;
        }

        public string EmployeeAddress
        {
            get;
            set;
        }

        public string EmployeeZipCity
        {
            get;
            set;
        }

        public string EmployeeSeNumber
        {
            get;
            set;
        }
        public string EmployeeAccountNumber
        {
            get;
            set;
        }

        public Employee(string _employeeName, string _employeeAddress, string _employeeZipCity, string _employeeSeNumber, string _employeeAccountNumber)
        {
            EmployeeName = _employeeName;
            EmployeeAddress = _employeeAddress;
            EmployeeZipCity = _employeeZipCity;
            EmployeeSeNumber = _employeeSeNumber;
            EmployeeAccountNumber = _employeeAccountNumber;
        }
    }
}
