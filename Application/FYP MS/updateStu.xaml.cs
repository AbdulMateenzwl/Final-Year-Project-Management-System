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
using System.Windows.Shapes;

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for updateStu.xaml
    /// </summary>
    public partial class updateStu : Window
    {
        private int Pid;
        public updateStu(string FirstName, string LastName,string regno, string Contact, string email, DateTime dateTime, string gender, int PersonID)
        {
            InitializeComponent();
            // Assign values to the input fields
            this.FirstName.Text = FirstName;
            this.LastName.Text = LastName;
            this.RegNo.Text = regno;
            this.ContactNo.Text = Contact;
            this.Email.Text = email;
            Datepicker.SelectedDate=dateTime;
            CmboxGender.ItemsSource = Lookup.getGenders();
            CmboxGender.SelectedValue = gender;
            Pid = PersonID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void donebtn_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                try
                {
                    // update person and student in db
                    Person_Helper.updatePerson(FirstName.Text, LastName.Text, ContactNo.Text, Email.Text, Datepicker.SelectedDate.Value, Lookup.getIndexFromValue(CmboxGender.SelectedValue.ToString()),Pid);
                    Stu_Helper.updateStu(RegNo.Text, Pid);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("There is an error while updating the record", "Alert",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Values");
            }
        }


        private bool validate()
        {
            if (GetDifferenceInYears(DateTime.Now, Datepicker.SelectedDate.Value) >= 16)
            {
                MessageBox.Show("Age is not valid");
                return false;
            }
            if (FirstName.Text == "" || LastName.Text == "" || ContactNo.Text == "" || Email.Text == "")
            {
                return false;
            }
            return true;
        }
        int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            return (endDate.Year - startDate.Year - 1) +
                (((endDate.Month > startDate.Month) ||
                ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
        }
    }
}
