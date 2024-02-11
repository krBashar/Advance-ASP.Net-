using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment1.Models;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Info()
        {
            return View(new Users());
        }
        [HttpPost]
        public ActionResult Info(Users p)
        {
            if (ModelState.IsValid)
            { //checking the rules imposed in Person class
                if (!p.IsEmailMatchingId())
                {
                    ModelState.AddModelError("Email", "Email does not match the ID.");
                    return View(p);
                }
                return RedirectToAction("Info", "HomeController");
            }

            return View(p);
        }


    }
}
