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
    /// Interaction logic for UpdateGroupEvaluation.xaml
    /// </summary>
    public partial class UpdateGroupEvaluation : Window
    {
        private int GroupId = 0;
        private int EvlId = 0;
        public UpdateGroupEvaluation(int groupId, int evlId, string evlName,int obtainedMarks ,DateTime evlDate)
        {
            InitializeComponent();
            EvlDatepicker.SelectedDate = evlDate;
            EvlName.Text = evlName;
            GroupId = groupId;
            EvlId = evlId;
            TotalMarks.Text = Evaluation_Helper.GetTotalMarksofEvaluation(evlId);
            ObtainedMarks.Text = obtainedMarks.ToString();
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
            if (validate())
            {
                Evaluation_Helper.UpdateGroupEvaluation(GroupId, EvlId, int.Parse(ObtainedMarks.Text.ToString()), EvlDatepicker.SelectedDate.Value);
                this.Close();
            }
        }
        private bool validate()
        {
            if(int.TryParse(ObtainedMarks.Text.ToString(), out int u))
            {
                MessageBox.Show("Marks must be integar.", "Alert", MessageBoxButton.OK, MessageBoxImage.Question);
                return false;
            }
            return true;
        }
    }
}
