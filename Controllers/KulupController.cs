using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulup = db.TBLKULUPLER.ToList();
            return View(kulup);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p2)
        {
            db.TBLKULUPLER.Add(p2);  //tblkulupler e p2 yi ekle
            db.SaveChanges();  //değişiklikleri kaydet
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id); //tblkulupler içinde id ye göre gönderilen değeri bul
            db.TBLKULUPLER.Remove(kulup); //tblkulupler içinden kulup değişkeninden gelen değeri kaldır
            db.SaveChanges(); //değişiklikleri kaydet
            return RedirectToAction("Index"); //index sayfasına geri dön
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup2 = db.TBLKULUPLER.Find(id); //tblkulupler içinde id ye göre gönderilen değeri bul
            return View("KulupGetir", kulup2);
        }
        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID); //parametreden gelen kulupid yi bulup klp adlı değişkene ata
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulup");
        }

    }
}