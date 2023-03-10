using FYP_MS.HelperClasses;
using System;
using System.Collections.Generic;
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

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for GroupCRUD.xaml
    /// </summary>
    public partial class GroupCRUD : UserControl
    {
        public GroupCRUD()
        {
            InitializeComponent();
            loadData();
            Grid.Loaded += Grid_Loaded;
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            AddGrp addGrp = new AddGrp();
            addGrp.ShowDialog();
            loadData();
            
        }
        private void loadData()
        {
            try
            {
                Grid.ItemsSource = Group_Helper.getGroupDetails().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }   
        private void clearTxt_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";
        }
        private void Grid_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            // try { Grid.Columns[0].Visibility = Visibility.Collapsed; } catch { }
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // data changes as text changes
            if (SearchBar.Text == "")
            {
                loadData();
            }
            else if (int.TryParse(SearchBar.Text.ToString(),out int indd))
            {
                Grid.ItemsSource = Group_Helper.SearchGroup(int.Parse(SearchBar.Text.ToString())).DefaultView;
            }
        }

        private void Grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = Grid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a value from Table", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    //  Get the selected group table from database
                    StudentsGrid.ItemsSource = Group_Helper.GetStuFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                    StudentsGrid.Columns[0].Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Getting Data from Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
