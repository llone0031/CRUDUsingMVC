using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class StudentModel
    {
        [Display(Name ="Id")]
      
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Name is required.")]
     
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string  Address { get; set; }
       
    }
}