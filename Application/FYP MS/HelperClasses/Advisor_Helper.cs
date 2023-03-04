using Lab2_GettingStartedWithDatabase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_MS.HelperClasses
{
    public static class Advisor_Helper
    {
        public static void addAdvisor(int id, int Design,int Salry)
        {
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Advisor values(@id,@designation,@Salary)", con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("designation", Design);
            cmd.Parameters.AddWithValue("Salary", Salry);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static DataTable GetAdvisorTable()
        {
            var con = Config.getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Advisor", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;
        }
        public static DataTable GetAdvisorTableDetails()
        {
            var con = Config.getConnection();
            SqlCommand cmd = new SqlCommand("Select p.id,p.FirstName,p.LastName,lo.Value AS Designation,s.Salary,p.Contact,p.Email,p.DateOfBirth,l.Value as Gender " +
                "from Advisor as s " +
                "join person as p on s.id = p.id " +
                "join lookup as l on p.gender = l.id " +
                "join lookup as lo on s.Designation=lo.Id ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;
        }
        public static void updateAdvisor(int Design,int Salray , int PID)
        {
            string Text = "UPDATE advisor SET Designation = @des_ ,salary = @sal_  Where id = @id_";
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(Text, con);
            cmd.Parameters.AddWithValue("des_", Design);
            cmd.Parameters.AddWithValue("sal_", Salray);
            cmd.Parameters.AddWithValue("id_", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static DataTable Search(string str)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand("Select p.id,p.FirstName,p.LastName,lo.Value AS Designation,s.Salary,p.Contact,p.Email,p.DateOfBirth,l.Value as Gender " +
                    "from advisor as s " +
                    "join person as p on s.id = p.id " +
                    "join lookup as l on p.gender = l.id " +
                    "join lookup as lo on s.Designation=lo.Id " +
                    "where FirstName + LastName + Email + lo.value + contact like @str_ ", con))
                {
                    cmd.Parameters.AddWithValue("str_", string.Format("%{0}%", str));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable GetAdvisors(string str)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand("Select p.id,p.FirstName,p.LastName,lo.Value AS Designation,l.Value as Gender " +
                    "from advisor as s " +
                    "join person as p on s.id = p.id " +
                    "join lookup as l on p.gender = l.id " +
                    "join lookup as lo on s.Designation=lo.Id " +
                    "where FirstName + LastName + Email + lo.value + contact like @str_ ", con))
                {
                    cmd.Parameters.AddWithValue("str_", string.Format("%{0}%", str));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
    }
}
