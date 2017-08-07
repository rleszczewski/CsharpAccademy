using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tournament.Models;

namespace Tournament.Controllers
{
    public class PersonModelsController : Controller
    {
        public ActionResult Index()
        {
            using (TournamentContext db = new TournamentContext())
            {
                return View(db.TournamentModels.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();

        }
        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(PersonModel Account)
        {
            if (ModelState.IsValid)
            {
                using (TournamentContext db = new TournamentContext())
                {
                    db.TournamentModels.Add(Account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = Account.FirstName + " " + Account.LastName + " succesful register.";

            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(PersonModel user)
        {
            using (TournamentContext db = new TournamentContext())
            {
                var usr = db.TournamentModels.Where(u => u.NickName == user.NickName && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["PersonId"] = usr.PersonId.ToString();
                    Session["NickName"] = usr.NickName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is not correct");
                }

            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            using (TournamentContext db = new TournamentContext())
            {
                
                if (Session["PersonId"] != null)
            {
                return View(db.Tournamets.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
            

            }
        }
        
    }
}
