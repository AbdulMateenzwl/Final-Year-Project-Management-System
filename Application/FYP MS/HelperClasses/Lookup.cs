using Lab2_GettingStartedWithDatabase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;

namespace FYP_MS.HelperClasses
{
    public static class Lookup
    {
        public static List<string> getGenders()
        {
            var con = Config.getConnection();
            SqlCommand cmd = new SqlCommand("Select value from Lookup where Category = 'Gender'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<string> list=new List<string>();
            while (sdr.Read())
            {
                string gender = sdr.GetString(0);
                list.Add(gender);
            }
            con.Close();
            return list;
        }
        public static int getIndexFromValue(string str)
        {
            var con = Config.getConnection();
            SqlCommand cmd = new SqlCommand($"Select Id from Lookup where value = '{str}'", con);
            con.Open();
            int id = (int)cmd.ExecuteScalar();
            con.Close();
            return id;
        }
    }
}
