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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for ProjectCRUD.xaml
    /// </summary>
    public partial class ProjectCRUD : UserControl
    {
        public ProjectCRUD()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProject addpr = new AddProject();
            addpr.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddProject addpr = new AddProject(true);
            addpr.ShowDialog();
        }
    }
}
