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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for Gemte_Fakturaer.xaml
    /// </summary>
    public partial class Gemte_Fakturaer : Page
    {
        public Gemte_Fakturaer()
        {
            InitializeComponent();
        }
        //public void UpdatePictures(InvoiceRepo invoiceRepo)
        //{
            
        //    foreach (Invoice invoice in invoiceRepo.invoices)
        //    {


        //        RadioButton radioBtn = new RadioButton
        //        {
        //            Margin = new Thickness(2, 10, 2, 10),
        //            Height = 100,
        //            HorizontalAlignment = HorizontalAlignment.Center,
        //            VerticalAlignment = VerticalAlignment.Top,
        //            Content = new Image { Source = new BitmapImage(new Uri(picture.PictureLink, UriKind.Relative)) },
        //            Name = "_" + picture.PictureNumber.ToString(),



        //        };
        //        radioBtn.Checked += this.Radio_Checked;
        //        WP_mainWrapPanel.Children.Add(radioBtn);


        //    }
        //}
    }
}
