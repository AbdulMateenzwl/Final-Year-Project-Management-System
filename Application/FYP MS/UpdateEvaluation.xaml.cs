using FYP_MS.HelperClasses;
using FYP_MS.Validations;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for UpdateEvaluation.xaml
    /// </summary>
    public partial class UpdateEvaluation : Window
    {
        private int EvaluationId;
        public UpdateEvaluation(string name,int totalMarks,int WeightAge,int evlId)
        {
            InitializeComponent();
            EvlName.Text = name;
            TotalMarks.Text = totalMarks.ToString();
            WeightAgetxtbox.Text = WeightAge.ToString();
            EvaluationId = evlId;   
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
                    Evaluation_Helper.UpdateEvaluation(EvlName.Text.ToString(), int.Parse(TotalMarks.Text.ToString()), int.Parse(WeightAgetxtbox.Text.ToString()),EvaluationId);
                }
                catch (Exception ex)
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
            }
            int value = int.Parse(WeightAgetxtbox.Text.ToString());
            int taken_percent = Evaluation_Helper.GetAssigedPercentageEvaluations();
            if (value + taken_percent > 100)
            {
                MessageBox.Show($"Total percentage will become {value + taken_percent}. Please Select value less than {100 - taken_percent}.", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            return true;
        }
    }
}
