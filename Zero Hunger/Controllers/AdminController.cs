using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Auth;
using Zero_Hunger.DTOs;
using Zero_Hunger.EF;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    [Logged]
    public class AdminController : Controller
    {
        Zero_HungerEntities db = new Zero_HungerEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult UpdateOrderStatus()
        {

            return View();
        }
        [HttpPost]
        public ActionResult UpdateOrderStatus(int oid, string status)
        {

            var order = db.orders.Find(oid);
                if (order != null)
                {
                    order.status = status;
                    db.SaveChanges();
                }
                else
                {
                return RedirectToAction("RequestStatus", "Admin");
            }

            return RedirectToAction("RequestStatus", "Admin");
        }



        [HttpGet]
        public ActionResult RequestStatus()
        {
            return View(db.orders.ToList());
        }

        [HttpGet]
        public ActionResult AssignCollector()
        {
            var viewModel = new OrderViewModel
            {
                Orders = db.orders.ToList(),
                Users = db.users.Where(u => u.type == "employee").ToList(),
                Distributions = db.distributions.ToList()
            };

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult UpdateOrderCollector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateOrderCollector(int oid, int uid)
        {
            var distribution = new distribution
            {
                oid = oid,
                eid = uid,
                status = "pending"
            };
            db.distributions.Add(distribution);
            db.SaveChanges();

            return RedirectToAction("AssignCollector", "Admin");
        }


        [HttpGet]
        public ActionResult DonationHistory()
        {
            var viewModel = new OrderViewModel
            {
                Orders = db.orders.ToList(),
                Users = db.users.ToList(),
                Distributions = db.distributions.ToList()
            };

            return View(viewModel);
        }


    }
}