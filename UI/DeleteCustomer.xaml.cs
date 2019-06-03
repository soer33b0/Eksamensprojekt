using ApplicationLayer;
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
    /// Interaction logic for DeleteCustomer.xaml
    /// </summary>
    public partial class DeleteCustomer : Window
    {

        Controller control = new Controller();
        public DeleteCustomer()
        {
            InitializeComponent();

            CustomerBox.ItemsSource = control.GetCustomerNames();
        }
        public void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string value = CustomerBox.SelectedValue.ToString();
            if (control.DeleteCustomer(value) == true)
            {
                MessageBox.Show("Kunde blev slettet.");
                CustomerBox.ItemsSource = control.GetCustomerNames();
            }
            else
            {
                MessageBox.Show("Kunde kunne ikke slettes.");
            }
        }
    }
}
