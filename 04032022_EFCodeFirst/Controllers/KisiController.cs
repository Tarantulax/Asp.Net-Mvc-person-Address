using _04032022_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04032022_EFCodeFirst.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Kisiler kisi)
        {
            DatabaseContext db = new DatabaseContext();
            db.Kisiler.Add(kisi);

           int sonuc= db.SaveChanges();

            if (sonuc > 0)
            {
                ViewBag.mesaj = "Kişi kaydedilmiştir.";
                ViewBag.renk = "success";
            }
            else
            {
                ViewBag.mesaj = "Kişi kayıt yapılırken hata oluştu. ";
                ViewBag.renk = "danger";
            }

            return View();
        }
        public ActionResult Duzenle(int? kisiid)
        {
            Kisiler kisi = new Kisiler();

            DatabaseContext db = new DatabaseContext();

            if (kisiid != null)
            {
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            }
            return View(kisi);
        }

        [HttpPost]
        public ActionResult Duzenle(Kisiler kisi,int? kisiid)
        {
            Kisiler k = new Kisiler();

            DatabaseContext db = new DatabaseContext();

            if (kisiid != null)  //kisiid null değilse if çalışır
            {
                k = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();

                k.Ad = kisi.Ad;
                k.Soyad = kisi.Soyad;
                k.Yas = kisi.Yas;

                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.mesaj = "Bilgiler değiştirilmiştir.";
                    ViewBag.renk = "success";
                }
                else
                {
                    ViewBag.mesaj = "Kişi kayıt yapılırken hata oluştu. ";
                    ViewBag.renk = "danger";
                }

            }
                          

            return View(k);
        }


        public ActionResult Sil(int? kisiid)
        {
            Kisiler kisi = new Kisiler();

            DatabaseContext db = new DatabaseContext();

            if (kisiid != null)
            {
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            }
            return View(kisi);
        }

        [HttpPost,ActionName("Sil")]
        public ActionResult KisiSil(int? kisiid)
        {
            Kisiler kisi = new Kisiler();

            DatabaseContext db = new DatabaseContext();

            if (kisiid != null)
            {
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
                db.Kisiler.Remove(kisi);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home"); 
        }


    }
}