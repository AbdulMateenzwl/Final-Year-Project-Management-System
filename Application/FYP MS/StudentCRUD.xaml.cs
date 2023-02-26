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
    /// Interaction logic for StudentCRUD.xaml
    /// </summary>
    /// 
    public class data
    {
        public int time;
        public int date;
        public int year;
        public data(int time, int date, int year)
        {
            this.time = time;
            this.date = date;
            this.year = year;
        }
    }
    public partial class StudentCRUD : UserControl
    {
        public StudentCRUD()
        {
            InitializeComponent();
            /*data dat1 = new data(1, 2, 3);
            data dat2 = new data(4, 5, 6);
            data dat3 = new data(7, 8, 9);
            List<data> list = new List<data>() { dat1, dat2, dat3 };
            Grid.ItemsSource = list;
            Grid.DataContext= list;*/
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStu addStu = new AddStu();
            addStu.ShowDialog();
            
        }
        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStu addStu = new AddStu(true);
            addStu.ShowDialog();
        }

    }
}
