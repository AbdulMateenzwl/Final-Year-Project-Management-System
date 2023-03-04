using FYP_MS.HelperClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// Interaction logic for AssignProject.xaml
    /// </summary>
    public partial class AssignProject : UserControl
    {
        public AssignProject()
        {
            InitializeComponent();
            loadData();
            ProjectGrid.Loaded += Grid_Loaded;
            
        }
        private void Grid_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            try { ProjectGrid.Columns[0].Visibility = Visibility.Collapsed; } catch { }
            try { MainAdvGrid.Columns[0].Visibility = Visibility.Collapsed; } catch { }
            try { coAdvGrid.Columns[0].Visibility = Visibility.Collapsed; } catch { }
            try { IndAdvGrid.Columns[0].Visibility = Visibility.Collapsed; } catch { }
        }
        private void loadData()
        {
            loadGroups();
            loadProjects();
            loadMainAdvisors();
            loadCoAdvisors();
            loadIndustryAdvisors();
            Grid_Loaded();
        }
        private void loadGroups()
        {
            GroupGrid.ItemsSource = Group_Helper.getGroupsNotAssignedProject().DefaultView;
            Grid_Loaded();
        }
        private void loadProjects()
        {
            ProjectGrid.ItemsSource = Project_Helper.GetProjectNotAssigned(SearchBar.Text).DefaultView;
            Grid_Loaded();

        }
        private void loadMainAdvisors()
        {
            MainAdvGrid.ItemsSource = Advisor_Helper.GetAdvisors(searchMainAdvbox.Text).DefaultView;
            Grid_Loaded();

        }
        private void loadCoAdvisors()
        {
            coAdvGrid.ItemsSource = Advisor_Helper.GetAdvisors(searchCoAdvbox.Text).DefaultView;
            Grid_Loaded();

        }
        private void loadIndustryAdvisors()
        {
            IndAdvGrid.ItemsSource = Advisor_Helper.GetAdvisors(IndustryAdvSearchbox.Text).DefaultView;
            Grid_Loaded();

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadProjects();
            Grid_Loaded();

        }

        private void searchCoAdvbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadCoAdvisors();
            Grid_Loaded();

        }

        private void IndustryAdvSearchbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadIndustryAdvisors();
            Grid_Loaded();

        }

        private void searchMainAdvbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadMainAdvisors();
            Grid_Loaded();

        }

        private void AssignBtn_Click(object sender, RoutedEventArgs e)
        {
            // Assign Project from selected vales 
            DataRowView row = ProjectGrid.SelectedValue as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please select a Value from Project Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show(row.Row.ItemArray[1].ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            searchMainAdvbox.Text = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            searchCoAdvbox.Text=null;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            IndustryAdvSearchbox.Text= null;
        }

        private void UpdateProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
