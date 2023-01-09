using School_77.Models;
using System.Collections.Generic;

namespace School_77.ViewModels
{
    public class GradeIndexData
    {
        public int? TeacherID { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Schedule> Monday { get; set; }
        public IEnumerable<Schedule> Tuesday { get; set; }
        public IEnumerable<Schedule> Wednesday { get; set; }
        public IEnumerable<Schedule> Thursday { get; set; }
        public IEnumerable<Schedule> Friday { get; set; }
    }
}