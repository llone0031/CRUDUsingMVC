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
    public class ClassRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddClass(ClassModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand($"insert into class values ({obj.Name}, {obj.startTime}, {obj.endTime}, {obj.location})", con);
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

        public List<studentModel> GetAllStudents()
        {
            connection();
            List<studentModel> stuList =new List<studentModel>();
           

            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
          
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                stuList.Add(

                    new studentModel {

                        StudentId = Convert.ToInt32(dr["Id"]),
                        Name =Convert.ToString( dr["Name"]),
                        Email = Convert.ToString( dr["Email"]),
                        Address = Convert.ToString(dr["Address"])

                    }
                    
                    
                    );


            }

            return stuList;


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