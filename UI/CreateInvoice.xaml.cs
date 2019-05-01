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
    /// Interaction logic for CreateInvoice.xaml
    /// </summary>
    public partial class CreateInvoice : Window
    {
        int LineItemCount = 0;
        public CreateInvoice()
        {
            InitializeComponent();
        }

        private void AddItemClicked(object sender, RoutedEventArgs e)
        {
            LineItemCount++;
            ItemCount.Content = LineItemCount;
            
            
            
            

        }
    }
}
