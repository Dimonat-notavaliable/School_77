using School_77.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_77.Models
{
    public class Course
    {
        public int ID { get; set; }
        public int? TeacherID { get; set; }
        [Required, StringLength(3, MinimumLength = 2)]
        [Display(Name = "Класс")]
        public string Title { get; set; }
        [Display(Name = "Специализация")]
        public string Branch { get; set; }
        [Display(Name = "Классный руководитель")]
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}