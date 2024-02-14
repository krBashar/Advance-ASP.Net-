using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uni_Management.EF;

namespace Uni_Management.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Course
        [HttpGet]
        public ActionResult DepartmentForm()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult DepartmentForm(Department p)
        {
            if (ModelState.IsValid)
            { //checking the rules imposed in Person class
                //TempData["Msg"] = "Form is valid";
                var db = new UniEntities();
                db.Departments.Add(p);
                db.SaveChanges();
                return RedirectToAction("List3");
            }
            return View(p);
        }


        public ActionResult List3()
        {
            var db = new UniEntities();

            var users = (from st in db.Departments
                         where st.Id >= 300 && st.Id <= 400
                         select st).ToList();

            //var users = db.Users.ToList();
            return View(users);
        }

    }
}