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
    public class TeamModelsController : Controller
    {
        private TournamentContext db = new TournamentContext();

        // GET: TeamModels
        public ActionResult Index()
        {
            var teams = db.Teams.Include(t => t.Matchup).Include(t => t.MatchupEntry);
            return View(teams.ToList());
        }

        // GET: TeamModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamModel teamModel = db.Teams.Find(id);
            if (teamModel == null)
            {
                return HttpNotFound();
            }
            return View(teamModel);
        }

        // GET: TeamModels/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.MatchUps, "MatchUpModelId", "MatchUpModelId");
            ViewBag.TeamId = new SelectList(db.MatchUpEntries, "MatchUpEntryModelId", "MatchUpEntryModelId");
            return View();
        }

        // POST: TeamModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,TeamName")] TeamModel teamModel)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(teamModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.MatchUps, "MatchUpModelId", "MatchUpModelId", teamModel.TeamId);
            ViewBag.TeamId = new SelectList(db.MatchUpEntries, "MatchUpEntryModelId", "MatchUpEntryModelId", teamModel.TeamId);
            return View(teamModel);
        }

        // GET: TeamModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamModel teamModel = db.Teams.Find(id);
            if (teamModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.MatchUps, "MatchUpModelId", "MatchUpModelId", teamModel.TeamId);
            ViewBag.TeamId = new SelectList(db.MatchUpEntries, "MatchUpEntryModelId", "MatchUpEntryModelId", teamModel.TeamId);
            return View(teamModel);
        }

        // POST: TeamModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,TeamName")] TeamModel teamModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.MatchUps, "MatchUpModelId", "MatchUpModelId", teamModel.TeamId);
            ViewBag.TeamId = new SelectList(db.MatchUpEntries, "MatchUpEntryModelId", "MatchUpEntryModelId", teamModel.TeamId);
            return View(teamModel);
        }

        // GET: TeamModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamModel teamModel = db.Teams.Find(id);
            if (teamModel == null)
            {
                return HttpNotFound();
            }
            return View(teamModel);
        }

        // POST: TeamModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamModel teamModel = db.Teams.Find(id);
            db.Teams.Remove(teamModel);
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
