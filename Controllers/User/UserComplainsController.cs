using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabMaintanance3.Models;

namespace LabMaintanance3.Controllers.User
{
    public class UserComplainsController : Controller
    {
        private LabMaintanance4Entities db = new LabMaintanance4Entities();

        // GET: UserComplains
        public ActionResult Index()
        {
            var complains = db.Complains.Include(c => c.AllUser).Include(c => c.Priority).Include(c => c.Repaired_Staus);
            return View(complains.ToList());
        }

        // GET: UserComplains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // GET: UserComplains/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.AllUsers, "user_id", "username");
            ViewBag.PriorityId = new SelectList(db.Priorities, "PriorityId", "priority1");
            ViewBag.Repaired_StausId = new SelectList(db.Repaired_Staus, "Repaired_StausId", "Status");
            return View();
        }

        // POST: Complains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Complain complain, HttpPostedFileBase imageData)
        {
            if (ModelState.IsValid)
            {
                if (imageData != null && imageData.ContentLength > 0)
                {
                    // Convert the uploaded image to a byte array
                    byte[] imageBytes;
                    using (var binaryReader = new BinaryReader(imageData.InputStream))
                    {
                        imageBytes = binaryReader.ReadBytes(imageData.ContentLength);
                    }

                    complain.image_data = imageBytes;
                }

                db.Complains.Add(complain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PriorityId = new SelectList(db.Priorities, "PriorityId", "priority1", complain.PriorityId);
            ViewBag.Repaired_StausId = new SelectList(db.Repaired_Staus, "Repaired_StausId", "Status", complain.Repaired_StausId);
            ViewBag.user_id = new SelectList(db.AllUsers, "user_id", "username", complain.user_id);
            return View(complain);
        }

        // GET: UserComplains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.AllUsers, "user_id", "username", complain.user_id);
            ViewBag.PriorityId = new SelectList(db.Priorities, "PriorityId", "priority1", complain.PriorityId);
            ViewBag.Repaired_StausId = new SelectList(db.Repaired_Staus, "Repaired_StausId", "Status", complain.Repaired_StausId);
            return View(complain);
        }

        // POST: UserComplains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "complain_id,user_id,Name_Of_the_Item,description,location,PriorityId,status,Repaired_StausId,image_data")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.AllUsers, "user_id", "username", complain.user_id);
            ViewBag.PriorityId = new SelectList(db.Priorities, "PriorityId", "priority1", complain.PriorityId);
            ViewBag.Repaired_StausId = new SelectList(db.Repaired_Staus, "Repaired_StausId", "Status", complain.Repaired_StausId);
            return View(complain);
        }

        // GET: UserComplains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // POST: UserComplains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complain complain = db.Complains.Find(id);
            db.Complains.Remove(complain);
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
