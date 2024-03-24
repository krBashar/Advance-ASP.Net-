using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_managemnt.Controllers
{
    public class memberController : Controller
    {
        // GET: member
        public ActionResult Index()
        {
            return View();
        }
    }
}