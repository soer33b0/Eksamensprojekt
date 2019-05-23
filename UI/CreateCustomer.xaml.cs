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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationLayer;
using DomainLayer;

namespace UI
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Page
    {
        public CreateCustomer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Controller controller = new Controller();
            if (string.IsNullOrWhiteSpace(customerName.Text) || string.IsNullOrWhiteSpace(customerAddress.Text) || string.IsNullOrWhiteSpace(customerZipCity.Text) || string.IsNullOrWhiteSpace(customerEmail.Text) || string.IsNullOrWhiteSpace(customerPhone.Text))
            {
                MessageBox.Show("fuck niggers");
            }
            else
            {
                if (MessageBox.Show("Vil du gemme denne kunde?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    controller.AddCustomer(customerName.Text, customerAddress.Text, customerZipCity.Text, customerEmail.Text, customerPhone.Text);
                    MessageBox.Show("Kunden blev gemt.");
                    ResetTextboxes();
                }
            }
        }
        private void ResetTextboxes()
        {
            
            customerName.Text = "";
            customerAddress.Text = "";
            customerZipCity.Text = "";
            customerEmail.Text = "";
            customerPhone.Text = "";
            customerName.Focus();
        }

        private void CloseProgram(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResetTextboxes();
        }
    }
}
