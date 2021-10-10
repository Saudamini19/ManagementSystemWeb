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
    public class TrainerDetailsController : Controller
    {
        private ManagementSystemEntities db = new ManagementSystemEntities();

        // GET: TrainerDetails
        public ActionResult Index()
        {
            var trainerDetails = db.TrainerDetails.Include(t => t.BatchDetail);
            return View(trainerDetails.ToList());
        }

        // GET: TrainerDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerDetail trainerDetail = db.TrainerDetails.Find(id);
            if (trainerDetail == null)
            {
                return HttpNotFound();
            }
            return View(trainerDetail);
        }

        // GET: TrainerDetails/Create
        public ActionResult Create()
        {
            ViewBag.training_module_id = new SelectList(db.BatchDetails, "training_module_id", "training_module_id");
            return View();
        }

        // POST: TrainerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trainer_id,trainer_name,training_module_id,business_unit_name,phno,email")] TrainerDetail trainerDetail)
        {
            if (ModelState.IsValid)
            {
                db.TrainerDetails.Add(trainerDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.training_module_id = new SelectList(db.BatchDetails, "training_module_id", "training_module_id", trainerDetail.training_module_id);
            return View(trainerDetail);
        }

        // GET: TrainerDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerDetail trainerDetail = db.TrainerDetails.Find(id);
            if (trainerDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.training_module_id = new SelectList(db.BatchDetails, "training_module_id", "training_module_id", trainerDetail.training_module_id);
            return View(trainerDetail);
        }

        // POST: TrainerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trainer_id,trainer_name,training_module_id,business_unit_name,phno,email")] TrainerDetail trainerDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.training_module_id = new SelectList(db.BatchDetails, "training_module_id", "training_module_id", trainerDetail.training_module_id);
            return View(trainerDetail);
        }

        // GET: TrainerDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerDetail trainerDetail = db.TrainerDetails.Find(id);
            if (trainerDetail == null)
            {
                return HttpNotFound();
            }
            return View(trainerDetail);
        }

        // POST: TrainerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerDetail trainerDetail = db.TrainerDetails.Find(id);
            db.TrainerDetails.Remove(trainerDetail);
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
