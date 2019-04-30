using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Invoice
    {
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
            get { return VAT; }
            set { VAT = 1.25; }
        }

        public double TotalSalary
        {
            get;
            set;
        }

        public Invoice(string _date, int _hoursWorked, double _hourlySalary, double _totalSalary)
        {
            Date = _date;
            HoursWorked = _hoursWorked;
            HourlySalary = _hourlySalary;
            TotalSalary = _totalSalary;
        }
    }
}
