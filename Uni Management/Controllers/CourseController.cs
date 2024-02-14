using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uni_Management.EF;

namespace Uni_Management.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        [HttpGet]
        public ActionResult CourseForm()
        {
            return View(new Cours());
        }
        [HttpPost]
        public ActionResult CourseForm(Cours p)
        {
            if (ModelState.IsValid)
            { //checking the rules imposed in Person class
                //TempData["Msg"] = "Form is valid";
                var db = new UniEntities();
                db.Courses.Add(p);
                db.SaveChanges();
                return RedirectToAction("List1");
            }
            return View(p);
        }


        public ActionResult List1()
        {
            var db = new UniEntities();

            var users = (from st in db.Courses
                         where st.Id >= 1 && st.Id <= 20
                         select st).ToList();

            //var users = db.Users.ToList();
            return View(users);
        }

    }
}