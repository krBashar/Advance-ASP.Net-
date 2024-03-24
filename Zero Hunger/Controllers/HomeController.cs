using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.DTOs;
using System.Data.Entity.ModelConfiguration.Configuration;
using Zero_Hunger.EF;

namespace Zero_Hunger.Controllers
{
    public class HomeController : Controller
    {

        Zero_HungerEntities db = new Zero_HungerEntities();


        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult Login(LoginDTO log)
        {

            var user = (from u in db.users
                        where u.email.Equals(log.email)
                        && u.password.Equals(log.password)
                        select u).SingleOrDefault();
            if (user != null)
            {
                Session["User"] = user;
                if (user.type.Equals("admin"))
                {
                    return RedirectToAction("RequestStatus", "Admin");
                }
                else if (user.type.Equals("restaurant"))
                {
                    return RedirectToAction("reqHistory", "Restaurant");
                }
                else
                {
                    return RedirectToAction("CollectionStatus", "Employee");
                }

            }
            TempData["Msg"] = "Invalid username and password";
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login", "Home");
        }


        [HttpGet]
        public ActionResult Registration()
        {
            return View(new RegistrationDTO());
        }

        [HttpPost]
        public ActionResult Registration(RegistrationDTO reg)
        {
            if (ModelState.IsValid)
            {


                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<RegistrationDTO, user>();
                });

                var mapper = new Mapper(config);
                var data = mapper.Map<user>(reg);

                db.users.Add(data);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            else
            {
                return View(reg);
            }
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}