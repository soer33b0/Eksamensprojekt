using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        Employee employee = new Employee("");

        public string Date
        {
            get;
            set;
        }

        public double HoursWorked
        {
            get;
            set;
        }

        public double HourlySalary
        {
            get;
            set;
        }

        public double VAT //moms
        {
            get;
            set;
        }

        public double TotalSalary
        {
            get;
            set;
        }

        public Invoice(string _date, int _hoursWorked, double _hourlySalary, double _VAT, double _totalSalary)
        {
            Date = _date;
            HoursWorked = _hoursWorked;
            HourlySalary = _hourlySalary;
            VAT = _VAT;
            TotalSalary = _totalSalary;
        }
    }
}
