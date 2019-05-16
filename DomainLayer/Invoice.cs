using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Invoice
    {
        public Invoice(string _invoiceDate, string _invoiceNum, string _invoiceTitle, string _hoursWorked, string _hourlySalary, string _desription, string _totalSalary)
        {
            InvoiceDate = _invoiceDate;
            InvoiceNum = _invoiceNum;
            InvoiceTitle = _invoiceTitle;
            HoursWorked = _hoursWorked;
            HourlySalary = _hourlySalary;
            Desription = _desription;
            TotalSalary = _totalSalary;
        }

        public Invoice() { }

        public string InvoiceDate
        {
            get;
            set;
        }

        public string InvoiceNum
        {
            get;
            set;
        }

        public string InvoiceTitle
        {
            get;
            set;
        }

        public string HoursWorked
        {
            get;
            set;
        }

        public string HourlySalary
        {
            get;
            set;
        }

        public double VAT //moms
        {
            get { return VAT; }
            set { VAT = 1.25; }
        }

        public string TotalSalary
        {
            get;
            set;
        }

        public string Desription
        {
            get; set;
        }
    }
}
