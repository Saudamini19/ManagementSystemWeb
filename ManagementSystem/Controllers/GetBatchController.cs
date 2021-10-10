using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;

namespace ManagementSystem.Controllers
{
    public class GetBatchController : Controller
    {
        ManagementSystemEntities ob = new ManagementSystemEntities();
        // GET: GetBatch
        public ActionResult Index(string searchbnam)
        {
            var deets = from s in ob.AllDetails
                            select s;

            if (!String.IsNullOrEmpty(searchbnam))
            {
                deets = deets.Where(s => s.business_unit_name.Contains(searchbnam));
            }
            return View(deets.ToList());
        }
    }
}