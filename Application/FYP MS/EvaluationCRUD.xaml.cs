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
    /// Interaction logic for EvaluationCRUD.xaml
    /// </summary>
    public partial class EvaluationCRUD : UserControl
    {
        public EvaluationCRUD()
        {
            InitializeComponent();
            loadData();
            Grid.Loaded += Grid_Loaded;
        }


        private void clearTxt_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";
        }

        private void loadData()
        {
            Grid.ItemsSource = Evaluation_Helper.GetEvaluations(SearchBar.Text).DefaultView;
        }

        private void AddEvlBtn(object sender, RoutedEventArgs e)
        {
            AddEvaluation addEvaluation = new AddEvaluation();
            addEvaluation.ShowDialog();
            loadData();
            Grid_Loaded();
        }
        private void Grid_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            Grid.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // data changes as text changes
            loadData();
            Grid_Loaded();
        }

        private void UpdateEvlBtnClick(object sender, RoutedEventArgs e)
        {
            // if selected row is not null
            DataRowView row = Grid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a value from Table", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    UpdateEvaluation updateEvaluation = new UpdateEvaluation(row.Row.ItemArray[1].ToString(),int.Parse(row.Row.ItemArray[2].ToString()),int.Parse(row.Row.ItemArray[3].ToString()),int.Parse(row.Row.ItemArray[0].ToString()));
                    updateEvaluation.ShowDialog();
                    loadData();
                    Grid_Loaded();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
