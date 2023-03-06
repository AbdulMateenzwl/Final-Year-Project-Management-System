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
    /// Interaction logic for AddGrp.xaml
    /// </summary>
    public partial class AddGrp : Window
    {
        private List<Stu> stuList;
        public AddGrp()
        {
            InitializeComponent();
            loadData();
            stuList = new List<Stu>();
            AllStudents.Loaded += Grid_Loaded;
            this.DataContext = stuList;
            SelectedStudents.ItemsSource = stuList;
            SelectedStudents.Columns[0].Visibility = Visibility.Collapsed;
            Datepicker.SelectedDate= DateTime.Now;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void loadData()
        {
            try
            {
                AllStudents.ItemsSource = Group_Helper.getStudentNotInGroup(SearchBar.Text).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Grid_Loaded(object sender = null, RoutedEventArgs e = null)
        {
            //AllStudents.Columns[0].Visibility = Visibility.Collapsed;
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
        private void UpdateStudentBtnClick(object sender, RoutedEventArgs e)
        {
            DataRowView row = AllStudents.SelectedItem as DataRowView;
            if (row == null)
            {
                MessageBox.Show("Please Select a value from Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if ( Stu.Contains(stuList,int.Parse(row.Row[0].ToString())))
                    {
                        MessageBox.Show("This Student is already Selected.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        stuList.Add(new Stu(int.Parse(row.Row[0].ToString()), row.Row[1].ToString(), row.Row[2].ToString(), row.Row[3].ToString()));
                        SelectedStudents.ItemsSource = null;
                        SelectedStudents.ItemsSource = stuList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Stu> d = SelectedStudents.ItemsSource as List<Stu>;
                if (d.Count > 0)
                {
                    Group_Helper.addGroup(Datepicker.SelectedDate.Value);
                    int Gid = Group_Helper.getLastGroupId();
                    for (int i = 0; i < d.Count; i++)
                    {
                        Group_Helper.addStuGroup(Gid, d[i].id, true, DateTime.Now);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select Atleast One Student.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("There is an Error while Adding Students in Group. " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void RemoveStu(object sender, RoutedEventArgs e)
        {
            Stu row = SelectedStudents.SelectedItem as Stu;
            if (row == null)
            {
                MessageBox.Show("Please Select a value from Student Table.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    if(!stuList.Contains(row))
                    {
                        MessageBox.Show("This Student does not exsists in the Group any more.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        stuList.Remove(row);
                        SelectedStudents.ItemsSource = null;
                        SelectedStudents.ItemsSource = stuList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Updating data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }

}
