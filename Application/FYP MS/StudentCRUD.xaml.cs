﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Markup;
using FYP_MS.HelperClasses;
using System.Collections.ObjectModel;

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for StudentCRUD.xaml
    /// </summary>
    /// 
    public partial class StudentCRUD : UserControl
    {
        public StudentCRUD()
        {
            InitializeComponent();
            loadData();
            Grid.Loaded += Grid_Loaded;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStu addStu = new AddStu();
            addStu.ShowDialog();
            SearchBar.Text = null;
            loadData();
            Grid_Loaded();
        }
        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = Grid.SelectedItem as DataRowView;
            if(row==null)
            {
                MessageBox.Show("Please Select a value from Table", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                updateStu ustu = new updateStu(row.Row.ItemArray[1].ToString(), row.Row.ItemArray[2].ToString(), row.Row.ItemArray[3].ToString(), row.Row.ItemArray[4].ToString(), row.Row.ItemArray[5].ToString(), (DateTime)row.Row.ItemArray[6],(row.Row.ItemArray[7].ToString()), (int)row.Row.ItemArray[0]);
                ustu.ShowDialog();
                loadData();
                Grid_Loaded();
            }
        }
        private void loadData()
        {
            try
            {
                //Grid.ItemsSource = Stu_Helper.GetStudentTableDetails().DefaultView;
                Grid.ItemsSource = Stu_Helper.Search(SearchBar.Text).DefaultView;
               
            }
            catch(Exception e) 
            {
                MessageBox.Show("Error loading data from Database "+e, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void clearTxt_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Text = "";
        }
        private void Grid_Loaded(object sender=null, RoutedEventArgs e=null)
        {
            Grid.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // data changes as text changes
            loadData();
            Grid_Loaded();
        }
    }
}
