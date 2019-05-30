using ApplicationLayer;
using DomainLayer;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lv.ItemsSource = controller.GetInvoiceList();
            Show.IsEnabled = true;

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Lv.Items.Clear();
        }
        private void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            
            InvoiceGen invoice = new InvoiceGen();
            List<DomainLayer.Invoice> meme = controller.GetInvoiceList();
            Invoice[] meme1 = meme.ToArray();
            int count = Lv.SelectedIndex;
            invoice.OpenDocxFromShow(meme1[count].Filepath);
        }
    }
}
