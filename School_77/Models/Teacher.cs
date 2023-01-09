using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_77.Models
{
    public class Teacher : Person
    {
        public int? CourseID { get; set; }
        [Display(Name = "Класс")]
        public virtual Course Course { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}