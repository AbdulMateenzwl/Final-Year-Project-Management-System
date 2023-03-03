using FYP_MS.HelperClasses;
using FYP_MS.Validations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for updateAdv.xaml
    /// </summary>
    public partial class updateAdv : Window
    {
        private int PId;
        public updateAdv(string FirstName, string LastName,string design ,int salary, string Contact, string email, DateTime dateTime, string gender, int PersonID)
        {
            InitializeComponent();
            CmboxGender.ItemsSource = Lookup.getGenders();
            DesignationCmBox.ItemsSource = Lookup.getDesignations();
            this.FirstName.Text = FirstName;
            this.LastName.Text = LastName;
            this.Salarytxtbox.Text = salary.ToString();
            this.ContactNo.Text = Contact;
            this.Email.Text = email;
            DatePicker.SelectedDate = dateTime;
            CmboxGender.SelectedValue = gender;
            DesignationCmBox.SelectedValue = design;
            PId = PersonID;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void donebtn_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                try
                {
                    // Update the values of person and advisor in db
                    Person_Helper.updatePerson(FirstName.Text, LastName.Text, ContactNo.Text, Email.Text, DatePicker.SelectedDate.Value, Lookup.getIndexFromValue(CmboxGender.SelectedValue.ToString()), PId);
                    Advisor_Helper.updateAdvisor(Lookup.getIndexFromValue(DesignationCmBox.SelectedValue.ToString()), int.Parse(Salarytxtbox.Text), PId);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error while updating the record " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool validate()
        {
            if (!validations.name(FirstName.Text) || !validations.name(LastName.Text))
            {
                MessageBox.Show("Name should atleast be 3 characters", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            if (!validations.contact(ContactNo.Text))
            {
                MessageBox.Show("Contact Number length Must be 11 and should not Contain characters", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            if (!validations.email(Email.Text))
            {
                MessageBox.Show("InValid Email Address", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            if (!validations.age16plus(DatePicker.SelectedDate.Value))
            {
                MessageBox.Show("Age is Below 16", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            if (!validations.greaterThanZero(int.Parse(Salarytxtbox.Text)))
            {
                MessageBox.Show("Salary Must be a postive Number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            return true;
        }

        private void Salarytxtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = validations.NumberInput(e);
        }
    }
}
