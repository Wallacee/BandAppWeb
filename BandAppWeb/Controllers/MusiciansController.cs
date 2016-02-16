using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BandAppWeb;

namespace BandAppWeb.Controllers
{
    public class MusiciansController : Controller
    {
        private DBBandEntities db = new DBBandEntities();

        // GET: Musicians
        public ActionResult Index()
        {
            var musician = db.Musician.Include(m => m.Instrument);
            return View(musician.ToList());
        }

        // GET: Musicians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musician.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // GET: Musicians/Create
        public ActionResult Create()
        {
            ViewBag.fk_instrument = new SelectList(db.Instrument, "idInstrument", "instrument1");
            return View();
        }

        // POST: Musicians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMusician,name,fk_instrument")] Musician musician)
        {
            if (ModelState.IsValid)
            {
                db.Musician.Add(musician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_instrument = new SelectList(db.Instrument, "idInstrument", "instrument1", musician.fk_instrument);
            return View(musician);
        }

        // GET: Musicians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musician.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_instrument = new SelectList(db.Instrument, "idInstrument", "instrument1", musician.fk_instrument);
            return View(musician);
        }

        // POST: Musicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMusician,name,fk_instrument")] Musician musician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_instrument = new SelectList(db.Instrument, "idInstrument", "instrument1", musician.fk_instrument);
            return View(musician);
        }

        // GET: Musicians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musician.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // POST: Musicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musician musician = db.Musician.Find(id);
            db.Musician.Remove(musician);
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
