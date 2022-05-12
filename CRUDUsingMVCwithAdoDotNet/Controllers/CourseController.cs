using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;
using University.Repository;
namespace University.Controllers
{
   
    public class CourseController : Controller
    {
      
        public ActionResult GetAllCourses()
        {
          
            CourseRepository clsRepo = new CourseRepository();
            ModelState.Clear();
            return View(clsRepo.GetAllCourses());
        }


        // GET: Employee/AddEmployee
        public ActionResult AddCourse()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddCourse(CourseModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CourseRepository EmpRepo = new CourseRepository();

                    if (EmpRepo.AddCourse(Emp))
                    {
                        ViewBag.Message = "Course details added successfully";
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
        public ActionResult EditCourseDetails(int id)
        {
            CourseRepository stuRepo = new CourseRepository();

          

            return View(stuRepo.GetAllCourses().Find(course => course.CourseId == id));

        }

        // POST: Employee/EditEmpDetails/5
        [HttpPost]
      
        public ActionResult EditCourseDetails(int id,CourseModel obj)
        {
            try
            {
                    CourseRepository EmpRepo = new CourseRepository();
                  
                    EmpRepo.UpdateCourse(obj);              

                return RedirectToAction("GetAllCourses");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteCourse(int id)
        {
            try
            {
                CourseRepository EmpRepo = new CourseRepository();
                if (EmpRepo.DeleteCourse(id))
                {
                    ViewBag.AlertMsg = "Course details deleted successfully";

                }
                return RedirectToAction("GetAllCourses");

            }
            catch
            {
                return View();
            }
        }

   
    }
}
