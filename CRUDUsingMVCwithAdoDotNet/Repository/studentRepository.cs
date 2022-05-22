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
    public class StudentRepository
    {
        private SQLiteConnection con;
        private void connection()
        {
            var connectionStringBuilder = new SQLiteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:\\Users\\llone\\OneDrive\\Desktop\\project_Jiazhen\\CRUDUsingMVCwithAdoDotNet\\University.db";
            con = new SQLiteConnection(connectionStringBuilder.ConnectionString);
        }

        public bool AddStudent(StudentModel obj)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"insert into student values ({obj.Name}, {obj.Email}, {obj.Address})";

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

        public List<StudentModel> GetAllStudents()
        {
            connection();
            List<StudentModel> list =new List<StudentModel>();

            var cmd = con.CreateCommand();
            cmd.CommandText = $"select * from student";

            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new StudentModel
                    {
                        StudentId = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
                        Address = Convert.ToString(dr["Address"])
                    }
                    );
            }

            return list;


        }

        public bool UpdateStudent(StudentModel obj)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"Update student set name = {obj.Name}, email = {obj.Email}, address = {obj.Address} where id= {obj.StudentId}";

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
        public bool DeleteStudent(int Id)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"Delete from Student where id={Id}";

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