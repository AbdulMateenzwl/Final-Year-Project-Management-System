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
    /// Interaction logic for AddEvaluation.xaml
    /// </summary>
    public partial class AddEvaluation : Window
    {
        public AddEvaluation()
        {
            InitializeComponent();
        }

        private void TotalMarks_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = validations.NumberInput(e);
        }

        private void WeightAgetxtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = validations.NumberInput(e);
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
                    Evaluation_Helper.insertGroup(EvlName.Text.ToString(), int.Parse(TotalMarks.Text.ToString()), int.Parse(WeightAgetxtbox.Text.ToString()));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("There is an error while updating the record " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                this.Close();
            }
        }
        private bool validate()
        {
            if (!validations.name(EvlName.Text))
            {
                MessageBox.Show("Name should atleast be 3 characters", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            if (!validations.greaterThanZero(int.Parse(TotalMarks.Text)))
            {
                MessageBox.Show("Marks Must be a postive Number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }if (!validations.greaterThanZero(int.Parse(WeightAgetxtbox.Text)))
            {
                MessageBox.Show("WeightAge Must be a postive Number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            return true;
        }
    }
}
