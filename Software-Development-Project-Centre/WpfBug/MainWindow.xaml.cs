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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfBug.ServiceReference1;
using System.Collections;

namespace WpfBug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceReference1.IWcfService ServiceObj = new ServiceReference1.WcfServiceClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.DataMembers obj = new ServiceReference1.DataMembers();
            obj.Worpackage = textBox1.Text;
            obj.Title = textBox2.Text;
            obj.Date = Convert.ToDateTime(datePicker1.Text);
            obj.Text = textBox3.Text;
            obj.Resolution = textBox4.Text;
            ServiceObj.CreateBug(obj);
            

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Edit EditWindow = new Edit();
            EditWindow.Show();
        }
    }
}
