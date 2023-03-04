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
    /// Interaction logic for GroupCRUD.xaml
    /// </summary>
    public partial class GroupCRUD : UserControl
    {
        public GroupCRUD()
        {
            InitializeComponent();
            loadData();
            //Grid.Loaded += Grid_Loaded;
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            AddGrp addGrp = new AddGrp();
            addGrp.ShowDialog();
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
            //Grid.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // data changes as text changes
            loadData();
            Grid_Loaded();
        }

    }
}
