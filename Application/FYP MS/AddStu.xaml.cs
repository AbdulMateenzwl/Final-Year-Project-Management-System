﻿using FYP_MS.HelperClasses;
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
        private bool update = false;
        public AddStu(bool flag=false)
        {
            InitializeComponent();
            Datepicker.SelectedDate= DateTime.Now;
            // Assign values to combox
            CmboxGender.ItemsSource=Lookup.getGenders();
            CmboxGender.SelectedIndex=0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void donebtn_Click(object sender, RoutedEventArgs e)
        {
            // validation
            //if (validate())
            {
                Person_Helper.addPerson(FirstName.Text, LastName.Text, ContactNo.Text, Email.Text, Datepicker.SelectedDate.Value, Lookup.getIndexFromValue(CmboxGender.SelectedValue.ToString()));
            }
        }
        private bool validate()
        {
            /*if(GetDifferenceInYears(DateTime.Now , Datepicker.SelectedDate.Value) >= 16)
            {
                return false;
            }*/
            if (FirstName.Text == "" || LastName.Text == "" || ContactNo.Text == "" || Email.Text == "")
            {
                MessageBox.Show(CmboxGender.SelectedValue.ToString());
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
