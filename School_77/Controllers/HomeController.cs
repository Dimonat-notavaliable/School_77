using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_77.Models;
using School_77.ViewModels;

namespace School_77.Controllers
{
    public class HomeController : Controller
    {
        SchoolContext db = new SchoolContext();
        public ActionResult Index(int? LoginID)
        {
            Person person = null;
            if (LoginID != null)
            {
                person = db.People.Find(LoginID);
            }
            if (LoginID == 0)
            {
                person = db.People.Where(x => x.LastName == "Шушин").Single();        
            }
            return View(person);
        }
    }
}