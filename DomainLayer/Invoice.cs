﻿namespace DomainLayer
{
    public class Invoice
    {
        public Invoice(string _customerName, string _invoiceDate, int _invoiceNum, string _invoiceTitle, string _hoursWorked, string _hourlySalary, string _description, double _totalWithoutVAT, string _filepath, int _count)
        {
            CustomerName = _customerName;
            InvoiceDate = _invoiceDate;
            InvoiceNum = _invoiceNum;
            InvoiceTitle = _invoiceTitle;
            HoursWorked = _hoursWorked;
            HourlySalary = _hourlySalary;
            Description = _description;
            TotalWithoutVAT = _totalWithoutVAT;
            Filepath = _filepath;
            Count = _count;
        }

        public Invoice() { }

        public string CustomerName { get; set; }

        public string InvoiceDate { get; set; }

        public int InvoiceNum { get; set; }

        public string InvoiceTitle { get; set; }

        public string HoursWorked { get; set; }

        public string HourlySalary { get; set; }

        public double TotalWithoutVAT { get; set; }

        public string Description { get; set; }
        public string Filepath { get; set; }
        public int Count { get; set; }
    }
}