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
        [Display(Name = "CourseNumber")]
        public string CourseNumber { get; set; }
        [Required(ErrorMessage ="Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "StartTime")]
        public string StartTime { get; set; }
        [Display(Name = "EndTime")]
        public string EndTime { get; set; }
        [Display(Name = "Location")]
        public string  Location { get; set; }
       
    }
}