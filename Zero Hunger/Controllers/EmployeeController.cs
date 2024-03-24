using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Auth;
using Zero_Hunger.EF;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    [Logged]
    public class EmployeeController : Controller
    {
        Zero_HungerEntities db = new Zero_HungerEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        /*[HttpGet]
        public ActionResult CollectionStatus()
        {
            return View(db.orders.ToList());
        }*/

        [HttpGet]
        public ActionResult CollectionStatus()
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
        public ActionResult UpdateDistributionStatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateDistributionStatus(int did, string status)
        {
            var distribution = db.distributions.Find(did);
            if (distribution != null)
            {
                distribution.status = status;
                db.SaveChanges();
            }
            return RedirectToAction("CollectionStatus", "Employee");
        }
    }
}