using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WpfBug
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        ServiceReference1.IWcfService ServiceObj = new ServiceReference1.WcfServiceClient();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            bool loginid = ServiceObj.IsUserValid(textBox1.Text, passwordBox1.Password);
            if (loginid == true)
            {
                MainWindow form = new MainWindow();
                form.Show();
            }
            else
            {
                MessageBox.Show("Enter Proper User Credentials");
            }
                }
            catch(Exception)
            {
                MessageBox.Show("Enter Proper User Credentials");
            }
        }
    }
}
