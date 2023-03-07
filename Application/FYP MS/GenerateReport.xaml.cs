using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace FYP_MS.HelperClasses
{
    /// <summary>
    /// Interaction logic for GenerateReport.xaml
    /// </summary>
    public partial class GenerateReport : UserControl
    {
        public GenerateReport()
        {
            InitializeComponent();
            Grid.ItemsSource = Stu_Helper.GetStudentTableDetails().DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER,10,10,42,35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
            doc.Open();






            // Fonts
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            // Text Sizes
            Font Heading = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.NORMAL);
            Font Parafont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

            // Repeated values
            PdfPTable table=null;
            DataTable dataTable = null;

            ////////////////// Student Section
            Paragraph StudentHeading = new Paragraph("Students", Heading);
            StudentHeading.IndentationLeft = 20;
            doc.Add(StudentHeading);

            ////////  Student Table 
            dataTable = Stu_Helper.GetStudentTableDetails();
            table = new PdfPTable(dataTable.Columns.Count - 1);
            table.SpacingBefore = 10;

            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataTable.Columns[i].ColumnName));
            }
            table.HeaderRows = 1;

            foreach (DataRow row in dataTable.Rows)
            {
                string firstname = row["firstName"].ToString();
                string lastname = row["LastName"].ToString();
                string registrationno = row["RegistrationNo"].ToString();
                string contact = row["Contact"].ToString();
                string email = row["Email"].ToString();
                string DOB = row["DateofBirth"].ToString();
                string Gender = row["Gender"].ToString();
                table.AddCell(new Phrase(firstname, Parafont));
                table.AddCell(new Phrase(lastname, Parafont));
                table.AddCell(new Phrase(registrationno, Parafont));
                table.AddCell(new Phrase(contact, Parafont));
                table.AddCell(new Phrase(email, Parafont));
                table.AddCell(new Phrase(DOB, Parafont));
                table.AddCell(new Phrase(Gender, Parafont));
            }

            doc.Add(table);
            // End Student Section


            ///////////////////  Project Section
            Paragraph ProjectsHeading= new Paragraph("Projects", Heading);
            ProjectsHeading.IndentationLeft = 20;
            doc.Add(ProjectsHeading);

            ///////////// Projects DataTable
            dataTable = Project_Helper.GetProjectTable();
            table = new PdfPTable(dataTable.Columns.Count - 1);
            table.SpacingBefore = 10;

            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataTable.Columns[i].ColumnName));
            }
            table.HeaderRows = 1;

            foreach (DataRow row in dataTable.Rows)
            {
                string title = row["Title"].ToString();
                string description = row["Description"].ToString();
                table.AddCell(new Phrase(title,Parafont));
                table.AddCell(new Phrase(description,Parafont));
            }
            doc.Add(table);







            

            doc.Close();
        }
    }
}
