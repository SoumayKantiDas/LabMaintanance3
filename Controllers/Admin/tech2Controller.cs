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
    public class tech2Controller : Controller
    {
        private LabMaintanance4Entities db = new LabMaintanance4Entities();

        // GET: tech2
        public ActionResult Index()
        {
            var tech2 = db.tech2.Include(t => t.Complain);
            return View(tech2.ToList());
        }

        // GET: tech2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tech2 tech2 = db.tech2.Find(id);
            if (tech2 == null)
            {
                return HttpNotFound();
            }
            return View(tech2);
        }

        // GET: tech2/Create
        public ActionResult Create(int id)
        {
            ViewBag.SelectedComplainId = id;

            return View();
        }

        // POST: tech2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "action_id,complain_id,technicianName,action_description,action_date")] tech2 tech2, int id)
        {
            if (ModelState.IsValid)
            {
                tech2.complain_id = id;
                db.tech2.Add(tech2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.complain_id = new SelectList(db.Complains, "complain_id", "Name_Of_the_Item", tech2.complain_id);
            return View(tech2);
        }

        // GET: tech2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tech2 tech2 = db.tech2.Find(id);
            if (tech2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.complain_id = new SelectList(db.Complains, "complain_id", "Name_Of_the_Item", tech2.complain_id);
            return View(tech2);
        }

        // POST: tech2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "action_id,complain_id,technicianName,action_description,action_date")] tech2 tech2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tech2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.complain_id = new SelectList(db.Complains, "complain_id", "Name_Of_the_Item", tech2.complain_id);
            return View(tech2);
        }

        // GET: tech2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tech2 tech2 = db.tech2.Find(id);
            if (tech2 == null)
            {
                return HttpNotFound();
            }
            return View(tech2);
        }

        // POST: tech2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tech2 tech2 = db.tech2.Find(id);
            db.tech2.Remove(tech2);
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
