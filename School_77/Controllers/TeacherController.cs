using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School_77.Models;
using School_77.ViewModels;

namespace School_77.Controllers
{
    public class TeacherController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Teacher
        public ActionResult Index()
        {
            var viewModel = new TeacherIndexData();
            viewModel.Form_tch = db.Teachers.Where(t => t.CourseID != null).OrderBy(e => e.LastName).ToList();
            viewModel.Subject_tch = db.Teachers.Where(t => t.CourseID == null).OrderBy(e => e.LastName).ToList();
            return View(viewModel);
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            PopulateCoursesDropDownList();
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,Patronymic,CourseID")] Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.People.Add(teacher);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator."); 
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", teacher.CourseID);
            PopulateCoursesDropDownList(teacher.ID, teacher.CourseID);
            return View(teacher);
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            PopulateCoursesDropDownList(id, teacher.CourseID);
            return View(teacher);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacherToUpdate = db.Teachers.Find(id);
            if (db.Courses.Where(i => i.TeacherID == id).Any())
            {
                Course courseToUpdateOld = db.Courses.Where(i => i.TeacherID == id).Single();
                courseToUpdateOld.TeacherID = null;
            }
            if (TryUpdateModel(teacherToUpdate, "",
                            new string[] { "LastName", "FirstName", "Patronymic", "CourseID" }))
            {
                try
                {
                    db.SaveChanges();
                    if (teacherToUpdate.Course != null) 
                    {
                        teacherToUpdate.Course.TeacherID = id;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes." +
                        " Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateCoursesDropDownList(id, teacherToUpdate.CourseID);
            return View(teacherToUpdate);
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {           
            Teacher teacher = db.Teachers.Find(id);
            if (teacher.Course != null)
            {
                teacher.Course.TeacherID = null;
            }
            db.People.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void PopulateCoursesDropDownList(int? id = null, object selectedCourse = null)
        {
            var coursesQuery = from d in db.Courses.Where(i => i.Teacher == null || i.TeacherID == id)
                                orderby d.Title
                                select d;
            ViewBag.CourseID = new SelectList(coursesQuery, "ID", "Title", selectedCourse);
        }
    }
}
