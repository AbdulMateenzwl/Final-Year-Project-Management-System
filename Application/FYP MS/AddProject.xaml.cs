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
    /// Interaction logic for AddProject.xaml
    /// </summary>
    public partial class AddProject : Window
    {
        public AddProject()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void donebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HelperClasses.Project_Helper.addProject(TopicTxtBox.Text, DescriptionTextBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("There is an error while Adding Value to DataBase "+ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
