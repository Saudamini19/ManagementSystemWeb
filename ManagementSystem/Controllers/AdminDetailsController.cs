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
    public class AdminDetailsController : Controller
    {
        private ManagementSystemEntities db = new ManagementSystemEntities();

        // GET: AdminDetails

        public ActionResult Login()
        {
            login obk = new login();
            return View(obk);
        }
        [HttpPost]
        public ActionResult Login(login obk)
        {
            if (ModelState.IsValid)
            {
                ManagementSystemEntities obj = new ManagementSystemEntities();
                if (obj.AdminDetails.Where(m => m.uerName == obk.userName && m.passTxt == obk.password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Incorrect Username or Password");
                    return View();
                }
                else
                {
                    Session["userid"] = obk.userName;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Index()
        {
            return View(db.AdminDetails.ToList());
        }

        // GET: AdminDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminDetail adminDetail = db.AdminDetails.Find(id);
            if (adminDetail == null)
            {
                return HttpNotFound();
            }
            return View(adminDetail);
        }

        // GET: AdminDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "uerName,passTxt")] AdminDetail adminDetail)
        {
            if (ModelState.IsValid)
            {
                db.AdminDetails.Add(adminDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminDetail);
        }

        // GET: AdminDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminDetail adminDetail = db.AdminDetails.Find(id);
            if (adminDetail == null)
            {
                return HttpNotFound();
            }
            return View(adminDetail);
        }

        // POST: AdminDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "uerName,passTxt")] AdminDetail adminDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminDetail);
        }

        // GET: AdminDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminDetail adminDetail = db.AdminDetails.Find(id);
            if (adminDetail == null)
            {
                return HttpNotFound();
            }
            return View(adminDetail);
        }

        // POST: AdminDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdminDetail adminDetail = db.AdminDetails.Find(id);
            db.AdminDetails.Remove(adminDetail);
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
