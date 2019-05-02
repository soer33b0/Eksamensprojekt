using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            

            Description.Text = "";
            NumOfHours.Text = "";
            HourlySalary.Text = "";
        }
    }
}
