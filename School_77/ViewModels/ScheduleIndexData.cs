using School_77.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_77.ViewModels
{
    public class ScheduleIndexData
    {
        public int? Id { get; set; }
        public string PersonType { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<Schedule> Monday { get; set; }
        public IEnumerable<Schedule> Tuesday { get; set; }
        public IEnumerable<Schedule> Wednesday { get; set; }
        public IEnumerable<Schedule> Thursday { get; set; }
        public IEnumerable<Schedule> Friday { get; set; }
        public IEnumerable<Schedule> Saturday { get; set; }
    }
}