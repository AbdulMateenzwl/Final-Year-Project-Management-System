using Lab2_GettingStartedWithDatabase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Controls;

namespace FYP_MS.HelperClasses
{
    public static class Group_Helper
    {
        public static DataTable getGroupDetails()
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Groups"))
            {
                using (SqlCommand cmd = new SqlCommand("Select id as [Group No],Created_On as [Creation Date] from [dbo].[group]", con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable getGroupsNotAssignedProject()
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Groups"))
            {
                using (SqlCommand cmd = new SqlCommand("Select id as [Group No],Created_On as [Creation Date] from [dbo].[group] where id not in (select GP.Groupid from GroupProject as GP)", con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable SearchGroup(int num)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Groups"))
            {
                using (SqlCommand cmd = new SqlCommand("Select id as [Group No],Created_On as [Creation Date] from [dbo].[group] where id = @num", con))
                {
                    cmd.Parameters.AddWithValue("num", num);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static void addGroup(DateTime dtime)
        {
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into [dbo].[Group] values(@date)", con);
            cmd.Parameters.AddWithValue("date", dtime);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static int getLastGroupId()
        {
            string insertSql = "SELECT MAX(ID) AS LastID FROM dbo.[Group]";
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(insertSql, con);
            int ans = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return ans;
        }
        public static void addStuGroup(int Gid,int Sid , bool status ,DateTime dtime)
        {
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into GroupStudent values( @gid, @sid, @st, @dtim )", con);
            cmd.Parameters.AddWithValue("gid", Gid);
            cmd.Parameters.AddWithValue("sid", Sid);
            cmd.Parameters.AddWithValue("st", status);
            cmd.Parameters.AddWithValue("dtim", dtime);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static DataTable GetStuFromGid(int Gid)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Student"))
            {
                using (SqlCommand cmd = new SqlCommand("Select p.id,p.FirstName,p.LastName,s.RegistrationNo,p.Contact,p.Email " +
                    "from student as s " +
                    "join person as p on s.id = p.id " +
                    "join lookup as l on p.gender = l.id " +
                    "join GroupStudent as GS on GS.StudentId = P.Id " +
                    "where GS.GroupId = @id ", con))
                {
                    cmd.Parameters.AddWithValue("id",Gid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable GetUnEvaluated(string Evl)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from [dbo].[group] where id not in ( select groupid from GroupEvaluation join Evaluation AS EVL on EVL.Id = GroupEvaluation.EvaluationId where EVL.Name like @EVL) and id in (select gp.GroupId from GroupProject GP) ", con))
                {
                    cmd.Parameters.AddWithValue("EVL", Evl);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable SearchUnEvaluated(string Evl, int id)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable())
            {
                using (SqlCommand cmd = new SqlCommand("select * from [dbo].[group] AS G where id not in ( select groupid from GroupEvaluation join Evaluation AS EVL on EVL.Id = GroupEvaluation.EvaluationId where EVL.Name like @EVL) and G.id = @id and id in (select gp.GroupId from GroupProject GP) ", con))
                {
                    cmd.Parameters.AddWithValue("EVL", Evl);
                    cmd.Parameters.AddWithValue("id", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable GetEvaluated(string Evl)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable())
            {
                using (SqlCommand cmd = new SqlCommand("select * from [dbo].[group] where id in ( select groupid from GroupEvaluation join Evaluation AS EVL on EVL.Id = GroupEvaluation.EvaluationId where EVL.Name like @EVL) and id in (select gp.GroupId from GroupProject GP)", con))
                {
                    cmd.Parameters.AddWithValue("EVL", Evl);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable SearchEvaluated(string Evl, int id)
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from [dbo].[group] AS G where id in ( select groupid from GroupEvaluation join Evaluation AS EVL on EVL.Id = GroupEvaluation.EvaluationId where EVL.Name like @EVL) and G.id = @id and id in (select gp.GroupId from GroupProject GP) ", con))
                {
                    cmd.Parameters.AddWithValue("EVL", Evl);
                    cmd.Parameters.AddWithValue("id", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static void AssignProject(int Gid,int Pid,DateTime dtime)
        {
            var con = Config.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into GroupProject values(@Pid , @Gid, @Dtime)", con);
            cmd.Parameters.AddWithValue("Gid", Gid);
            cmd.Parameters.AddWithValue("Pid", Pid);
            cmd.Parameters.AddWithValue("Dtime", dtime);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
        }
        public static DataTable getStudentNotInGroup(string str = "")
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand("Select p.id,p.FirstName,p.LastName,s.RegistrationNo,p.Contact,p.Email " +
                    "from student as s " +
                    "join person as p on s.id = p.id " +
                    "join lookup as l on p.gender = l.id " +
                    "where FirstName + LastName + RegistrationNo + Email + l.value + contact like @str and p.id not in ( select GS.studentid from GroupStudent as GS where GS.status = 1)", con))
                {
                    cmd.Parameters.AddWithValue("str", string.Format("%{0}%", str));
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public static DataTable getGroupWithProjects()
        {
            var con = Config.getConnection();
            con.Open();
            using (DataTable dt = new DataTable("Person"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from GroupProject", con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
    }
}
