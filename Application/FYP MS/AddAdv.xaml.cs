using FYP_MS.HelperClasses;
using FYP_MS.Validations;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
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
    /// Interaction logic for AddAdv.xaml
    /// </summary>
    public partial class AddAdv : Window
    {
        public AddAdv()
        {
            InitializeComponent();
            CmboxGender.ItemsSource = Lookup.getGenders();
            DesignationCmBox.ItemsSource = Lookup.getDesignations();
            CmboxGender.SelectedIndex = 0;
            DesignationCmBox.SelectedIndex = 0;
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
                    Person_Helper.addPerson(FirstName.Text, LastName.Text, ContactNo.Text, Email.Text, DatePicker.SelectedDate.Value, Lookup.getIndexFromValue(CmboxGender.SelectedValue.ToString()));
                    Advisor_Helper.addAdvisor(Person_Helper.getLastPersonId(),Lookup.getIndexFromValue(CmboxGender.SelectedValue.ToString()),int.Parse(Salarytxtbox.Text));
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

        private void Salarytxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Salarytxtbox.Text.Length>0 )
            {
                if (!(Salarytxtbox.Text[Salarytxtbox.Text.Length-1] >='0' && Salarytxtbox.Text[Salarytxtbox.Text.Length-1] <='9'))
                {
                    Salarytxtbox.Text = Salarytxtbox.Text.Substring(0,Salarytxtbox.Text.Length-1);
                }
            }
        }
    }
}
