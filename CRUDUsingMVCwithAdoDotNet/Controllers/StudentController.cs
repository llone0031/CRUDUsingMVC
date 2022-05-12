using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;
using University.Repository;
namespace University.Controllers
{
   
    public class StudentController : Controller
    {
      
       
        // GET: Employee/GetAllEmpDetails
      
        public ActionResult GetAllStudentDetails()
        {
          
            StudentRepository EmpRepo = new StudentRepository();
            ModelState.Clear();
            return View(EmpRepo.GetAllStudents());
        }


        // GET: Employee/AddEmployee
        public ActionResult AddStudent()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddStudent(StudentModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentRepository EmpRepo = new StudentRepository();

                    if (EmpRepo.AddStudent(Emp))
                    {
                        ViewBag.Message = "Student details added successfully";
                    }
                }
              
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/EditEmpDetails/5
        public ActionResult EditStudentDetails(int id)
        {
            StudentRepository stuRepo = new StudentRepository();

          

            return View(stuRepo.GetAllStudents().Find(student => student.StudentId == id));

        }

        // POST: Employee/EditEmpDetails/5
        [HttpPost]
      
        public ActionResult EditStudentDetails(int id,StudentModel obj)
        {
            try
            {
                    StudentRepository EmpRepo = new StudentRepository();
                  
                    EmpRepo.UpdateEmployee(obj);
               



                return RedirectToAction("GetAllStudentDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                StudentRepository EmpRepo = new StudentRepository();
                if (EmpRepo.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student details deleted successfully";

                }
                return RedirectToAction("GetAllStudentDetails");

            }
            catch
            {
                return View();
            }
        }

   
    }
}
