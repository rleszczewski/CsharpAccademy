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
        private TournamentContext db = new TournamentContext();

        // GET: PersonModels
        public ActionResult Index()
        {
            var tournamentModels = db.TournamentModels.Include(p => p.TeamModel);
            return View(tournamentModels.ToList());
        }

        // GET: PersonModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = db.TournamentModels.Find(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // GET: PersonModels/Create
        public ActionResult Create()
        {
            ViewBag.TeamRefId = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: PersonModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,NickName,FirstName,LastName,Email,TeamRefId")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                db.TournamentModels.Add(personModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamRefId = new SelectList(db.Teams, "TeamId", "TeamName", personModel.TeamRefId);
            return View(personModel);
        }

        // GET: PersonModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = db.TournamentModels.Find(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamRefId = new SelectList(db.Teams, "TeamId", "TeamName", personModel.TeamRefId);
            return View(personModel);
        }

        // POST: PersonModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,NickName,FirstName,LastName,Email,TeamRefId")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamRefId = new SelectList(db.Teams, "TeamId", "TeamName", personModel.TeamRefId);
            return View(personModel);
        }

        // GET: PersonModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonModel personModel = db.TournamentModels.Find(id);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // POST: PersonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonModel personModel = db.TournamentModels.Find(id);
            db.TournamentModels.Remove(personModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
