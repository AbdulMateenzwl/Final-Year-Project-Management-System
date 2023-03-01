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
        public static bool update(string FirstName, string LastName, string Contact, string email, DateTime dateTime, int gender,int PersonID)
        {

            return true;
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
