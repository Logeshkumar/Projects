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
using Wpf.ServiceReference1;
using System.Collections;


namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         ServiceReference1.IWcfService ServiceObj = new ServiceReference1.WcfServiceClient();
             List<ServiceReference1.DataMembers> list = new List<ServiceReference1.DataMembers>();


        public MainWindow()
        {
            InitializeComponent();
           
           
           
            list = ServiceObj.LoadWorkPackId().ToList();
            foreach (var item1 in list)
            {
                comboBox1.Items.Add(item1.Id);
            }
        }
        
        

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ServiceReference1.DataMembers obj = new ServiceReference1.DataMembers();
                obj.Date = Convert.ToDateTime(datePicker1.Text);
                obj.Title = textBox2.Text;
                obj.Text = textBox4.Text;
                obj.WorkPacId = Convert.ToInt32(comboBox1.SelectedItem);
                bool g = ServiceObj.Create(obj);
                if (g == true)
                {
                    MessageBox.Show("Succesfull");
                }
                else
                {
                    MessageBox.Show("Cannot Create... Please Enter Proper Data");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot Create... Please Enter Proper Data");

            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window1 EditWindow = new Window1();
            EditWindow.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Window2 DeleteWindow = new Window2();
            DeleteWindow.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            


        }

      

      
    }
}
