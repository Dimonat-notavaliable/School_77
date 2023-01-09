using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using School_77.Models;

namespace School_77.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        [Range(1, 5)]
        public int Order { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public DateTime DateDay { get; set; }
        
    }
}