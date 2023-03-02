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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for AdvisorMenu.xaml
    /// </summary>
    public partial class AdvisorMenu : UserControl
    {
        public AdvisorMenu()
        {
            InitializeComponent();
            loadData();
            Grid.Loaded += Grid_Loaded;
        }
        private void loadData()
        {
            try
            {
                //Grid.ItemsSource = Stu_Helper.GetStudentTableDetails().DefaultView;
                Grid.ItemsSource = Advisor_Helper.Search(SearchBar.Text).DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading data from Database " + e, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Grid_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            Grid.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddAdv addAdv = new AddAdv();
            addAdv.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddAdv addAdv = new AddAdv();
            addAdv.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddAdv addStu = new AddAdv();
            addStu.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddAdv addStu = new AddAdv();
            addStu.ShowDialog();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // data changes as text changes
            loadData();
            Grid_Loaded();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void clearTxt_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";

        }

        private void Grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
