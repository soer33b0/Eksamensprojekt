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

        public string EmployeeSeNum
        {
            get;
            set;
        }
        public string EmployeeAccountNum
        {
            get;
            set;
        }

        public Employee(string _employeeName, string _employeeAddress, string _employeeZipCity, string _employeeSeNum, string _employeeAccountNum)
        {
            EmployeeName = _employeeName;
            EmployeeAddress = _employeeAddress;
            EmployeeZipCity = _employeeZipCity;
            EmployeeSeNum = _employeeSeNum;
            EmployeeAccountNum = _employeeAccountNum;
        }
    }
}
