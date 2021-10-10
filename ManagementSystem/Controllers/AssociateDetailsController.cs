using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;

namespace ManagementSystem.Controllers
{
    public class AssociateDetailsController : Controller
    {
        private ManagementSystemEntities db = new ManagementSystemEntities();

        // GET: AssociateDetails
        public ActionResult Index()
        {
            var associateDetails = db.AssociateDetails.Include(a => a.BatchDetail);
            return View(associateDetails.ToList());
        }

        // GET: AssociateDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateDetail associateDetail = db.AssociateDetails.Find(id);
            if (associateDetail == null)
            {
                return HttpNotFound();
            }
            return View(associateDetail);
        }

        // GET: AssociateDetails/Create
        public ActionResult Create()
        {
            ViewBag.training_module_id = new SelectList(db.BatchDetails, "training_module_id", "training_module_id");
            return View();
        }

        // POST: AssociateDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "associate_id,associate_name,training_module_id,doj,loc,phno,email")] AssociateDetail associateDetail)
        {
            if (ModelState.IsValid)
            {
                db.AssociateDetails.Add(associateDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.training_module_id = new SelectList(db.BatchDetails, "training_module_id", "training_module_id", associateDetail.training_module_id);
            return View(associateDetail);
        }

        // GET: AssociateDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateDetail associateDetail = db.AssociateDetails.Find(id);
            if (associateDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.training_module_id = new SelectList(db.BatchDetails, "training_module_id", "training_module_id", associateDetail.training_module_id);
            return View(associateDetail);
        }

        // POST: AssociateDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "associate_id,associate_name,training_module_id,doj,loc,phno,email")] AssociateDetail associateDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associateDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.training_module_id = new SelectList(db.BatchDetails, "training_module_id", "training_module_id", associateDetail.training_module_id);
            return View(associateDetail);
        }

        // GET: AssociateDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateDetail associateDetail = db.AssociateDetails.Find(id);
            if (associateDetail == null)
            {
                return HttpNotFound();
            }
            return View(associateDetail);
        }

        // POST: AssociateDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociateDetail associateDetail = db.AssociateDetails.Find(id);
            db.AssociateDetails.Remove(associateDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
