using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMaintanance3.Controllers.Admin
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            // Retrieve user_id from session
            var userId = Session["UserId"] as int?;

            // Only users with specific user_ids can access this action
            if (!IsAuthorizedUser(userId))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            return View();
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve user_id from session
            var userId = Session["UserId"] as int?;

            // Only users with specific user_ids can access this action
            if (!IsAuthorizedUser(userId))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            return View();
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            // Retrieve user_id from session
            var userId = Session["UserId"] as int?;

            // Only users with specific user_ids can access this action
            if (!IsAuthorizedUser(userId))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            // Retrieve user_id from session
            var userId = Session["UserId"] as int?;

            // Only users with specific user_ids can access this action
            if (!IsAuthorizedUser(userId))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            // Retrieve user_id from session
            var userId = Session["UserId"] as int?;

            // Only users with specific user_ids can access this action
            if (!IsAuthorizedUser(userId))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            return View();
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            // Retrieve user_id from session
            var userId = Session["UserId"] as int?;

            // Only users with specific user_ids can access this action
            if (!IsAuthorizedUser(userId))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            // Retrieve user_id from session
            var userId = Session["UserId"] as int?;

            // Only users with specific user_ids can access this action
            if (!IsAuthorizedUser(userId))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Retrieve user_id from session
            var userId = Session["UserId"] as int?;

            // Only users with specific user_ids can access this action
            if (!IsAuthorizedUser(userId))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private bool IsAuthorizedUser(int? userId)
        {
            // Define the list of authorized user_ids
            var authorizedUserIds = new List<int> { 1, 2, 3 }; // Add your authorized user_ids here

            // Check if the provided user_id is in the authorized list
            return userId.HasValue && authorizedUserIds.Contains(userId.Value);
        }
    }
}
