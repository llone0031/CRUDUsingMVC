using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;
using University.Repository;
namespace University.Controllers
{
   
    public class TeacherController : Controller
    {


        // GET: Teacher/GetAllTeacherDetails

        public ActionResult GetAllTeacherDetails()
        {
          
            TeacherRepository TeacherRepo = new TeacherRepository();
            ModelState.Clear();
            return View(TeacherRepo.GetAllTeachers());
        }

        // POST: Teacher/AddTeacher
        [HttpPost]
        public ActionResult AddTeacher(TeacherModel teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TeacherRepository teacherRepo = new TeacherRepository();

                    if (teacherRepo.AddTeacher(teacher))
                    {
                        ViewBag.Message = "Teacher details added successfully";
                    }
                }
              
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/EditTeacherDetails/5
        public ActionResult EditTeacherDetails(int id)
        {
            TeacherRepository teacherRepo = new TeacherRepository();

          

            return View(teacherRepo.GetAllTeachers().Find(teacher => teacher.TeacherId == id));

        }

        // POST: Teacher/EditTeacherDetails/5
        [HttpPost]
      
        public ActionResult EditTeacherDetails(int id,TeacherModel obj)
        {
            try
            {
                TeacherRepository teacherRepo = new TeacherRepository();

                teacherRepo.UpdateTeacher(obj);
               



                return RedirectToAction("GetAllTeacherDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET:  Teacher/DeleteTeacher/5
        public ActionResult DeleteTeacher(int id)
        {
            try
            {
                TeacherRepository teacherRepo = new TeacherRepository();
                if (teacherRepo.DeleteTeacher(id))
                {
                    ViewBag.AlertMsg = "Teacher details deleted successfully";

                }
                return RedirectToAction("GetAllTeacherDetails");

            }
            catch
            {
                return View();
            }
        }

   
    }
}
