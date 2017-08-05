using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Tournament.Models;

namespace Tournament.Controllers
{
    public class HomeController : Controller
    {
        private TournamentContext db = new TournamentContext();
        public ActionResult Index(int id)
        {
            var tm = db.Tournamets.First(x => x.TournamentModelId == id);
            return View(tm);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}