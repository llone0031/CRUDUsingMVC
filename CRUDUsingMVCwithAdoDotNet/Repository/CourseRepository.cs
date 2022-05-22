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
    public class CourseRepository
    {

        private SQLiteConnection con;
        private void connection()
        {
            var connectionStringBuilder = new SQLiteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "C:\\Users\\llone\\OneDrive\\Desktop\\project_Jiazhen\\CRUDUsingMVCwithAdoDotNet\\University.db";
            con = new SQLiteConnection(connectionStringBuilder.ConnectionString);

        }

        public bool AddCourse(CourseModel obj)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"insert into course values({ obj.Name}, { obj.CourseNumber}, { obj.StartTime}, { obj.EndTime}, { obj.Location})";
      
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

        public List<CourseModel> GetAllCourses()
        {
            connection();
            List<CourseModel> list = new List<CourseModel>();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"select * from course";

            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new CourseModel
                    {
                        CourseId = Convert.ToInt32(dr["Id"]),
                        CourseNumber = Convert.ToString(dr["CourseNumber"]),
                        Name = Convert.ToString(dr["Name"]),
                        StartTime = Convert.ToString(dr["StartTime"]),
                        EndTime = Convert.ToString(dr["EndTime"]),
                        Location = Convert.ToString(dr["Location"])
                    }
                    );
            }

            return list;
        }

        public bool UpdateCourse(CourseModel obj)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"Update Course set name = {obj.Name}, email = {obj.StartTime}, address = {obj.EndTime} where id= {obj.Location}";

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
        public bool DeleteCourse(int Id)
        {

            connection();
            var cmd = con.CreateCommand();
            cmd.CommandText = $"Delete from Course where id={Id}";
           
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