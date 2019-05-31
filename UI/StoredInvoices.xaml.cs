using ApplicationLayer;
using DomainLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for StoredInvoices.xaml
    /// </summary>
    public partial class StoredInvoices : Window
    {
        InvoiceRepo invoiceRepo = new InvoiceRepo();
        Controller controller = new Controller();

        public StoredInvoices()
        {
            InitializeComponent();
        }

        private void GetAllInvoice_Clicked(object sender, RoutedEventArgs e)
        {
            Lv.ItemsSource = controller.GetInvoiceList();

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InvoiceSearch.Text != "")
            {
                GetSpecificInvoice.IsEnabled = true;
            }
            else
            {
                GetSpecificInvoice.IsEnabled = false;
            }
        }

        private void GetSpecificInvoiced_Clicked(object sender, RoutedEventArgs e)
        {
            Lv.Items.Clear();
        }
        private void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowSelectedInvoice_Clicked(object sender, RoutedEventArgs e)
        {
            InvoiceGen invoice = new InvoiceGen();
            List<Invoice> invoices = controller.GetInvoiceList();
            Invoice[] invoicesarray = invoices.ToArray();
            int count = Lv.SelectedIndex;
            invoice.OpenDocx("", invoicesarray[count].Filepath);
        }
    }
}