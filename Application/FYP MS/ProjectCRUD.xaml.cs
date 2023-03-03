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
        }

        private void UpdateProject_Click(object sender, RoutedEventArgs e)
        {
            // Update Project with values

        }

        private void loadData()
        {
            Grid.ItemsSource = Project_Helper.Search(SearchBar.Text).DefaultView;
        }
        private void Grid_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            Grid.Columns[0].Visibility = Visibility.Collapsed;
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
