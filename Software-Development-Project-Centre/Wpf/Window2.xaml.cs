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

namespace Wpf
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        ServiceReference1.IWcfService ServiceObj = new ServiceReference1.WcfServiceClient();
        public Window2()
        {
            InitializeComponent();
            List<ServiceReference1.DataMembers> list = new List<ServiceReference1.DataMembers>();
            list = ServiceObj.LoadStatusId().ToList();
            foreach (var item in list)
            {
                comboBox1.Items.Add(item.Id);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

  
            MessageBox.Show("Are you Sure, You wanna Delete");

            ServiceReference1.DataMembers obj = new ServiceReference1.DataMembers();
            int Id = Convert.ToInt32(comboBox1.SelectedItem);
            ServiceObj.Delete(Id);
            MessageBox.Show("Deleted");
        }
    }
}
