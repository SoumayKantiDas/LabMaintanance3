using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabMaintanance3.Models;

namespace LabMaintanance3.Controllers.Admin
{
    public class Repaired_StausController : Controller
    {
        private LabMaintanance4Entities db = new LabMaintanance4Entities();

        // GET: Repaired_Staus
        public ActionResult Index()
        {
            return View(db.Repaired_Staus.ToList());
        }

        // GET: Repaired_Staus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repaired_Staus repaired_Staus = db.Repaired_Staus.Find(id);
            if (repaired_Staus == null)
            {
                return HttpNotFound();
            }
            return View(repaired_Staus);
        }

        // GET: Repaired_Staus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Repaired_Staus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Repaired_StausId,Status")] Repaired_Staus repaired_Staus)
        {
            if (ModelState.IsValid)
            {
                db.Repaired_Staus.Add(repaired_Staus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repaired_Staus);
        }

        // GET: Repaired_Staus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repaired_Staus repaired_Staus = db.Repaired_Staus.Find(id);
            if (repaired_Staus == null)
            {
                return HttpNotFound();
            }
            return View(repaired_Staus);
        }

        // POST: Repaired_Staus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Repaired_StausId,Status")] Repaired_Staus repaired_Staus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repaired_Staus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repaired_Staus);
        }

        // GET: Repaired_Staus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repaired_Staus repaired_Staus = db.Repaired_Staus.Find(id);
            if (repaired_Staus == null)
            {
                return HttpNotFound();
            }
            return View(repaired_Staus);
        }

        // POST: Repaired_Staus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repaired_Staus repaired_Staus = db.Repaired_Staus.Find(id);
            db.Repaired_Staus.Remove(repaired_Staus);
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
