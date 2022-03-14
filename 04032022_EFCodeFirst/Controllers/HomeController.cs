using _04032022_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04032022_EFCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
           List<Kisiler> kisiler=db.Kisiler.ToList();

            KisilerveAdresleri model = new KisilerveAdresleri();

            model.Kisiler = db.Kisiler.ToList();
            model.Adresler = db.Adresler.ToList();

            return View(model);
        }
    }
}