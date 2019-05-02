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
            LineItemCount++;
            ItemCount.Content = LineItemCount;

            //metodekald indsæt kolonne

            //Description.Text = "";
            //NumOfHours.Text = "";
            //HourlySalary.Text = "";
            //MessageBox.Show("Punkt tilføjet!");

            InvoiceGen invoiceGen = new InvoiceGen();
            invoiceGen.OpenDocx(@"C:\Users\Søren\Desktop\Eksamensprojekt", @"\Fakturaskabelon.docx");

            Customer cust = new Customer("Hans", "hula bulla gade", "123@nej.dk", "33313215", "4412");
            Employee emp = new Employee("Jørn Jensen", "nejgade 42", "4000 odense Q", "12355578876", "6352 6125343124");
            Invoice inv = new Invoice("21-03-2018", 420, 220, 412534);

            invoiceGen.ReplaceInvoiceText(cust, emp, inv);

        }
    }
}
