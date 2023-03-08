using System;
using Microsoft.Win32;
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
using System.Windows.Documents;
using Syncfusion.Windows.Forms;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Globalization;

namespace FYP_MS.HelperClasses
{
    /// <summary>
    /// Interaction logic for GenerateReport.xaml
    /// </summary>
    public partial class GenerateReport : System.Windows.Controls.UserControl
    {
        // Fonts
        static BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        // Text Sizes
        Font FirstHeading = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
        Font SecondHeading = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD);
        Font ThirdHeading = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
        Font HeadFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
        Font Parafont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
        public GenerateReport()
        {
            InitializeComponent();
            //pdfviewer.Navigate(new Uri("about:blank")); 
            //pdfviewer.Navigate("C:\\Users\\star tech !\\Desktop\\Semester-4-Database-Mid-Project\\Application\\FYP MS\\bin\\Debug\\Test.pdf");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.DefaultExt = ".pdf";
            saveFileDialog.Filter = "PDF document (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"FYP Report {DateTime.Now.ToString("yyyy-MM-dd")}";
            saveFileDialog.InitialDirectory = $"C:\\Users\\{System.Environment.MachineName}\\Desktop";
            if (saveFileDialog.ShowDialog() == true)
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                doc.Open();


                ////////////////// Student Section
                AddFirstHeading("Students", ref doc);
                AddStudentTable(ref doc);
                doc.NewPage();
                // End Student Section

                ////////////////// Advisors Section
                AddFirstHeading("Advisors", ref doc);
                AddAdvisorTable(ref doc);
                doc.NewPage();
                // End Advisors Section

                /////////////////// Evaluation SEction
                AddFirstHeading("Evaluations", ref doc);
                AddEvaluationTable(ref doc);
                doc.NewPage();
                //  End Evluation Section

                ///////////////////  Project Section
                AddFirstHeading("Projects", ref doc);
                AddProjectsTable(ref doc);
                doc.NewPage();
                // End Project Secion

                ////////// Assigned Advisor with there Students Section
                AddFirstHeading("Groups with Assigned Project and Advisors", ref doc);
                AddAdvisorsWithStudents(ref doc);
                doc.NewPage();
                //End Advisors Student Section
                doc.Close();
            }
            
            
        }
        private void AddFirstHeading(string str,ref Document doc)
        {
            iTextSharp.text.Paragraph StudentFirstHeading = new iTextSharp.text.Paragraph(str, FirstHeading);
            StudentFirstHeading.IndentationLeft = 40;
            doc.Add(StudentFirstHeading);
        }
        private void AddSecHeading(string str,ref Document doc)
        {
            iTextSharp.text.Paragraph StudentFirstHeading = new iTextSharp.text.Paragraph(str, SecondHeading);
            StudentFirstHeading.IndentationLeft = 40;
            doc.Add(StudentFirstHeading);
        }
        private void AddThirdHeading(string str,ref Document doc)
        {
            iTextSharp.text.Paragraph StudentFirstHeading = new iTextSharp.text.Paragraph(str, ThirdHeading);
            StudentFirstHeading.IndentationLeft = 40;
            doc.Add(StudentFirstHeading);
        }
        private void AddFontHeading(string str,ref Document doc)
        {
            iTextSharp.text.Paragraph StudentFirstHeading = new iTextSharp.text.Paragraph(str, HeadFont);
            StudentFirstHeading.IndentationLeft = 40;
            doc.Add(StudentFirstHeading);
        }
        private void AddPara(string str,ref Document doc)
        {
            iTextSharp.text.Paragraph StudentFirstHeading = new iTextSharp.text.Paragraph(str, Parafont);
            StudentFirstHeading.IndentationLeft = 70;
            doc.Add(StudentFirstHeading);
        }
        private void AddStudentTable(ref Document doc)
        {
            DataTable dataTable = Stu_Helper.GetStudentTableDetails();
            PdfPTable table = new PdfPTable(dataTable.Columns.Count - 1);
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
        }
        private void AddAdvisorTable(ref Document doc)
        {
            DataTable dataTable = Advisor_Helper.GetAdvisorTableDetails();
            PdfPTable table = new PdfPTable(dataTable.Columns.Count - 1);
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
                string designation = row["Designation"].ToString();
                string salary = row["Salary"].ToString();
                string contact = row["Contact"].ToString();
                string email = row["Email"].ToString();
                string DOB = row["DateofBirth"].ToString();
                string Gender = row["Gender"].ToString();
                table.AddCell(new Phrase(firstname, Parafont));
                table.AddCell(new Phrase(lastname, Parafont));
                table.AddCell(new Phrase(designation, Parafont));
                table.AddCell(new Phrase(salary, Parafont));
                table.AddCell(new Phrase(contact, Parafont));
                table.AddCell(new Phrase(email, Parafont));
                table.AddCell(new Phrase(DOB, Parafont));
                table.AddCell(new Phrase(Gender, Parafont));
            }
            doc.Add(table);
        }
        private void AddProjectsTable(ref Document doc)
        {
            DataTable  dataTable = Project_Helper.GetProjectTable();
            PdfPTable table = new PdfPTable(dataTable.Columns.Count - 1);
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
                table.AddCell(new Phrase(title, Parafont));
                table.AddCell(new Phrase(description, Parafont));
            }
            doc.Add(table);
        }
        private void AddAdvisorsWithStudents(ref Document doc)
        {
            DataTable dataTable = Project_Helper.GetProjectWithAdvisorsNames();
            int numRows = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                int Gid = int.Parse(row["GroupId"].ToString());
                string Title = row["Title"].ToString();
                DateTime assignDate = (DateTime)row["AssignmentDate"];
                string MAdv= row["Main Advisor"].ToString();
                string CAdv= row["Co Advisor"].ToString();
                string IAdv= row["Industry Advisor"].ToString();
                AddSecHeading( RomanNum.IntToRoman(++numRows) + ") Group ID : " + Gid , ref doc);
                AddPara($"The topic of Group {Gid} is {Title}.Project Assign Date is {assignDate}. The Advisors Assigned to the group are ",ref doc);
                AddFontHeading($"Main Advisor : {MAdv}", ref doc);
                AddFontHeading($"Co Advisor : {CAdv}", ref doc);
                AddFontHeading($"Industry Advisor : {IAdv}", ref doc);
                AddFontHeading($"Project Assign Date is  {assignDate}", ref doc);


                //Each Group Student Table
                AddThirdHeading(" • Group Students", ref doc);
                if (dataTable.Rows.Count <= 1)
                {
                    AddPara("There are no Students int this group.", ref doc);
                }
                DataTable dTable = Group_Helper.GetStuFromGid(Gid);
                PdfPTable table = new PdfPTable(dTable.Columns.Count - 1);
                table.SpacingBefore = 10;
                for (int i = 1; i < dTable.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dTable.Columns[i].ColumnName));
                }
                table.HeaderRows = 1;
                foreach (DataRow Row in dTable.Rows)
                {
                    string firstname = Row["FirstName"].ToString();
                    string lastname = Row["LastName"].ToString();
                    string registrationno = Row["RegistrationNo"].ToString();
                    string contact = Row["Contact"].ToString();
                    string email = Row["Email"].ToString();
                    table.AddCell(new Phrase(firstname, Parafont));
                    table.AddCell(new Phrase(lastname, Parafont));
                    table.AddCell(new Phrase(registrationno, Parafont));
                    table.AddCell(new Phrase(contact, Parafont));
                    table.AddCell(new Phrase(email, Parafont));
                }
                doc.Add(table);

                //Each Group Evaluations Table
                dTable = Evaluation_Helper.GetEvaluationFromGid(Gid);
                AddThirdHeading(" • Group Evaluations", ref doc);
                if (dTable.Rows.Count<1)
                {
                    AddPara("There are no Evaluations of this group.",ref doc);
                }
                table = new PdfPTable(dTable.Columns.Count - 2);
                table.SpacingBefore = 10;
                for (int i = 2; i < dTable.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dTable.Columns[i].ColumnName));
                }
                table.HeaderRows = 1;
                foreach (DataRow Row in dTable.Rows)
                {
                    string Ename = Row["Name"].ToString();
                    string Omarks= Row["ObtainedMarks"].ToString();
                    string TMarks= Row["TotalMarks"].ToString();
                    string TWeightAge = Row["TotalWeightage"].ToString();
                    DateTime Dtime = (DateTime)Row["EvaluationDate"];
                    table.AddCell(new Phrase(Ename, Parafont));
                    table.AddCell(new Phrase(Omarks, Parafont));
                    table.AddCell(new Phrase(TMarks, Parafont));
                    table.AddCell(new Phrase(TWeightAge, Parafont));
                    table.AddCell(new Phrase(Dtime.ToString(),Parafont));
                }
                doc.Add(table);

            }
        }
        private void AddEvaluationTable(ref Document doc)
        {
            DataTable dataTable = Evaluation_Helper.GetEvaluations();
            PdfPTable table = new PdfPTable(dataTable.Columns.Count - 1);
            table.SpacingBefore = 10;
            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataTable.Columns[i].ColumnName));
            }
            table.HeaderRows = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                string title = row["Name"].ToString();
                string totalmarks= row["TotalMarks"].ToString();
                string totalWeightAge = row["TotalWeightAge"].ToString();
                table.AddCell(new Phrase(title, Parafont));
                table.AddCell(new Phrase(totalmarks, Parafont));
                table.AddCell(new Phrase(totalWeightAge, Parafont));
            }
            doc.Add(table);
        }
    }
}
