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
    public class MatchUpEntryModelsController : Controller
    {
        private TournamentContext db = new TournamentContext();

        // GET: MatchUpEntryModels
        public ActionResult Index()
        {
            var matchUpEntries = db.MatchUpEntries.Include(m => m.TeamCompeting);
            return View(matchUpEntries.ToList());
        }

        // GET: MatchUpEntryModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchUpEntryModel matchUpEntryModel = db.MatchUpEntries.Find(id);
            if (matchUpEntryModel == null)
            {
                return HttpNotFound();
            }
            return View(matchUpEntryModel);
        }

        // GET: MatchUpEntryModels/Create
        public ActionResult Create()
        {
            ViewBag.MatchUpEntryModelId = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: MatchUpEntryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchUpEntryModelId,Score")] MatchUpEntryModel matchUpEntryModel)
        {
            if (ModelState.IsValid)
            {
                db.MatchUpEntries.Add(matchUpEntryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchUpEntryModelId = new SelectList(db.Teams, "TeamId", "TeamName", matchUpEntryModel.MatchUpEntryModelId);
            return View(matchUpEntryModel);
        }

        // GET: MatchUpEntryModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchUpEntryModel matchUpEntryModel = db.MatchUpEntries.Find(id);
            if (matchUpEntryModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchUpEntryModelId = new SelectList(db.Teams, "TeamId", "TeamName", matchUpEntryModel.MatchUpEntryModelId);
            return View(matchUpEntryModel);
        }

        // POST: MatchUpEntryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchUpEntryModelId,Score")] MatchUpEntryModel matchUpEntryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchUpEntryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchUpEntryModelId = new SelectList(db.Teams, "TeamId", "TeamName", matchUpEntryModel.MatchUpEntryModelId);
            return View(matchUpEntryModel);
        }

        // GET: MatchUpEntryModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchUpEntryModel matchUpEntryModel = db.MatchUpEntries.Find(id);
            if (matchUpEntryModel == null)
            {
                return HttpNotFound();
            }
            return View(matchUpEntryModel);
        }

        // POST: MatchUpEntryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchUpEntryModel matchUpEntryModel = db.MatchUpEntries.Find(id);
            db.MatchUpEntries.Remove(matchUpEntryModel);
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
