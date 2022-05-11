using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDUsingMVC.Models;
using CRUDUsingMVC.Repository;
namespace CRUDUsingMVC.Controllers
{
   
    public class EmployeeController : Controller
    {
      
       
        // GET: Employee/GetAllEmpDetails
      
        public ActionResult GetAllEmpDetails()
        {
          
            studentRepository EmpRepo = new studentRepository();
            ModelState.Clear();
            return View(EmpRepo.GetAllEmployees());
        }


        // GET: Employee/AddEmployee
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(studentModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentRepository EmpRepo = new studentRepository();

                    if (EmpRepo.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
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
        public ActionResult EditEmpDetails(int id)
        {
            studentRepository stuRepo = new studentRepository();

          

            return View(stuRepo.GetAllEmployees().Find(student => student.StudentId == id));

        }

        // POST: Employee/EditEmpDetails/5
        [HttpPost]
      
        public ActionResult EditEmpDetails(int id,studentModel obj)
        {
            try
            {
                    studentRepository EmpRepo = new studentRepository();
                  
                    EmpRepo.UpdateEmployee(obj);
               



                return RedirectToAction("GetAllEmpDetails");
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
                studentRepository EmpRepo = new studentRepository();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }

   
    }
}
