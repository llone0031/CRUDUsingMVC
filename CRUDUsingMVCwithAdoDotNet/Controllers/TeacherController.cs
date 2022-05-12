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
      
       
        // GET: Employee/GetAllEmpDetails
      
        public ActionResult GetAllTeacherDetails()
        {
          
            TeacherRepository tchRepo = new TeacherRepository();
            ModelState.Clear();
            return View(tchRepo.GetAllTeachers());
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(TeacherModel tch)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TeacherRepository EmpRepo = new TeacherRepository();

                    if (EmpRepo.AddTeacher(tch))
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

        // GET: Employee/EditEmpDetails/5
        public ActionResult EditTchDetails(int id)
        {
            TeacherRepository tchRepo = new TeacherRepository();

          

            return View(tchRepo.GetAllTeachers().Find(teacher => teacher.TeacherId == id));

        }

        // POST: Employee/EditEmpDetails/5
        [HttpPost]
      
        public ActionResult EditTchDetails(int id,TeacherModel obj)
        {
            try
            {
                TeacherRepository TchRepo = new TeacherRepository();

                TchRepo.UpdateTeacher(obj);
               



                return RedirectToAction("GetAllTeachers");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteTeacher(int id)
        {
            try
            {
                TeacherRepository EmpRepo = new TeacherRepository();
                if (EmpRepo.DeleteTeacher(id))
                {
                    ViewBag.AlertMsg = "Teacher details deleted successfully";

                }
                return RedirectToAction("GetAllTeachers");

            }
            catch
            {
                return View();
            }
        }

   
    }
}
