using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsingMVC.Models
{
    public class ClassModel
    {
        [Display(Name ="Id")]
      
        public int ClassId { get; set; }
        [Required(ErrorMessage ="Name is required.")]
     
        public string Name { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string  location { get; set; }
       
    }
}