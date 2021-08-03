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
    public class UrunController : Controller
    {
        // GET: Urun
        DbStokEntities db = new DbStokEntities();
        [Authorize]
        public ActionResult Index(string p)
        {
            //var urunler = db.TBL_Urunler.Where(x => x.durum == true).ToList();
            var urunler = db.TBL_Urunler.Where(x => x.durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.ad.Contains(p) && x.durum==true);
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.TBL_Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBL_Urunler p)
        {
            p.durum = true;
            var ktgr = db.TBL_Kategori.Where(x => x.id == p.TBL_Kategori.id).FirstOrDefault();
            p.TBL_Kategori = ktgr;
            db.TBL_Urunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(TBL_Urunler p)
        {
            var urunBul = db.TBL_Urunler.Find(p.id);
            urunBul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.TBL_Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.urunKategori = kat;
            var urn = db.TBL_Urunler.Find(id);
            return View("UrunGetir", urn);
        }
        public ActionResult UrunGuncelle(TBL_Urunler p)
        {
            var urn = db.TBL_Urunler.Find(p.id);
            urn.ad = p.ad;
            urn.marka = p.marka;
            urn.stok = p.stok;
            urn.alisFiyat = p.alisFiyat;
            urn.satisFiyat = p.satisFiyat;

            var ktg = db.TBL_Kategori.Where(x => x.id == p.TBL_Kategori.id).FirstOrDefault();
            urn.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}