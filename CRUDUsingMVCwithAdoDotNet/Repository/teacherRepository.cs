using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CRUDUsingMVC.Models;
namespace CRUDUsingMVC.Repository
{
    public class TeacherRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }


        public bool AddTeacher(TeacherModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand($"insert into student values ({obj.Name}, {obj.Email}, {obj.Address})", con);
            com.CommandType = CommandType.Text;
            //com.CommandType = CommandType.StoredProcedure;
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

        public List<TeacherModel> GetAllTeacher()
        {
            connection();
            List<TeacherModel> list =new List<TeacherModel>();
           

            SqlCommand com = new SqlCommand("select * from teacher", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
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
            SqlCommand com = new SqlCommand($"Update teacher set name = {obj.Name}, email = {obj.Email}, address = {obj.Address} where id= {obj.TeacherId}", con);
           
            com.CommandType = CommandType.Text;
            //com.Parameters.AddWithValue("@StudentId", obj.Empid);
            //com.Parameters.AddWithValue("@Name", obj.Name);
            //com.Parameters.AddWithValue("@City", obj.City);
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
        public bool DeleteTeacher(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand($"Delete from teacher where id={Id}", con);
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