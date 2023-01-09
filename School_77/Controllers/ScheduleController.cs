using School_77.Models;
using School_77.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_77.Controllers
{
    public class ScheduleController : Controller
    {
        private SchoolContext db = new SchoolContext();
        // GET: Schedule
        public ActionResult Student(int? id, int? PersonID, string calendar)
        {
            var viewModel = new ScheduleIndexData();
            viewModel.Schedules = db.Schedules;
            if (id != null)
            {
                viewModel.Id = id;
                Person person = db.People.Find(id);
                if (person.GetType().Name.Contains("Parent"))
                {
                    PopulatePersonDropDownList(id, "Parent", viewModel);
                }
                else 
                { 
                    PersonID = id;
                    PopulatePersonDropDownList(id, "Student", viewModel);
                }                
            }
            viewModel.Grades = db.Grades
                .OrderBy(p => p.ID)
                .ToArray();         
            
            FillSchedule(PersonID, "Student", viewModel, calendar);
            return View(viewModel); 
        }

        public ActionResult Teacher(int? id, int? PersonID, string calendar)
        {
            var viewModel = new ScheduleIndexData();
            viewModel.Schedules = db.Schedules;

            if (id != null)
            {
                PersonID = id;
                PopulatePersonDropDownList(id, "Teacher", viewModel);
            }
            
            FillSchedule(PersonID, "Teacher", viewModel, calendar);
            return View(viewModel);
        }
        private void FillSchedule(int? PersonID, string type, ScheduleIndexData viewModel, string calendar)
        {
            if (type == "Student" && PersonID != null)
            {
                int? courseID = db.Students.Find(PersonID).CourseID;
                viewModel.Schedules = viewModel.Schedules.Where(x => x.CourseID == courseID);
                viewModel.Grades = viewModel.Grades.Where(x => x.StudentID == PersonID);
            }

            else if (type == "Teacher" && PersonID != null)
            {
                viewModel.Schedules = viewModel.Schedules.Where(x => x.TeacherID == PersonID);
            }

            if (!String.IsNullOrEmpty(calendar))
            {
                int year = Int32.Parse(calendar.Substring(0, 4));
                int week = Int32.Parse(calendar.Substring(6, 2));
                DateTime Default = new DateTime(2022, 9, 5);

                viewModel.Schedules = viewModel.Schedules.Where(s => s.DateDay >= Default && s.DateDay <= Default.AddDays(5));
                //Понедельник
                if (viewModel.Schedules.Where(s => s.DateDay == Default).Any())
                {
                    viewModel.Monday = viewModel.Schedules.Where(s => s.DateDay == Default);
                }
                //Вторник
                if (viewModel.Schedules.Where(s => s.DateDay == Default.AddDays(1)).Any())
                {
                    viewModel.Tuesday = viewModel.Schedules.Where(s => s.DateDay == Default.AddDays(1));
                }
                //Среда
                if (viewModel.Schedules.Where(s => s.DateDay == Default.AddDays(2)).Any())
                {
                    viewModel.Wednesday = viewModel.Schedules.Where(s => s.DateDay == Default.AddDays(2));
                }
                //Четверг
                if (viewModel.Schedules.Where(s => s.DateDay == Default.AddDays(3)).Any())
                {
                    viewModel.Thursday = viewModel.Schedules.Where(s => s.DateDay == Default.AddDays(3));
                }
                //Пятница
                if (viewModel.Schedules.Where(s => s.DateDay == Default.AddDays(4)).Any())
                {
                    viewModel.Friday = viewModel.Schedules.Where(s => s.DateDay == Default.AddDays(4));
                }
            }
        }
        private void PopulatePersonDropDownList(int? id, string type, ScheduleIndexData viewModel)
        {
            viewModel.Id = id;
            viewModel.PersonType = type;
            Person person = db.People.Find(id);
            if (type == "Parent")
            {
                Parent parent = (Parent) person;
                var PersonQry = from d in parent.Kids
                                    orderby d.LastName
                                    select d;
                ViewBag.PersonID = new SelectList(PersonQry, "ID", "Initials");
            }
            else if (type == "Student")
            {
                var PersonQry = from d in db.Students.Where(x => x.ID == id)
                                    orderby d.LastName
                                    select d;
                ViewBag.PersonID = new SelectList(PersonQry, "ID", "Initials");
            }
            else if (type == "Teacher")
            {
                var PersonQry = from d in db.Teachers.Where(x => x.ID == id)
                                 orderby d.LastName
                                 select d;
                ViewBag.PersonID = new SelectList(PersonQry, "ID", "Initials");
            }
        }
    }
}