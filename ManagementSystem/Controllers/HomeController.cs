using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;

namespace ManagementSystem.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Login", "AdminDetails");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //Dashboard
            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            //Generating reports
            return View();
        }
    }
}