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
    public class StudentRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddStudent(StudentModel obj)
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

        public List<StudentModel> GetAllStudents()
        {
            connection();
            List<StudentModel> list =new List<StudentModel>();


            SqlCommand com = new SqlCommand("select * from student", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
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

        public bool UpdateEmployee(studentModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);
           
            com.CommandType = CommandType.StoredProcedure;
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
        public bool DeleteStudent(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);
           
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