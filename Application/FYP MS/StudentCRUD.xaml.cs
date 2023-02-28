using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Markup;

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for StudentCRUD.xaml
    /// </summary>
    /// 
    public class data
    {
        public int time;
        public int date;
        public int year;
        public data(int time, int date, int year)
        {
            this.time = time;
            this.date = date;
            this.year = year;
        }
    }
    public partial class StudentCRUD : UserControl
    {
        public StudentCRUD()
        {
            InitializeComponent();
            loadData();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStu addStu = new AddStu();
            addStu.ShowDialog();
            
        }
        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            /*AddStu addStu = new AddStu(true);
            addStu.ShowDialog();*/
            DataRowView row = Grid.SelectedItem as DataRowView;
            if(row==null)
            {
                MessageBox.Show("Please Select a value from Table", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show(row.Row.ItemArray[1].ToString());
            }
        }
        private void loadData()
        {
            Grid.ItemsSource = Person_Helper.GetFullTable().DefaultView;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Open add user form with values from the table
        }

        private void clearTxt_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";
        }
    }
}
