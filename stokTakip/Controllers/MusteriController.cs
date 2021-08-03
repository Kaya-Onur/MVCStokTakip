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
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbStokEntities db = new DbStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            //var musteriListe = db.TBL_Musteri.ToList();
            var musteriListe = db.TBL_Musteri.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 10);
            return View(musteriListe);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_Musteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.durum = true;
            db.TBL_Musteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(TBL_Musteri p)
        {
            var mst = db.TBL_Musteri.Find(p.id);
            mst.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mstr = db.TBL_Musteri.Find(id);
            return View("MusteriGetir", mstr);
        }
        public ActionResult MusteriGuncelle(TBL_Musteri p)
        {
            var mst = db.TBL_Musteri.Find(p.id);
            mst.ad = p.ad;
            mst.soyad = p.soyad;
            mst.sehir = p.sehir;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}