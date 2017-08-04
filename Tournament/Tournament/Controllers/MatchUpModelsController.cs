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
    public class MatchUpModelsController : Controller
    {
        private TournamentContext db = new TournamentContext();

        // GET: MatchUpModels
        public ActionResult Index()
        {
            var matchUps = db.MatchUps.Include(m => m.Winner);
            return View(matchUps.ToList());
        }

        // GET: MatchUpModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchUpModel matchUpModel = db.MatchUps.Find(id);
            if (matchUpModel == null)
            {
                return HttpNotFound();
            }
            return View(matchUpModel);
        }

        // GET: MatchUpModels/Create
        public ActionResult Create()
        {
            ViewBag.MatchUpModelId = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: MatchUpModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchUpModelId,MatchupRound")] MatchUpModel matchUpModel)
        {
            if (ModelState.IsValid)
            {
                db.MatchUps.Add(matchUpModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchUpModelId = new SelectList(db.Teams, "TeamId", "TeamName", matchUpModel.MatchUpModelId);
            return View(matchUpModel);
        }

        // GET: MatchUpModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchUpModel matchUpModel = db.MatchUps.Find(id);
            if (matchUpModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchUpModelId = new SelectList(db.Teams, "TeamId", "TeamName", matchUpModel.MatchUpModelId);
            return View(matchUpModel);
        }

        // POST: MatchUpModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchUpModelId,MatchupRound")] MatchUpModel matchUpModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchUpModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchUpModelId = new SelectList(db.Teams, "TeamId", "TeamName", matchUpModel.MatchUpModelId);
            return View(matchUpModel);
        }

        // GET: MatchUpModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchUpModel matchUpModel = db.MatchUps.Find(id);
            if (matchUpModel == null)
            {
                return HttpNotFound();
            }
            return View(matchUpModel);
        }

        // POST: MatchUpModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchUpModel matchUpModel = db.MatchUps.Find(id);
            db.MatchUps.Remove(matchUpModel);
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
