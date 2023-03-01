using Lab2_GettingStartedWithDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_MS
{
    public static class Person_Helper
    {
        public static void addPerson(string FirstName,string LastName,string Contact,string email,DateTime dateTime,int gender)
        {
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into person values(@firstname,@lastname,@contact,@email,@date,@gender)", con);
            cmd.Parameters.AddWithValue("firstname", FirstName);
            cmd.Parameters.AddWithValue("lastname", LastName);
            cmd.Parameters.AddWithValue("contact", Contact);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("date", dateTime);
            cmd.Parameters.AddWithValue("gender", gender);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static int getLastPersonId()
        {
            string insertSql = "SELECT MAX(ID) AS LastID FROM Person";
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(insertSql, con);
            int ans = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return ans;
        }
        public static void updatePerson(string FN, string LN, string C, string E, DateTime DT, int G,int PID)
        {
            string Text = "UPDATE Person SET firstname = @FirstName_, LastName = @LastName_, Contact = @cont_,Email =@email_,DateOfBirth = @dTime_,gender =@Gdr_ Where id = @id_";
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(Text, con);
            cmd.Parameters.AddWithValue("FirstName_", FN);
            cmd.Parameters.AddWithValue("LastName_", LN);
            cmd.Parameters.AddWithValue("cont_", C);
            cmd.Parameters.AddWithValue("email_", E);
            cmd.Parameters.AddWithValue("dTime_", DT);
            cmd.Parameters.AddWithValue("Gdr_", G);
            cmd.Parameters.AddWithValue("id_", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static DataTable GetFullTable()
        {
            var con = Config.getConnection();
            SqlCommand cmd = new SqlCommand("Select * from person", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;
        }
        
    }
}
