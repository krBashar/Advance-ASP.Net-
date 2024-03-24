using project_managemnt.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_managemnt.Controllers
{
    public class HomeController : Controller
    {

        project_managementEntities db = new project_managementEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            
                var user = (from u in db.users
                            where u.id.Equals(id)
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    if (user.role.Equals("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                else if(user.role.Equals("Coordinator"))
                {
                    return RedirectToAction("Index", "Coordinator");
                }
                else if (user.role.Equals("Member"))
                {
                    return RedirectToAction("Index", "Member");
                }

                }
                TempData["Msg"] = "Invalid Id";
                return RedirectToAction("Index");

         
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}