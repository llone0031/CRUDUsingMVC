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


        // GET: Student/GetAllStudentDetails

        public ActionResult GetAllStudentDetails()
        {
          
            StudentRepository StudentRepo = new StudentRepository();
            ModelState.Clear();
            return View(StudentRepo.GetAllStudents());
        }


        // GET: Student/AddStudent
        public ActionResult AddStudent()
        {
            return View();
        }

        // POST: Student/AddStudent
        [HttpPost]
        public ActionResult AddStudent(StudentModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentRepository studentRepo = new StudentRepository();

                    if (studentRepo.AddStudent(student))
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

        // GET: Student/EditStudentDetails/5
        public ActionResult EditStudentDetails(int id)
        {
            StudentRepository stuRepo = new StudentRepository();

          

            return View(stuRepo.GetAllStudents().Find(student => student.StudentId == id));

        }

        // POST: Student/EditStudentDetails/5
        [HttpPost]
      
        public ActionResult EditStudentDetails(int id,StudentModel obj)
        {
            try
            {
                StudentRepository studentRepo = new StudentRepository();

                studentRepo.UpdateStudent(obj);

                return RedirectToAction("GetAllStudentDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/DeleteStudent/5
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                StudentRepository studentRepo = new StudentRepository();
                if (studentRepo.DeleteStudent(id))
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
