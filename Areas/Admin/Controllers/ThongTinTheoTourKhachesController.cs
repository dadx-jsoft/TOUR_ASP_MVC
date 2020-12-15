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
    public class ThongTinTheoTourKhachesController : BaseController
    {
        private tourdb db = new tourdb();

        // GET: Admin/ThongTinTheoTourKhaches
        public ActionResult Index()
        {
            var thongTinTheoTourKhaches = db.ThongTinTheoTourKhaches.Include(t => t.Tour);
            return View(thongTinTheoTourKhaches.ToList());
        }

        // GET: Admin/ThongTinTheoTourKhaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinTheoTourKhach thongTinTheoTourKhach = db.ThongTinTheoTourKhaches.Find(id);
            if (thongTinTheoTourKhach == null)
            {
                return HttpNotFound();
            }
            return View(thongTinTheoTourKhach);
        }

        // GET: Admin/ThongTinTheoTourKhaches/Create
        public ActionResult Create()
        {
            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem");
            return View();
        }

        // POST: Admin/ThongTinTheoTourKhaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tenKhachHang,sdtKhachHang,loiNhanKhachHang,idTour")] ThongTinTheoTourKhach thongTinTheoTourKhach)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinTheoTourKhaches.Add(thongTinTheoTourKhach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem", thongTinTheoTourKhach.idTour);
            return View(thongTinTheoTourKhach);
        }

        // GET: Admin/ThongTinTheoTourKhaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinTheoTourKhach thongTinTheoTourKhach = db.ThongTinTheoTourKhaches.Find(id);
            if (thongTinTheoTourKhach == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem", thongTinTheoTourKhach.idTour);
            return View(thongTinTheoTourKhach);
        }

        // POST: Admin/ThongTinTheoTourKhaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenKhachHang,sdtKhachHang,loiNhanKhachHang,idTour")] ThongTinTheoTourKhach thongTinTheoTourKhach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinTheoTourKhach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem", thongTinTheoTourKhach.idTour);
            return View(thongTinTheoTourKhach);
        }

        // GET: Admin/ThongTinTheoTourKhaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinTheoTourKhach thongTinTheoTourKhach = db.ThongTinTheoTourKhaches.Find(id);
            if (thongTinTheoTourKhach == null)
            {
                return HttpNotFound();
            }
            return View(thongTinTheoTourKhach);
        }

        // POST: Admin/ThongTinTheoTourKhaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinTheoTourKhach thongTinTheoTourKhach = db.ThongTinTheoTourKhaches.Find(id);
            db.ThongTinTheoTourKhaches.Remove(thongTinTheoTourKhach);
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
