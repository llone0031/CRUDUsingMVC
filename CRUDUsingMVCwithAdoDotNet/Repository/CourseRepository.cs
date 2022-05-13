using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using University.Models;
namespace University.Repository
{
    public class CourseRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddCourse(CourseModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand($"insert into course values ({obj.Name}, {obj.CourseNumber}, {obj.StartTime}, {obj.EndTime}, {obj.Location})", con);
            com.CommandType = CommandType.Text;
            //com.Parameters.AddWithValue("@Name", obj.Name);
            //com.Parameters.AddWithValue("@City", obj.Email);
            //com.Parameters.AddWithValue("@Address", obj.Address);
          
            con.Open();
            int i = com.ExecuteNonQuery();
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


            SqlCommand com = new SqlCommand("select * from course", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
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
            SqlCommand com = new SqlCommand($"Update Course set name = {obj.Name}, email = {obj.StartTime}, address = {obj.EndTime} where id= {obj.Location}", con);

            com.CommandType = CommandType.StoredProcedure;
            con.Open();
            int i = com.ExecuteNonQuery();
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
            SqlCommand com = new SqlCommand($"Delete from Course where id={Id}", con);

            com.CommandType = CommandType.Text;
           
            con.Open();
            int i = com.ExecuteNonQuery();
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