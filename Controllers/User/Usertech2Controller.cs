using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabMaintanance3.Models;

namespace LabMaintanance3.Controllers.User
{
    public class Usertech2Controller : Controller
    {
        private LabMaintanance4Entities db = new LabMaintanance4Entities();

        // GET: Usertech2
        public ActionResult Index()
        {
            var tech2 = db.tech2.Include(t => t.Complain);
            return View(tech2.ToList());
        }

        // GET: Usertech2/Details/5
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

        // GET: Usertech2/Create
       
    }
}
