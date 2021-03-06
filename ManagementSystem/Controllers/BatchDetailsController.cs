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
    public class BatchDetailsController : Controller
    {
        private ManagementSystemEntities db = new ManagementSystemEntities();

        // GET: BatchDetails
        public ActionResult Index()
        {
            var batchDetails = db.BatchDetails.Include(b => b.TrainingModule);
            return View(batchDetails.ToList());
        }

        // GET: BatchDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchDetail batchDetail = db.BatchDetails.Find(id);
            if (batchDetail == null)
            {
                return HttpNotFound();
            }
            return View(batchDetail);
        }

        // GET: BatchDetails/Create
        public ActionResult Create()
        {
            ViewBag.business_unit_id = new SelectList(db.TrainingModules, "business_unit_id", "business_unit_name");
            return View();
        }

        // POST: BatchDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "training_module_id,business_unit_id,startdate,enddate")] BatchDetail batchDetail)
        {
            if (ModelState.IsValid)
            {
                db.BatchDetails.Add(batchDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.business_unit_id = new SelectList(db.TrainingModules, "business_unit_id", "business_unit_name", batchDetail.business_unit_id);
            return View(batchDetail);
        }

        // GET: BatchDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchDetail batchDetail = db.BatchDetails.Find(id);
            if (batchDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.business_unit_id = new SelectList(db.TrainingModules, "business_unit_id", "business_unit_name", batchDetail.business_unit_id);
            return View(batchDetail);
        }

        // POST: BatchDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "training_module_id,business_unit_id,startdate,enddate")] BatchDetail batchDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batchDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.business_unit_id = new SelectList(db.TrainingModules, "business_unit_id", "business_unit_name", batchDetail.business_unit_id);
            return View(batchDetail);
        }

        // GET: BatchDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BatchDetail batchDetail = db.BatchDetails.Find(id);
            if (batchDetail == null)
            {
                return HttpNotFound();
            }
            return View(batchDetail);
        }

        // POST: BatchDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BatchDetail batchDetail = db.BatchDetails.Find(id);
            db.BatchDetails.Remove(batchDetail);
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
