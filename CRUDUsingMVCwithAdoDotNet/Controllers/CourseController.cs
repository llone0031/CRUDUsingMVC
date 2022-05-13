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
      
        public ActionResult GetAllCoursesDetails()
        {
          
            CourseRepository clsRepo = new CourseRepository();
            ModelState.Clear();
            return View(clsRepo.GetAllCourses());
        }


        // GET: Course/AddCourse
        public ActionResult AddCourse()
        {
            return View();
        }

        // POST: Course/AddCourse
        [HttpPost]
        public ActionResult AddCourse(CourseModel course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CourseRepository courseRepo = new CourseRepository();

                    if (courseRepo.AddCourse(course))
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

        // GET: Course/EditcourseDetails/5
        public ActionResult EditCourseDetails(int id)
        {
            CourseRepository stuRepo = new CourseRepository();

          

            return View(stuRepo.GetAllCourses().Find(course => course.CourseId == id));

        }

        // POST: Course/EditCourseDetails/5
        [HttpPost]
      
        public ActionResult EditCourseDetails(int id, CourseModel obj)
        {
            try
            {
                CourseRepository CourseRepo = new CourseRepository();

                CourseRepo.UpdateCourse(obj);              

                return RedirectToAction("GetAllCoursesDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/DeleteCourse/5
        public ActionResult DeleteCourse(int id)
        {
            try
            {
                CourseRepository CourseRepo = new CourseRepository();
                if (CourseRepo.DeleteCourse(id))
                {
                    ViewBag.AlertMsg = "Course details deleted successfully";

                }
                return RedirectToAction("GetAllCoursesDetails");

            }
            catch
            {
                return View();
            }
        }

   
    }
}
