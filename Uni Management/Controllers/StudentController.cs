using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uni_Management.EF;

namespace Uni_Management.Controllers
{
    public class StudentController : Controller
    {
        // GET: Course
        [HttpGet]
        public ActionResult StudentForm()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult StudentForm(Student p)
        {
            if (ModelState.IsValid)
            { //checking the rules imposed in Person class
                //TempData["Msg"] = "Form is valid";
                var db = new UniEntities();
                db.Students.Add(p);
                db.SaveChanges();
                return RedirectToAction("List2");
            }
            return View(p);
        }


        public ActionResult List2()
        {
            var db = new UniEntities();

            var users = (from st in db.Students
                         where st.Id >= 200 && st.Id <= 300
                         select st).ToList();

            //var users = db.Users.ToList();
            return View(users);
        }

    }
}