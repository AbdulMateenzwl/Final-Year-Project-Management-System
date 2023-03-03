using FYP_MS.HelperClasses;
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

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for AddGrp.xaml
    /// </summary>
    public partial class AddGrp : Window
    {
        public AddGrp()
        {
            InitializeComponent();
            loadData();
            AllStudents.Loaded += Grid_Loaded;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void loadData()
        {
            try
            {
                AllStudents.ItemsSource = Stu_Helper.getStudentNotInGroup(SearchBar.Text).DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Grid_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            AllStudents.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // data changes as text changes
            loadData();
            Grid_Loaded();
        }

        private void clearTxt_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";
        }
    }
}
