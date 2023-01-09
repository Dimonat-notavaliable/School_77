using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School_77.Models;

namespace School_77.ViewModels
{
    public class TeacherIndexData
    {
        public IEnumerable<Teacher> Form_tch { get; set; }
        public IEnumerable<Teacher> Subject_tch { get; set; }
    }
}