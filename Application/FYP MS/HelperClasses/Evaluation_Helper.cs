using Lab2_GettingStartedWithDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_MS.HelperClasses
{
    public static class Evaluation_Helper
    {
        public static DataTable GetEvaluations(string str)
        {
            var con = Config.getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Evaluation where name like @str", con);
            cmd.Parameters.AddWithValue("str", string.Format("%{0}%", str));
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;
        }
        public static void insertGroup(string name,int totalM,int tWeightage)
        {
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into evaluation values(@name,@tot,@weight)", con);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("tot", totalM);
            cmd.Parameters.AddWithValue("weight", tWeightage);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
    }
}
