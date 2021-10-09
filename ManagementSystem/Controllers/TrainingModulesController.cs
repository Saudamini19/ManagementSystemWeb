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
    public class TrainingModulesController : Controller
    {
        private ManagementSystemEntities db = new ManagementSystemEntities();

        // GET: TrainingModules
        public ActionResult Index()
        {
            return View(db.TrainingModules.ToList());
        }

        // GET: TrainingModules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingModule trainingModule = db.TrainingModules.Find(id);
            if (trainingModule == null)
            {
                return HttpNotFound();
            }
            return View(trainingModule);
        }

        // GET: TrainingModules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "business_unit_id,business_unit_name")] TrainingModule trainingModule)
        {
            if (ModelState.IsValid)
            {
                db.TrainingModules.Add(trainingModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingModule);
        }

        // GET: TrainingModules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingModule trainingModule = db.TrainingModules.Find(id);
            if (trainingModule == null)
            {
                return HttpNotFound();
            }
            return View(trainingModule);
        }

        // POST: TrainingModules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "business_unit_id,business_unit_name")] TrainingModule trainingModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingModule);
        }

        // GET: TrainingModules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingModule trainingModule = db.TrainingModules.Find(id);
            if (trainingModule == null)
            {
                return HttpNotFound();
            }
            return View(trainingModule);
        }

        // POST: TrainingModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingModule trainingModule = db.TrainingModules.Find(id);
            db.TrainingModules.Remove(trainingModule);
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
