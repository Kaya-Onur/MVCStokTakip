using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakip.Models.Entity;
using System.Web.Security;

namespace stokTakip.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        DbStokEntities db = new DbStokEntities();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(TBL_Admin p)
        {
            var bilgiler = db.TBL_Admin.FirstOrDefault(x => x.kullanici == p.kullanici && x.sifre == p.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Urun");
            }
            else
            {
                return View();
            }
            
        }
    }
}