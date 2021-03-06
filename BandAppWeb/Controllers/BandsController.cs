﻿using System;
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
    public class BandsController : Controller
    {
        private DBBandEntities db = new DBBandEntities();

        // GET: Bands
        public ActionResult Index()
        {
            var band = db.Band.Include(b => b.Style);
            return View(band.ToList());
        }

        // GET: Bands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Band.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // GET: Bands/Create
        public ActionResult Create()
        {
            ViewBag.fk_style = new SelectList(db.Style, "idStyle", "style1");
            List<Musician> list = db.Musician.ToList();
            ViewBag.listMusician = list;
            return View();
        }

        // POST: Bands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBand,name,foundationDate,fk_style")] Band band)
        {
            if (ModelState.IsValid)
            {
                db.Band.Add(band);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_style = new SelectList(db.Style, "idStyle", "style1", band.fk_style);
            return View(band);
        }

        // GET: Bands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Band.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_style = new SelectList(db.Style, "idStyle", "style1", band.fk_style);
            return View(band);
        }

        // POST: Bands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBand,name,foundationDate,fk_style")] Band band)
        {
            if (ModelState.IsValid)
            {
                db.Entry(band).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_style = new SelectList(db.Style, "idStyle", "style1", band.fk_style);
            return View(band);
        }

        // GET: Bands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Band.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Bands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Band band = db.Band.Find(id);
            db.Band.Remove(band);
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
