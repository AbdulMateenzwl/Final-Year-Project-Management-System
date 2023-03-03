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
    /// Interaction logic for UpdateProject.xaml
    /// </summary>
    public partial class UpdateProject : Window
    {
        private int Pid;
        public UpdateProject(int ProjectId, string title, string discription)
        {
            InitializeComponent();
            Pid= ProjectId;
            TopicTxtBox.Text = title;
            DescriptionTextBox.Text = discription;
        }
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void donebtn_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                try
                {
                    // Update the Project with values
                    HelperClasses.Project_Helper.updateProject(Pid, TopicTxtBox.Text, DescriptionTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is an error while Adding Value to DataBase " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                this.Close();
            }
        }
        private bool validate()
        {
            if (!validations.name(TopicTxtBox.Text))
            {
                MessageBox.Show("Title should atleast be 3 characters.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!validations.description(DescriptionTextBox.Text))
            {
                MessageBox.Show("Description Should be more than 50 characters.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
