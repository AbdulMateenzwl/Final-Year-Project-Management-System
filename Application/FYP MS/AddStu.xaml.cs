using FYP_MS.HelperClasses;
using FYP_MS.Validations;
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
    /// Interaction logic for AddStu.xaml
    /// </summary>
    /// 

    public partial class AddStu : Window
    {
        public AddStu()
        {
            InitializeComponent();
            Datepicker.SelectedDate= DateTime.Now;
            // Assign values to combox
            CmboxGender.ItemsSource=Lookup.getGenders();
            CmboxGender.SelectedIndex=0;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void donebtn_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                try
                {
                    Person_Helper.addPerson(FirstName.Text, LastName.Text, ContactNo.Text, Email.Text, Datepicker.SelectedDate.Value, Lookup.getIndexFromValue(CmboxGender.SelectedValue.ToString()));
                    Stu_Helper.addStudent(Person_Helper.getLastPersonId(), RegNo.Text);
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("There is an error while updating the record "+ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if(!validations.contact(ContactNo.Text))
            {
                MessageBox.Show("Contact Number length Must be 11 and should not Contain characters", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            if (!validations.email(Email.Text))
            {
                MessageBox.Show("InValid Email Address", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            if (!validations.age16plus(Datepicker.SelectedDate.Value))
            {
                MessageBox.Show("Age is Below 16", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            return true;
        }

    }
}
