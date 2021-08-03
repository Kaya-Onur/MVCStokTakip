using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakip.Models.Entity;

namespace stokTakip.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DbStokEntities db = new DbStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var satislar = db.TBL_Satislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Ürünler
            List<SelectListItem> urun = (from x in db.TBL_Urunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop1 = urun;

            //Personel
            List<SelectListItem> per = (from x in db.TBL_Personel.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad + " " + x.soyad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop2 = per;

            //Müşteriler
            List<SelectListItem> mst = (from x in db.TBL_Musteri.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad + " " + x.soyad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop3 = mst;





            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBL_Satislar p)
        {

            var urun = db.TBL_Urunler.Where(x => x.id == p.TBL_Urunler.id).FirstOrDefault();
            var musteri = db.TBL_Musteri.Where(x => x.id == p.TBL_Musteri.id).FirstOrDefault();
            var personel = db.TBL_Personel.Where(x => x.id == p.TBL_Personel.id).FirstOrDefault();
            p.TBL_Urunler = urun;
            p.TBL_Musteri = musteri;
            p.TBL_Personel = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortTimeString());
            db.TBL_Satislar.Add(p);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}