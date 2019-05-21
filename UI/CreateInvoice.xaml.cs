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
        }

        Controller control = new Controller();

        private List<string> customers;
        int LineItemCount = 0;

        double totalprice = 0;
        string numofHours = "";
        string description = "";
        string hourlySalary = "";
        string totalprice1 = "";

        private void NextButttonClicked(object sender, RoutedEventArgs e)
        {
            Controller controller = new Controller();
            InvoiceGen invoiceGen = new InvoiceGen();
            InvoiceTable invoiceTable = new InvoiceTable();
            CustomerRepo customerRepo = new CustomerRepo();
            Customer customer = new Customer();
            Invoice invoice = new Invoice();
            Employee employee = new Employee("Jørn Jensen", "Holbækvej 62", "4400 Kalundborg", "88888888", "5321 6666666666");

            customerRepo.UpdateCustomerList();

            int selectedIndex = Customer_names.SelectedIndex;
            string selectedItem = Customer_names.SelectedItem.ToString();

            customer = customerRepo.GetCustomerAtIndex(selectedIndex, selectedItem);
            if (customer == null)
            {
                MessageBox.Show("Fejl! 404 kunde not found");
            }

            invoice.InvoiceTitle = Title.Text;
            invoice.InvoiceNum = InvoiceNum.Text;
            invoice.InvoiceDate = InvoiceDate.Text;

            invoiceGen.ReplaceInvoiceText(customer, employee, invoice);
            invoiceTable.InsertInvoiceTable();
            DisableStepOne();
        }

        public void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        
        private void AddItemClicked(object sender, RoutedEventArgs e)
        {
            InvoiceTable invoiceTable = new InvoiceTable();

            totalprice += Convert.ToDouble(invoiceTable.AddInvoiceLine(Description.Text.ToString(), HourlySalary.Text, NumOfHours.Text));


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
            InvoiceGen invoiceGen = new InvoiceGen();
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
            //Customer customer = new Customer();
            //CustomerRepo customerRepo = new CustomerRepo();

            //int selectedIndex = Customer_names.SelectedIndex;
            //string selectedItem = Customer_names.SelectedItem.ToString();

            
            //customer = customerRepo.GetCustomerAtIndex(selectedIndex, selectedItem);
            //if(customer == null)
            //{
            //    MessageBox.Show("fuck niggers");
            //}
        }
    }
}
