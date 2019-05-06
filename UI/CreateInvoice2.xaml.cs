using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DomainLayer;

namespace UI
{
    /// <summary>
    /// Interaction logic for CreateInvoice2.xaml
    /// </summary>
    public partial class CreateInvoice2 : Page
    {
        int LineItemCount = 0;
        public CreateInvoice2()
        {
            InitializeComponent();
        }

        private void AddItemClicked(object sender, RoutedEventArgs e)
        {
            InvoiceGen invoiceGen = new InvoiceGen();

            LineItemCount++;
            ItemCount.Content = LineItemCount;

            //metodekald indsæt kolonne

            //Description.Text = "";
            //NumOfHours.Text = "";
            //HourlySalary.Text = "";
            //MessageBox.Show("Punkt tilføjet!");

        }

        private void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            InvoiceGen invoiceGen = new InvoiceGen();
            invoiceGen.OpenDocx(@"C:\Users\Søren\Desktop\Eksamensprojekt", @"\Fakturaskabelon.docx");

            Customer cust = new Customer();
            Employee emp = new Employee();
            Invoice inv = new Invoice();

            invoiceGen.ReplaceInvoiceText(cust, emp, inv);

            invoiceGen.InsertInvoiceTable();
        }
    }
}
