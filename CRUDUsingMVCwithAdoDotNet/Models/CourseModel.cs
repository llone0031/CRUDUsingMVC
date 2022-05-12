using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class CourseModel
    {
        [Display(Name ="Id")]
      
        public int CourseId { get; set; }
        public int CourseNumber { get; set; }
        [Required(ErrorMessage ="Name is required.")]
     
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string  Location { get; set; }
       
    }
}