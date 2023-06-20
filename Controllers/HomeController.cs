using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabMaintanance3.Models;

namespace LabMaintanance3.Controllers
{
    public class HomeController : Controller
    {
        private LabMaintanance4Entities db = new LabMaintanance4Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
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

        // GET: Home/Register
        public ActionResult Register()
        {
            ViewBag.role_id = new SelectList(db.Roles, "role_id", "role_name");
            return View();
        }

        // POST: Home/Register
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
