using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace stokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbStokEntities db = new DbStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            //var kategoriler = db.TBL_Kategori.ToList();
            var kategoriler = db.TBL_Kategori.ToList().ToPagedList(sayfa, 10);
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBL_Kategori p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }

            db.TBL_Kategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TBL_Kategori.Find(id);
            db.TBL_Kategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_Kategori.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult KategoriGuncelle(TBL_Kategori p)
        {
            var ktg = db.TBL_Kategori.Find(p.id);
            ktg.ad = p.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}