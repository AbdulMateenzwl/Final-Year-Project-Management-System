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
    /// Interaction logic for ProjectCRUD.xaml
    /// </summary>
    public partial class ProjectCRUD : UserControl
    {
        public ProjectCRUD()
        {
            InitializeComponent();
            Grid.Loaded += Grid_Loaded;
            loadData();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            AddProject addpr = new AddProject();
            addpr.ShowDialog();
            loadData();
            Grid_Loaded();
        }

        private void UpdateProject_Click(object sender, RoutedEventArgs e)
        {
            // Update Project with values
            DataRowView row = Grid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a value from Table", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    UpdateProject up = new UpdateProject(int.Parse(row.Row[0].ToString()), row.Row[1].ToString(), row.Row[2].ToString());
                    up.ShowDialog();
                    loadData();
                    Grid_Loaded();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            
        }

        private void loadData()
        {
            Grid.ItemsSource = Project_Helper.Search(SearchBar.Text).DefaultView;
        }
        private void Grid_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            Grid.Columns[0].Visibility = Visibility.Collapsed;
            Grid.Columns[1].Width = 90;
            Grid.RowHeight = 50;

        }
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // data changes as text changes
            loadData();
            Grid_Loaded();
        }
    }
}
