using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakip.Models.Entity;

namespace stokTakip.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DbStokEntities db = new DbStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBL_Admin p)
        {
            db.TBL_Admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}