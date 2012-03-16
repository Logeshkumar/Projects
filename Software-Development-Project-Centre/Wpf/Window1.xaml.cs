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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ServiceReference1.IWcfService ServiceObj = new ServiceReference1.WcfServiceClient();
        ServiceReference1.DataMembers obj = new ServiceReference1.DataMembers();
        public Window1()
        {
            InitializeComponent();
            List<ServiceReference1.DataMembers> list = new List<ServiceReference1.DataMembers>();
            List<ServiceReference1.DataMembers> list1 = new List<ServiceReference1.DataMembers>();
            list = ServiceObj.LoadStatusId().ToList();
            list1 = ServiceObj.LoadWorkPackId().ToList();
            foreach (var item in list)
            {
                comboBox1.Items.Add(item.Id);
            }
            foreach (var item1 in list1)
            {
                comboBox2.Items.Add(item1.Id);
            }
        }
       
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            int Id = Convert.ToInt32(comboBox1.SelectedItem);
            obj = ServiceObj.Edit(Id);
            {
                textBox2.Text = obj.Title;
                textBox3.Text = Convert.ToString(obj.Date.ToShortDateString());
                textBox4.Text = obj.Text;
               comboBox2.SelectedItem = Convert.ToString(obj.WorkPacId);
              


            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
        //    ServiceReference1.DataMembers obj = new ServiceReference1.DataMembers();
            obj.Id = Convert.ToInt32(comboBox1.SelectedItem);
            obj.Title = textBox2.Text;
            obj.Date = DateTime.Parse(textBox3.Text);
            obj.Text = textBox4.Text;
            obj.WorkPacId = Convert.ToInt32(comboBox2.SelectedItem);
            ServiceObj.saveEdit(obj);
            MessageBox.Show("Edit action done succesfully");
        }
    }
}


