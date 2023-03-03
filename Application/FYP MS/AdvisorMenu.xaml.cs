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
                // changes as text changes in the textbox
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

        private void AddAvisorBtn(object sender, RoutedEventArgs e)
        {
            // Add New Student
            AddAdv addStu = new AddAdv();
            addStu.ShowDialog();
            loadData();
            Grid_Loaded();
        }

        private void UpdateAdvBtnClick(object sender, RoutedEventArgs e)
        {
            // Edit Advisor Menu with values given from the selected column
            DataRowView row = Grid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a value from Table", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Passing value to the next form to update them
                try
                {
                    updateAdv ustu = new updateAdv(row.Row.ItemArray[1].ToString(), row.Row.ItemArray[2].ToString(), row.Row.ItemArray[3].ToString(), int.Parse(row.Row.ItemArray[4].ToString()), row.Row.ItemArray[5].ToString(), (row.Row.ItemArray[6].ToString()), (DateTime)row.Row.ItemArray[7], (row.Row.ItemArray[8].ToString()), (int)row.Row.ItemArray[0]);
                    ustu.ShowDialog();
                    loadData();
                    Grid_Loaded();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("There is an error while getting value from table. "+ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
