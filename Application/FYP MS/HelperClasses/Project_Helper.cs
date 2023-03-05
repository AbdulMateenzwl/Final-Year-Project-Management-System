using Lab2_GettingStartedWithDatabase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FYP_MS.HelperClasses
{
    public static class Project_Helper
    {
        public static void addProject(string title, string description)
        {
            MessageBox.Show("testing 2");
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Project values(@des,@title)", con);
            cmd.Parameters.AddWithValue("title", title);
            cmd.Parameters.AddWithValue("des", description);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static void updateProject(int id, string title, string desc)
        {
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("update Project set Title = @title , Description = @desc where id = @id", con);
            cmd.Parameters.AddWithValue("title", title);
            cmd.Parameters.AddWithValue("desc", desc);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static DataTable GetProjectTable()
        {
            var con = Config.getConnection();
            SqlCommand cmd = new SqlCommand("Select id,title,Description from Project", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;
        }
        public static DataTable Search(string str)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand("Select id,title,Description from Project " +
                    "where Title + Description like @str_ ", con))
                {
                    cmd.Parameters.AddWithValue("str_", string.Format("%{0}%", str));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable GetProjectNotAssigned(string str)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand("Select id,title,Description from Project " +
                    "where Project.Id not in ( select s.ProjectId from GroupProject as s ) and Title + Description like @str_ ", con))
                {
                    cmd.Parameters.AddWithValue("str_", string.Format("%{0}%", str));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable GetAssignedProjectWithDetails()
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand(" select GroupId,Project.Title ,(select Person.FirstName+' '+Person.LastName from ProjectAdvisor PA join Person on Person.Id= Pa.AdvisorId where GP.ProjectId = Pa.ProjectId and PA.AdvisorRole = 11 ) as [Main Advisor] ,(select Person.FirstName+' '+Person.LastName from ProjectAdvisor PA join Person on Person.Id= Pa.AdvisorId where GP.ProjectId = Pa.ProjectId and PA.AdvisorRole = 12 ) as [Co Advisor] ,(select Person.FirstName+' '+Person.LastName from ProjectAdvisor PA join Person on Person.Id= Pa.AdvisorId where GP.ProjectId = Pa.ProjectId and PA.AdvisorRole = 14 ) as [Industry Advisor] from GroupProject GP join Project on Project.Id = GP.ProjectId\r\n ", con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
    }
}
