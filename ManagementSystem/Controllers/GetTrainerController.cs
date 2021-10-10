using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;


namespace ManagementSystem.Controllers
{
    public class GetTrainerController : Controller
    {
        ManagementSystemEntities ob = new ManagementSystemEntities();
        // GET: GetTrainer
        public ActionResult Index(string searching)
        {
            var deets = from s in ob.TrainerDetails
                        where s.training_module_id==null
                        select s;
            return View(deets.ToList());
        }
    }
}

