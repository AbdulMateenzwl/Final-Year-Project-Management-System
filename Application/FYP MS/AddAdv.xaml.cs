﻿using System;
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
    /// Interaction logic for AddAdv.xaml
    /// </summary>
    public partial class AddAdv : Window
    {
        private bool update=false;
        public AddAdv(bool flag= false)
        {
            InitializeComponent();
            update = flag;
            if (update)
            {
                InitializeComponent();
                donebtn.Content = "Update Advisor";
                donebtn.Width += 20;
                // Assign values to the boxes
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}
