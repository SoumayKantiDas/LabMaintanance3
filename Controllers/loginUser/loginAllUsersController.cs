using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabMaintanance3.Models;

namespace LabMaintanance3.Controllers.loginUser
{
    public class loginAllUsersController : Controller
    {
        private LabMaintanance4Entities db = new LabMaintanance4Entities();

        // GET: loginAllUsers
        public ActionResult Index()
        {
            var allUsers = db.AllUsers.Include(a => a.Role);
            return View(allUsers.ToList());
        }

        // GET: loginAllUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllUser allUser = db.AllUsers.Find(id);
            if (allUser == null)
            {
                return HttpNotFound();
            }
            return View(allUser);
        }

        // GET: loginAllUsers/Create
        public ActionResult Create()
        {
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name");
            return View();
        }

        // POST: loginAllUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,username,email,role_id,password,hashPassword")] AllUser allUser)
        {
            if (ModelState.IsValid)
            {
                db.AllUsers.Add(allUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name", allUser.role_id);
            return View(allUser);
        }

        // GET: loginAllUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllUser allUser = db.AllUsers.Find(id);
            if (allUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name", allUser.role_id);
            return View(allUser);
        }

        // POST: loginAllUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,username,email,role_id,password,hashPassword")] AllUser allUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name", allUser.role_id);
            return View(allUser);
        }

        // GET: loginAllUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllUser allUser = db.AllUsers.Find(id);
            if (allUser == null)
            {
                return HttpNotFound();
            }
            return View(allUser);
        }

        // POST: loginAllUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllUser allUser = db.AllUsers.Find(id);
            db.AllUsers.Remove(allUser);
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

        // GET: loginAllUsers/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: loginAllUsers/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            // Perform authentication logic here
            // You can customize this according to your authentication mechanism

            // Example code:
            var user = db.AllUsers.SingleOrDefault(u => u.username == username && u.password == password);
            if (user == null)
            {
                // Authentication failed
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
            else
            {
                // Authentication succeeded
                // Redirect based on user role
                switch (user.role_id)
                {
                    case 1:
                        return RedirectToAction("Index", "Teacher");
                    case 2:
                        return RedirectToAction("Index", "Stuff");
                    case 3:
                        return RedirectToAction("Index", "Student");
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }
        }

        // GET: loginAllUsers/Register
        public ActionResult Register()
        {
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name");
            return View();
        }

        // POST: loginAllUsers/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "user_id,username,email,role_id,password,hashPassword")] AllUser allUser)
        {
            if (ModelState.IsValid)
            {
                db.AllUsers.Add(allUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name", allUser.role_id);
            return View(allUser);
        }
    }
}
