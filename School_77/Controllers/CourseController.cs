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
    public class CourseController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Course
        public ActionResult Index(int? id)
        {
            var viewModel = new CourseIndexData();
            viewModel.Courses = db.Courses
                .Include(i => i.Teacher)
                .OrderBy(i => i.Title);

            if (id != null)
            {
                ViewBag.CourseID = id.Value;
                viewModel.Students = viewModel.Courses.Where(
                    i => i.ID == id.Value).Single().Students.OrderBy(i => i.LastName);
            }

            return View(viewModel);
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            PopulateTeachersDropDownList(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TeacherID,Title,Branch")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    Teacher teacherToUpdate = db.Teachers.Find(course.TeacherID);
                    teacherToUpdate.CourseID = course.ID;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            ViewBag.TeacherID = new SelectList(db.People, "ID", "LastName", course.TeacherID);
            PopulateTeachersDropDownList(course.ID, course.TeacherID);
            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            PopulateTeachersDropDownList(id, course.TeacherID);
            return View(course);
        }

 
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var courseToUpdate = db.Courses.Find(id);
            if (db.Teachers.Where(i => i.CourseID == id).Any()) 
            {
                Teacher teacherToUpdateOld = db.Teachers.Where(i => i.CourseID == id).Single();
                teacherToUpdateOld.CourseID = null;
            }          
            if (TryUpdateModel(courseToUpdate, "", 
                new string[] { "Title", "Branch", "TeacherID" }))
            {
                try
                {                   
                    db.SaveChanges();
                    courseToUpdate.Teacher.CourseID = id;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateTeachersDropDownList(id, courseToUpdate.TeacherID);
            return View(courseToUpdate);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            course.Teacher.CourseID = null;
            db.Courses.Remove(course);
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
        private void PopulateTeachersDropDownList(int? id, object selectedTeacher = null)
        {
            var teachersQuery = from d in db.Teachers.Where(i => i.Course == null || i.CourseID == id)
                                   orderby d.LastName
                                   select d;
            ViewBag.TeacherID = new SelectList(teachersQuery, "ID", "FullName", selectedTeacher);
        }
    }   
}

