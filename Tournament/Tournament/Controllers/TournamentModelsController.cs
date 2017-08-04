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
    public class TournamentModelsController : Controller
    {
        private TournamentContext db = new TournamentContext();

        // GET: TournamentModels
        public ActionResult Index()
        {
            return View(db.Tournamets.ToList());
        }

        // GET: TournamentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentModel tournamentModel = db.Tournamets.Find(id);
            if (tournamentModel == null)
            {
                return HttpNotFound();
            }
            return View(tournamentModel);
        }

        // GET: TournamentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TournamentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TournamentModelId,TournamentName,EntryFee")] TournamentModel tournamentModel)
        {
            if (ModelState.IsValid)
            {
                db.Tournamets.Add(tournamentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tournamentModel);
        }

        // GET: TournamentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentModel tournamentModel = db.Tournamets.Find(id);
            if (tournamentModel == null)
            {
                return HttpNotFound();
            }
            return View(tournamentModel);
        }

        // POST: TournamentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TournamentModelId,TournamentName,EntryFee")] TournamentModel tournamentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournamentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tournamentModel);
        }

        // GET: TournamentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentModel tournamentModel = db.Tournamets.Find(id);
            if (tournamentModel == null)
            {
                return HttpNotFound();
            }
            return View(tournamentModel);
        }

        // POST: TournamentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TournamentModel tournamentModel = db.Tournamets.Find(id);
            db.Tournamets.Remove(tournamentModel);
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
