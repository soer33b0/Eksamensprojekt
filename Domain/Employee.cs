using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        public string EmployeeName
        {
            get { return EmployeeName; }
            set { EmployeeName = value; }
        }

        public string EmployeeAddress
        {
            get { return EmployeeAddress; }
            set { EmployeeAddress = value; }
        }

        public string EmployeeZipCode
        {
            get { return EmployeeZipCode; }
            set { EmployeeZipCode = value; }
        }

        public string EmployeeCity
        {
            get { return EmployeeCity; }
            set { EmployeeCity = value; }
        }

        public string EmployeeSeNumber
        {
            get { return EmployeeSeNumber; }
            set { EmployeeSeNumber = value; }
        }
        public string EmployeeAccountNumber
        {
            get { return EmployeeAccountNumber; }
            set { EmployeeAccountNumber = value; }
        }

        public Employee(string _employeeName, string _employeeAddress, string _employeeZipCode, string _employeeCity, string _employeeSeNumber, string _employeeAccountNumber)
        {
            EmployeeName = _employeeName;
            EmployeeAddress = _employeeAddress;
            EmployeeZipCode = _employeeZipCode;
            EmployeeCity = _employeeCity;
            EmployeeSeNumber = _employeeSeNumber;
            EmployeeAccountNumber = _employeeAccountNumber;
        }
    }
}
