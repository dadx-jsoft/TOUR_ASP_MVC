using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TOUR.Models;

namespace TOUR.Areas.Admin.Controllers
{
    public class DongToursController : BaseController
    {
        private tourdb db = new tourdb();

        // GET: Admin/DongTours
        public ActionResult Index()
        {
            return View(db.DongTours.ToList());
        }

        // GET: Admin/DongTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongTour dongTour = db.DongTours.Find(id);
            if (dongTour == null)
            {
                return HttpNotFound();
            }
            return View(dongTour);
        }

        // GET: Admin/DongTours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DongTours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dongTourId,moTaDongTour")] DongTour dongTour)
        {
            if (ModelState.IsValid)
            {
                db.DongTours.Add(dongTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dongTour);
        }

        // GET: Admin/DongTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongTour dongTour = db.DongTours.Find(id);
            if (dongTour == null)
            {
                return HttpNotFound();
            }
            return View(dongTour);
        }

        // POST: Admin/DongTours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dongTourId,moTaDongTour")] DongTour dongTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dongTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dongTour);
        }

        // GET: Admin/DongTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongTour dongTour = db.DongTours.Find(id);
            if (dongTour == null)
            {
                return HttpNotFound();
            }
            return View(dongTour);
        }

        // POST: Admin/DongTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DongTour dongTour = db.DongTours.Find(id);
            db.DongTours.Remove(dongTour);
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
