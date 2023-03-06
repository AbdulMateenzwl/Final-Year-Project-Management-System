using System.Windows;
using System.Windows.Input;

namespace FYP_MS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StuBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StudentCRUD Stu = new StudentCRUD();
            mainField.Children.Clear();
            mainField.Children.Add(Stu);
        }

        private void AdvBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AdvisorMenu advmenu = new AdvisorMenu();
            mainField.Children.Clear();
            mainField.Children.Add(advmenu);
        }

        private void Projectbtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProjectCRUD projectCRUDproject  = new ProjectCRUD();
            mainField.Children.Clear();
            mainField.Children.Add(projectCRUDproject);
        }

        private void GroupManagebtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GroupCRUD projectCRUD = new GroupCRUD();
            mainField.Children.Clear();
            mainField.Children.Add(projectCRUD);
        }

        private void AssignProjectbtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AssignProjectCRUD assignProject = new AssignProjectCRUD();
            mainField.Children.Clear();
            mainField.Children.Add(assignProject);
        }

        private void EvalutionBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EvaluationCRUD evaluationCRUD = new EvaluationCRUD();
            mainField.Children.Clear();
            mainField.Children.Add(evaluationCRUD);
        }

        private void GroupEvaluation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GroupEvaluation GroupEvl = new GroupEvaluation();
            mainField.Children.Clear();
            mainField.Children.Add(GroupEvl);
        }

    }
}
