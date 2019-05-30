using ApplicationLayer;
using DomainLayer;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void NextButttonClicked(object sender, RoutedEventArgs e)
        {
            if (customer == null)
            {
                MessageBox.Show("Error 404 \nkunde not found");
            }

            invoice.InvoiceTitle = Title.Text;
            invoice.InvoiceNum = Convert.ToInt32(InvoiceNum.Text);
            invoice.InvoiceDate = InvoiceDate.Text;

            

            DisableStepOne();
        }

        public void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        
        private void AddItemClicked(object sender, RoutedEventArgs e)
        {
            invoiceTable.AddInvoiceLine(Description.Text, HourlySalary.Text, NumOfHours.Text);

            invoice.HoursWorked += NumOfHours.Text + ",";
            invoice.HourlySalary += HourlySalary.Text + ",";
            invoice.Description += Description.Text + ",";

            invoice.TotalWithoutVAT += Convert.ToDouble(NumOfHours.Text) * Convert.ToDouble(HourlySalary.Text);

            LineItemCount++;
            ItemCount.Content = LineItemCount;
            Description.Text = "";
            NumOfHours.Text = "";
            HourlySalary.Text = "";
        }
        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            invoiceGen.ReplaceInvoiceText(customer, employee, invoice);
            invoice.Filepath = invoiceGen.InvoiceCalc(invoice);

            int count = Customer_names.SelectedIndex;
            control.SaveInvoice(invoice.InvoiceDate, invoice.InvoiceNum, invoice.InvoiceTitle, invoice.HoursWorked, invoice.HourlySalary , invoice.TotalWithoutVAT, invoice.Description, invoice.Filepath, count);

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
