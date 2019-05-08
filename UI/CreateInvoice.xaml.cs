using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ApplicationLayer;
using DomainLayer;
using UI;

namespace UI
{
    /// <summary>
    /// Interaction logic for CreateInvoice.xaml
    /// </summary>
    public partial class CreateInvoice : Window
    {
        public CreateInvoice()
        {
            InitializeComponent();
        }

        private void NextButttonClicked(object sender, RoutedEventArgs e)
        {
            CreateInvoice2 createInvoice2 = new CreateInvoice2();
            this.Content = createInvoice2;

            InvoiceGen invoiceGen = new InvoiceGen();
            Customer cust = new Customer("Smedegården Hans Jørgen ApS", "vollsmose 4", "Jørgenleth@nej.uk.dk.usa.gov", "44411231", "5000 Odense C");
            Employee emp = new Employee("Jørn Jensen", "Jørnvej 420", "3299 århus F", "44155523564", "5321 66666661661");
            Invoice inv = new Invoice("22-01-2013", "63", "Uge 42 - 52", 41, 4441);

            invoiceGen.ReplaceInvoiceText(cust, emp, inv);
            invoiceGen.InsertInvoiceTable();
            
        }
    }
}
