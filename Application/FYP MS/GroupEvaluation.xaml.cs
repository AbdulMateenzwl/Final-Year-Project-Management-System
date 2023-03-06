using FYP_MS.HelperClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
    /// Interaction logic for GroupEvaluation.xaml
    /// </summary>
    public partial class GroupEvaluation : UserControl
    {
        public GroupEvaluation()
        {
            InitializeComponent();
            EvaluationNamecmbox.ItemsSource = Evaluation_Helper.getEvaluationName();
            EvaluationNamecmbox.SelectedIndex = 0;
            loadUnEvaluatedGroup();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Load Evaluated and unEvaluated Groups with the same name

        }

        private void clearTxt_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = null;
        }

        private void EvaluationNamecmbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Load Groups with specific Evaluation
            loadUnEvaluatedGroup();
            loadEvaluatedGroup();
        }
        private void loadUnEvaluatedGroup()
        {
            UnEvlGroupGrid.ItemsSource = Group_Helper.GetUnEvaluated(EvaluationNamecmbox.SelectedValue.ToString()).DefaultView;
        }
        private void loadEvaluatedGroup()
        {
            EvlGroupGrid.ItemsSource = Group_Helper.GetEvaluated(EvaluationNamecmbox.SelectedValue.ToString()).DefaultView;
        }

        private void EvalateGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EvalateGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = EvlGroupGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a Group from UnEvaluated Groups Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    // Evaluate Group Window
                    loadEvaluatedGroup();
                    loadUnEvaluatedGroup();
                    GroupMembersGrid.ItemsSource = null;
                    EvaluationsDetailsGrid.ItemsSource = null;
                    //Grid_Loaded();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void UpdateEvlBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = EvlGroupGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a Group from UnEvaluated Groups Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    // Edit the Evaluation Details Window
                    loadEvaluatedGroup();
                    loadUnEvaluatedGroup();
                    GroupMembersGrid.ItemsSource = null;
                    EvaluationsDetailsGrid.ItemsSource = null;
                    //Grid_Loaded();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void UnEvlGroupGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            MessageBox.Show("clicked");

            DataRowView row = UnEvlGroupGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a Group from UnEvaluated Groups Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    GroupMembersGrid.ItemsSource = Group_Helper.GetStuFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
