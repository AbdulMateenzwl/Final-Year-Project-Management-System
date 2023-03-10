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
            loadEvaluatedGroup();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Load Evaluated and unEvaluated Groups with the same name
            loadUnEvaluatedGroup();
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
            EvaluationsDetailsGrid.ItemsSource = null;
            GroupMembersGrid.ItemsSource = null;
        }
        private void loadUnEvaluatedGroup()
        {
            try
            {
                if (EvaluationNamecmbox.ItemsSource != null)
                {
                    if (int.TryParse(SearchBar.Text.ToString(), out int id))
                    {
                        UnEvlGroupGrid.ItemsSource = Group_Helper.SearchUnEvaluated(EvaluationNamecmbox.SelectedValue.ToString(), int.Parse(SearchBar.Text.ToString())).DefaultView;
                    }
                    else
                    {
                        UnEvlGroupGrid.ItemsSource = Group_Helper.GetUnEvaluated(EvaluationNamecmbox.SelectedValue.ToString()).DefaultView;
                    }
                }
            }
            catch {}
            
        }
        private void loadEvaluatedGroup()
        {
            try
            {
                if (EvaluationNamecmbox.SelectedValue.ToString() != null)
                {
                    if (int.TryParse(SearchBar.Text.ToString(), out int id))
                    {
                        EvlGroupGrid.ItemsSource = Group_Helper.SearchEvaluated(EvaluationNamecmbox.SelectedValue.ToString(), int.Parse(SearchBar.Text.ToString())).DefaultView;
                    }
                    else
                    {

                        EvlGroupGrid.ItemsSource = Group_Helper.GetEvaluated(EvaluationNamecmbox.SelectedValue.ToString()).DefaultView;
                    }
                }
            }
            catch {}
                
        }

        private void StuGrid_Loaded()
        {
            try { GroupMembersGrid.Columns[0].Visibility = Visibility.Collapsed; } catch { }
        }
        
        private void EvlGrid_Loaded()
        {
            try { EvaluationsDetailsGrid.Columns[0].Visibility = Visibility.Collapsed; 
                EvaluationsDetailsGrid.Columns[1].Visibility = Visibility.Collapsed; } catch { }
        }

        private void EvalateGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = UnEvlGroupGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a Group from UnEvaluated Groups Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    // Evaluate Group Window
                    AddGroupEvaluation addGroupEvaluation = new AddGroupEvaluation(int.Parse(row.Row[0].ToString()), Evaluation_Helper.GetEvaluationIndex(EvaluationNamecmbox.SelectedIndex), EvaluationNamecmbox.SelectedValue.ToString());
                    addGroupEvaluation.ShowDialog();
                    loadEvaluatedGroup();
                    loadUnEvaluatedGroup();
                    GroupMembersGrid.ItemsSource = null;
                    EvaluationsDetailsGrid.ItemsSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void UpdateEvlBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = EvaluationsDetailsGrid.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a Evaluation from Evaluation Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    //Update the Group Evaluation Details Window
                    UpdateGroupEvaluation updateGroupEvaluation = new UpdateGroupEvaluation(int.Parse(row.Row[1].ToString()), int.Parse(row.Row[0].ToString()), EvaluationNamecmbox.SelectedValue.ToString(), int.Parse(row.Row[3].ToString()) , (DateTime)row.Row[6]);
                    updateGroupEvaluation.ShowDialog();
                    loadEvaluatedGroup();
                    loadUnEvaluatedGroup();
                    EvlGroupGrid_SelectedCellsChanged();
                    GroupMembersGrid.ItemsSource = null;
                    EvaluationsDetailsGrid.ItemsSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void UnEvlGroupGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataRowView row = UnEvlGroupGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                try
                {
                    GroupMembersGrid.ItemsSource = Group_Helper.GetStuFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                    StuGrid_Loaded();
                    EvaluationsDetailsGrid.ItemsSource = Evaluation_Helper.GetEvaluationFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                    EvlGrid_Loaded();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void UnEvlGroupGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
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
                    StuGrid_Loaded();
                    EvaluationsDetailsGrid.ItemsSource = Evaluation_Helper.GetEvaluationFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                    EvlGrid_Loaded();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void EvlGroupGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                    GroupMembersGrid.ItemsSource = Group_Helper.GetStuFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                    StuGrid_Loaded();
                    EvaluationsDetailsGrid.ItemsSource = Evaluation_Helper.GetEvaluationFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                    EvlGrid_Loaded();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Loading data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void EvlGroupGrid_SelectedCellsChanged(object sender=null, SelectedCellsChangedEventArgs e=null)
        {
            DataRowView row = EvlGroupGrid.SelectedItem as DataRowView;
            if (row != null)
            {
                try
                {
                    GroupMembersGrid.ItemsSource = Group_Helper.GetStuFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                    StuGrid_Loaded();
                    EvaluationsDetailsGrid.ItemsSource = Evaluation_Helper.GetEvaluationFromGid(int.Parse(row.Row[0].ToString())).DefaultView;
                    EvlGrid_Loaded();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Loading data from Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void EvaluationsDetailsGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
