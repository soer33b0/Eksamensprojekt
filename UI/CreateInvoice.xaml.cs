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

            Customer_names.ItemsSource = control.GetCustomerNames();
            invoiceTable.InsertInvoiceTable();
            customerRepo.UpdateCustomerList();
        }

        Controller control = new Controller();
        InvoiceTable invoiceTable = new InvoiceTable();
        InvoiceGen invoiceGen = new InvoiceGen();
        CustomerRepo customerRepo = new CustomerRepo();
        Customer customer = new Customer();
        Invoice invoice = new Invoice();
        Employee employee = new Employee("Jørn Jensen", "Holbækvej 62", "4400 Kalundborg", "88888888", "5321 6666666666");

        int LineItemCount = 0;

        double totalprice = 0;
        string numofHours = "";
        string description = "";
        string hourlySalary = "";
        string totalprice1 = "";

        private void NextButttonClicked(object sender, RoutedEventArgs e)
        {
            if (customer == null)
            {
                MessageBox.Show("Error 404 \nkunde not found");
            }

            invoice.InvoiceTitle = Title.Text;
            invoice.InvoiceNum = InvoiceNum.Text;
            invoice.InvoiceDate = InvoiceDate.Text;

            

            DisableStepOne();
        }

        public void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        
        private void AddItemClicked(object sender, RoutedEventArgs e)
        {
            

            totalprice += Convert.ToDouble(HourlySalary.Text) * Convert.ToDouble(NumOfHours.Text);

            numofHours += NumOfHours.Text + ",";
            hourlySalary += HourlySalary.Text + ",";
            description += Description.Text + ",";
            totalprice1 += totalprice.ToString() + ",";

            LineItemCount++;
            ItemCount.Content = LineItemCount;
            Description.Text = "";
            NumOfHours.Text = "";
            HourlySalary.Text = "";
        }
        private void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            invoiceGen.ReplaceInvoiceText(customer, employee, invoice);


            invoiceGen.InvoiceCalc(totalprice);
            

            //control.SaveInvoice("");

            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        public void DisableStepOne()
        {
            Customer_names.IsEnabled = false;
            Title.IsEnabled = false;
            InvoiceDate.IsEnabled = false;
            InvoiceNum.IsEnabled = false;
            Next.IsEnabled = false;

            Description.IsEnabled = true;
            NumOfHours.IsEnabled = true;
            HourlySalary.IsEnabled = true;
            AddItem.IsEnabled = true;
            OpenInvoice.IsEnabled = true;
            Close.IsEnabled = true;
        }

        private void Customer_names_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = Customer_names.SelectedIndex;
            string selectedItem = Customer_names.SelectedItem.ToString();

            customer = customerRepo.GetCustomerAtIndex(selectedIndex, selectedItem);
        }
    }
}
