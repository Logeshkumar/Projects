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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        ServiceReference1.IWcfService ServiceObj = new ServiceReference1.WcfServiceClient();
      
        public  Edit()
        {
            InitializeComponent();
           
            var list = ServiceObj.LoadBugId();
            foreach (var item in list)
            {
               comboBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.DataMembers obj = new ServiceReference1.DataMembers();
             obj.bugid = comboBox1.SelectedItem.ToString();
             obj.Worpackage =  textBox1.Text;
             obj.Title = textBox2.Text;
             obj.Date = Convert.ToDateTime(datePicker1.Text);
             obj.Text = textBox4.Text ;
             obj.Resolution = textBox5.Text ;
             ServiceObj.BugEditSave(obj);
             MessageBox.Show("Edited Succesfully");

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.DataMembers obj = new ServiceReference1.DataMembers();
                    string Id = comboBox1.SelectedItem.ToString();
                    obj = ServiceObj.BugEditing(Id);
                    textBox1.Text = obj.Worpackage;
                    textBox2.Text = obj.Title;
                   datePicker1.Text = obj.Date.ToString();
                    textBox4.Text = obj.Text;
                    textBox5.Text = obj.Resolution;
        } 
    }
}
