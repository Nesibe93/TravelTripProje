using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            context.Blogs.Add(p);
            context.SaveChanges();
           return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var values = context.Blogs.Find(id);
            return View(values);
        }
        public ActionResult BlogGüncelle(Blog b)
        {
            var value = context.Blogs.Find(b.ID);
            value.Baslik = b.Baslik;
            value.Aciklama = b.Aciklama;
            value.BlogImage = b.BlogImage;
            value.Tarih = b.Tarih;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(b);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            return View(yorum);
        }
        public ActionResult YorumGüncelle(Yorumlar y)
        {
            var yorum = context.Yorumlars.Find(y.ID);
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;
            yorum.Yorum = y.Yorum;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");

        }
    }
}