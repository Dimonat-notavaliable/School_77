using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using School_77.Models;
using School_77.ViewModels;

namespace School_77.Controllers
{
    public class GradesController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Grades
        [Obsolete]
        public ActionResult Index(int? id, int? SubjectID, string month, int? CourseID = 1)
        {
            
            var viewModel = new GradeIndexData();
            viewModel.TeacherID = id;
            viewModel.Grades = db.Grades.ToArray();
            PopulateCoursesDropDownList(id, db.Courses.Find(CourseID));
            PopulateSubjectsDropDownList(id, CourseID);

            var students = from m in db.Students
                           select m;
            DateTime Default = new DateTime(2022, 9, 5);
            if (CourseID != null && db.Schedules.Where(x => x.CourseID == CourseID && x.SubjectID == SubjectID).Any())
            {               
                viewModel.Students = students.Where(x => x.CourseID == CourseID).OrderBy(s => s.LastName);
                var NeedSchedules = db.Schedules.Where(x => x.CourseID == CourseID && x.SubjectID == SubjectID);
                //Понедельник
                viewModel.Monday = NeedSchedules.Where(x => x.DateDay == Default);
                //Вторник
                viewModel.Tuesday = NeedSchedules.Where(x => x.DateDay == EntityFunctions.AddDays(Default, 1));
                //Среда
                viewModel.Wednesday = NeedSchedules.Where(x => x.DateDay == EntityFunctions.AddDays(Default, 2));
                //Четверг
                viewModel.Thursday = NeedSchedules.Where(x => x.DateDay == EntityFunctions.AddDays(Default, 3));
                //Пятница
                viewModel.Friday = NeedSchedules.Where(x => x.DateDay == EntityFunctions.AddDays(Default, 4));
            }
            else {
                viewModel.Students = null;
                viewModel.Monday = new List<Schedule>();
                //Вторник
                viewModel.Tuesday = new List<Schedule>();
                //Среда
                viewModel.Wednesday = new List<Schedule>();
                //Четверг
                viewModel.Thursday = new List<Schedule>();
                //Пятница
                viewModel.Friday = new List<Schedule>();
            }

            if (SubjectID != null)
            {
                viewModel.Grades = viewModel.Grades.Where(x => x.SubjectID == SubjectID);
                PopulateSubjectsDropDownList(id, CourseID, db.Subjects.Find(SubjectID));
            }

            return View(viewModel);
        }

        [HttpPost]   
        public ActionResult Create(int studentID, int subjectID, int value, DateTime date)
        {
            Grade grade = new Grade { StudentID = studentID, SubjectID = subjectID, Value = value, Date = date };
            db.Grades.Add(grade);
            db.SaveChanges();
            int? course = db.Students.Find(studentID).CourseID;
            string monthRedirect = date.Year + "-" + date.Month;
            if (date.Month < 10) { monthRedirect = date.Year + "-0" + date.Month; }
            return RedirectToAction("Index", new { CourseID=course, SubjectID=subjectID, month= monthRedirect });
        }

        [HttpPost]
        public ActionResult Edit(int ID, int value)
        {
            Grade grade = db.Grades.Find(ID);

            string monthRedirect = grade.Date.Year + "-" + grade.Date.Month;
            if (grade.Date.Month < 10) { monthRedirect = grade.Date.Year + "-0" + grade.Date.Month; }
            int? courseRedirect = grade.Student.CourseID;
            int? subjectRedirect = grade.SubjectID;

            if (value != grade.Value)
            {
                if (value == 0)
                {
                    db.Grades.Remove(grade);
                }
                else
                {
                    grade.Value = value;                   
                }
                db.SaveChanges();
            }           
            return RedirectToAction("Index", new { CourseID = courseRedirect, SubjectID = subjectRedirect, month = monthRedirect });
        }

        private void PopulateCoursesDropDownList(int? TeacherID, object selectedCourse = null)
        {
            var CourseQuery = from d in db.Courses
                            orderby d.Title
                            select d;
            if (TeacherID != null) 
            {
                var CourseLst = from d in db.Schedules.Where(item => item.TeacherID == TeacherID)
                                 select d.Course;
                CourseQuery = CourseLst.Distinct().OrderBy(x => x.Title);
            }
            List<SelectListItem> MyCourseList = new List<SelectListItem>();
            MyCourseList.AddRange(new SelectList(CourseQuery, "ID", "Title", selectedCourse));
            MyCourseList.Insert(0, new SelectListItem { Text = "", Value = "" });
            ViewBag.CourseID = MyCourseList;
        }
        private void PopulateSubjectsDropDownList(int? TeacherID, int? courseID, object selectedSubject = null)
        {
            var SubjectLst = from d in db.Subjects.Where(item => item.ID == null)
                             orderby d.Name
                             select d;
            if (courseID != null)
            {
                var ScheduleQuery = from d in db.Schedules.Where(x => x.CourseID == courseID)
                                   select d;
                if (TeacherID != null) 
                {
                    ScheduleQuery = ScheduleQuery.Where(k => k.TeacherID == TeacherID);
                }
                var SubjectQuery = from d in ScheduleQuery
                                   select d.Subject;
                SubjectLst = SubjectQuery.Distinct().OrderBy(d => d.Name);
                
            }
            if (TeacherID != null) 
            {
                
            }
            SubjectLst.Append(new Subject { ID = 50, Name = "--Выберите--" });
            ViewBag.SubjectID = new SelectList(SubjectLst, "ID", "Name", selectedSubject);
        }
    }
}