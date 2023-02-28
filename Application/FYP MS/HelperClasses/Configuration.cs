using System;
using System.Data.SqlClient;
namespace Lab2_GettingStartedWithDatabase
{
    class Config
    {
        static String ConnectionStr = @"Data Source=MATEENS-LAPTOP;Initial Catalog=ProjectA;Integrated Security=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(ConnectionStr);
        }
    }
}




