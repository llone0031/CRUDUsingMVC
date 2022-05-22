using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using University.Models;
namespace University.Repository
{
    public class TeacherRepository
    {
        private SQLiteConnection con;
        private void connection()
        {
            var connectionStringBuilder = new SQLiteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:\\Users\\llone\\OneDrive\\Desktop\\project_Jiazhen\\CRUDUsingMVCwithAdoDotNet\\University.db";
            con = new SQLiteConnection(connectionStringBuilder.ConnectionString);

        }


        public bool AddTeacher(TeacherModel obj)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"insert into teacher values ({obj.Name}, {obj.Email}, {obj.Address})";

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<TeacherModel> GetAllTeachers()
        {
            connection();
            List<TeacherModel> list =new List<TeacherModel>();


            var cmd = con.CreateCommand();
            cmd.CommandText = $"select * from teacher";

            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new TeacherModel {
                        TeacherId = Convert.ToInt32(dr["Id"]),
                        Name =Convert.ToString( dr["Name"]),
                        Email = Convert.ToString( dr["Email"]),
                        Address = Convert.ToString(dr["Address"])
                    }                
                    );
            }

            return list;
        }

        public bool UpdateTeacher(TeacherModel obj)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"Update student set name = {obj.Name}, email = {obj.Email}, address = {obj.Address} where id= {obj.TeacherId}";

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {       
                return true;
            }
            else
            {
                return false;
            }


        }
        public bool DeleteTeacher(int Id)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"Delete from Teacher where id={Id}";

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {              
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}