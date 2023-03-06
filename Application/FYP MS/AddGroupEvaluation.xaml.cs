using FYP_MS.HelperClasses;
using FYP_MS.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AddGroupEvaluation.xaml
    /// </summary>
    public partial class AddGroupEvaluation : Window
    {
        private int GroupId = 0;
        private int EvlId = 0;
        public AddGroupEvaluation(int groupId, int evlId, string evlName)
        {
            InitializeComponent();
            EvlDatepicker.SelectedDate = DateTime.Now;
            EvlName.Text = evlName;
            GroupId = groupId;
            EvlId = evlId;
            TotalMarks.Text = Evaluation_Helper.GetTotalMarksofEvaluation(evlId);
        }

        private void ObtainedMarks_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = validations.NumberInput(e);
        }

        private void TotalMarks_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = validations.NumberInput(e);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void donebtn_Click(object sender, RoutedEventArgs e)
        {
            if(validate())
            {
                try
                {
                    Evaluation_Helper.AddGroupEvaluation(GroupId, EvlId, int.Parse(ObtainedMarks.Text.ToString()), EvlDatepicker.SelectedDate.Value);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error Saving data into Database " + ex, "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                this.Close();
            }
        }
        private bool validate()
        {
            if (!int.TryParse(ObtainedMarks.Text.ToString(), out int u))
            {
                MessageBox.Show("Marks must be integar.", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            if (int.Parse(ObtainedMarks.Text.ToString()) > int.Parse(TotalMarks.Text.ToString()))
            {
                MessageBox.Show("Obtained Marks cannot be more than Total Marks.", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            return true;
        }
    }
}
