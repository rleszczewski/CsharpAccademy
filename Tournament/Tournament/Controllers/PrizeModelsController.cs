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
    public class PrizeModelsController : Controller
    {
        private TournamentContext db = new TournamentContext();

        // GET: PrizeModels
        public ActionResult Index()
        {
            var prizes = db.Prizes.Include(p => p.Tournament);
            return View(prizes.ToList());
        }

        // GET: PrizeModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrizeModel prizeModel = db.Prizes.Find(id);
            if (prizeModel == null)
            {
                return HttpNotFound();
            }
            return View(prizeModel);
        }

        // GET: PrizeModels/Create
        public ActionResult Create()
        {
            ViewBag.TournamentId = new SelectList(db.Tournamets, "TournamentModelId", "TournamentName");
            return View();
        }

        // POST: PrizeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrizeModelId,PlaceNumber,PlaceName,PrizeAmount,PrizePercentage,TournamentId")] PrizeModel prizeModel)
        {
            if (ModelState.IsValid)
            {
                db.Prizes.Add(prizeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TournamentId = new SelectList(db.Tournamets, "TournamentModelId", "TournamentName", prizeModel.TournamentId);
            return View(prizeModel);
        }

        // GET: PrizeModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrizeModel prizeModel = db.Prizes.Find(id);
            if (prizeModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TournamentId = new SelectList(db.Tournamets, "TournamentModelId", "TournamentName", prizeModel.TournamentId);
            return View(prizeModel);
        }

        // POST: PrizeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrizeModelId,PlaceNumber,PlaceName,PrizeAmount,PrizePercentage,TournamentId")] PrizeModel prizeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prizeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TournamentId = new SelectList(db.Tournamets, "TournamentModelId", "TournamentName", prizeModel.TournamentId);
            return View(prizeModel);
        }

        // GET: PrizeModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrizeModel prizeModel = db.Prizes.Find(id);
            if (prizeModel == null)
            {
                return HttpNotFound();
            }
            return View(prizeModel);
        }

        // POST: PrizeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrizeModel prizeModel = db.Prizes.Find(id);
            db.Prizes.Remove(prizeModel);
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
