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
    /// Interaction logic for AssignProjectCRUD.xaml
    /// </summary>
    public partial class AssignProjectCRUD : UserControl
    {
        public AssignProjectCRUD()
        {
            InitializeComponent();
            loadData();

        }
        private void loadData()
        {
            try
            {
                Grid.ItemsSource = Project_Helper.GetAssignedProjectDetails(SearchBar.Text).DefaultView;
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
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // data changes as text changes
            loadData();
        }

        private void UpdateProjectDetail(object sender, RoutedEventArgs e)
        {
            // Update Group Project Details
        }
        private void AssignProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            AddAssignProject assignProject = new AddAssignProject();
            assignProject.ShowDialog();
            loadData();
        }
    }
}
