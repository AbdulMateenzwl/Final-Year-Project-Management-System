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
    /// Interaction logic for AssignProject.xaml
    /// </summary>
    public partial class AssignProject : UserControl
    {
        public AssignProject()
        {
            InitializeComponent();
            data dat1 = new data(1, 2, 3);
            data dat2 = new data(4, 5, 6);
            data dat3 = new data(7, 8, 9);
            List<data> list = new List<data>() { dat1, dat2, dat3 };
            Grid.ItemsSource = list;
            Grid.DataContext = list;
            Grid1.ItemsSource = list;
            Grid1.DataContext = list;
        }
    }
}
