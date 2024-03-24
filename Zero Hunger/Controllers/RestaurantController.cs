using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.EF;
using Zero_Hunger.Auth;
using AutoMapper;
using Zero_Hunger.DTOs;

namespace Zero_Hunger.Controllers
{
    [Logged]
    public class RestaurantController : Controller
    {

        Zero_HungerEntities db = new Zero_HungerEntities();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult reqHistory()
        {
            var user = Session["User"] as user;
            int userId = user.uid;


            var requestHistory = db.orders
                .Where(o => o.uid == userId) 
                .ToList();

            return View(requestHistory);
        }

        [HttpGet]
        public ActionResult newDonation()
        {
            return View(new newDonationDTO());
        }


        [HttpPost]
        public ActionResult newDonation(newDonationDTO donate)
        {

            donate.status = "pending";
          

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<newDonationDTO, order>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<order>(donate);


            db.orders.Add(data);
            db.SaveChanges();


            return RedirectToAction("reqHistory", "Restaurant");
        }

       




    }
}