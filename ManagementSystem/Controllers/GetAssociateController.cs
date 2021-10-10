using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;

namespace ManagementSystem.Controllers
{
    public class GetAssociateController : Controller
    {
        ManagementSystemEntities db = new ManagementSystemEntities();
        // GET: GetAssociate
        public ActionResult Index(string searchloc, string searchtid)
        {
            var associate = from s in db.AssociateDetails
                            select s;

            if (!String.IsNullOrEmpty(searchloc))
            {
                associate = associate.Where(s => s.loc.Contains(searchloc));
            }
            else if (!String.IsNullOrEmpty(searchtid))
            {
                associate = associate.Where(s => s.training_module_id.Contains(searchtid));
            }
            return View(associate.ToList());
        }
    }
}