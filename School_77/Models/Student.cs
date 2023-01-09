using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace School_77.Models
{
    public class Student : Person
    {
        public int? CourseID { get; set; }
        [Display(Name = "Класс")]
        public virtual Course Course { get; set; }

    }
}