using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School_77.Models;

namespace School_77.ViewModels
{
    public class CourseIndexData
    {
        public IEnumerable<Course> Courses { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}