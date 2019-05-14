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
using ApplicationLayer;
using DomainLayer;
using Xceed.Words.NET;


namespace UI
{
    /// <summary>
    /// Interaction logic for CreateInvoice2.xaml
    /// </summary>
    public partial class CreateInvoice2 : Page
    {
        int LineItemCount = 0;
        double totalprice = 0;
        public CreateInvoice2()
        {
            InitializeComponent();
        }

        private void AddItemClicked(object sender, RoutedEventArgs e)
        {
            InvoiceAdd invoiceAdd = new InvoiceAdd();


            totalprice += Convert.ToDouble(invoiceAdd.AddInvoiceLine(Description.Text.ToString(), HourlySalary.Text, NumOfHours.Text));

            LineItemCount++;
            ItemCount.Content = LineItemCount;

            Description.Text = "";
            NumOfHours.Text = "";
            HourlySalary.Text = "";
        }

        private void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            InvoiceGen invoiveGen = new InvoiceGen();
            invoiveGen.InvSave(totalprice);

            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
