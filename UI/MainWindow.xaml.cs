﻿using System.Windows;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateInvoice createInvoice = new CreateInvoice();
            createInvoice.Show();
        }

        private void CloseProgram(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Management management = new Management();
            management.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StoredInvoices storedInvoices = new StoredInvoices();
            storedInvoices.Show();
        }
    }
}
