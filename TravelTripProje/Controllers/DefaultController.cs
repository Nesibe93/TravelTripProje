using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {

            var degerler = context.Blogs.ToList();
            return View(degerler);
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var degerler = context.Blogs.OrderByDescending(x=> x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var degerler = context.Blogs.Where(x => x.ID==1).ToList();
            return PartialView(degerler);
        }
    }
}