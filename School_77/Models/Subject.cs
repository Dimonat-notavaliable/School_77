using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_77.Models
{
    public class Subject
    {
        public int ID { get; set; }
        [Display(Name = "Название предмета")]
        public string Name { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}