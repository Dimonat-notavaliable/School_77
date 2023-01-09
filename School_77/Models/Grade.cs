using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_77.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; }
        [Range(1, 5)]
        public int Value { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}