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
using System.Windows.Shapes;

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for UpdateAssignProject.xaml
    /// </summary>
    public partial class UpdateAssignProject : Window
    {
        private int GID;
        public UpdateAssignProject(int gid)
        {
            InitializeComponent();
            loadData();
            ProjectGrid.Loaded += Grid_Loaded;
            Datepicker.SelectedDate = DateTime.Now;
            GID = gid;
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
            loadProjects();
            loadMainAdvisors();
            loadCoAdvisors();
            loadIndustryAdvisors();
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
            if (validate())
            {
                try
                {
                    // Assign Project from selected vales 
                    DataRowView Prow = ProjectGrid.SelectedValue as DataRowView;
                    Group_Helper.AssignProject(GID, int.Parse(Prow.Row[0].ToString()), Datepicker.SelectedDate.Value);
                    // Assign Advisor to the Project Group
                    DataRowView madv = MainAdvGrid.SelectedValue as DataRowView;
                    //Advisor_Helper.AssignAdvisor(int.Parse(madv.Row[0].ToString()), int.Parse(Prow.Row[0].ToString()), 11, DateTime.Now);
                    DataRowView cadv = coAdvGrid.SelectedValue as DataRowView;
                    //Advisor_Helper.AssignAdvisor(int.Parse(cadv.Row[0].ToString()), int.Parse(Prow.Row[0].ToString()), 12, DateTime.Now);
                    DataRowView iadv = IndAdvGrid.SelectedValue as DataRowView;
                    //Advisor_Helper.AssignAdvisor(int.Parse(iadv.Row[0].ToString()), int.Parse(Prow.Row[0].ToString()), 14, DateTime.Now);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();

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
            searchCoAdvbox.Text = null;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            IndustryAdvSearchbox.Text = null;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool validate()
        {
            DataRowView row = ProjectGrid.SelectedValue as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please select a Value from Project Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            DataRowView madv = MainAdvGrid.SelectedValue as DataRowView;
            if (madv == null)
            {
                MessageBox.Show("Please select Main Advisor.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            DataRowView cadv = coAdvGrid.SelectedValue as DataRowView;
            if (cadv == null)
            {
                MessageBox.Show("Please select Co Advisor.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            DataRowView iadv = IndAdvGrid.SelectedValue as DataRowView;
            if (iadv == null)
            {
                MessageBox.Show("Please select Industry Advisor.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (madv.Row[0].ToString() == cadv.Row[0].ToString() || madv.Row[0].ToString() == iadv.Row[0].ToString())
            {
                MessageBox.Show("Two Advisors can not be same.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        
    }
}
