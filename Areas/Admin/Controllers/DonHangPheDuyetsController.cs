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
    public class DonHangPheDuyetsController : BaseController
    {
        private tourdb db = new tourdb();

        // GET: Admin/DonHangPheDuyets
        public ActionResult Index()
        {
            var donHangPheDuyets = db.DonHangPheDuyets.Include(d => d.HoaDon);
            return View(donHangPheDuyets.ToList());
        }

        // GET: Admin/DonHangPheDuyets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangPheDuyet donHangPheDuyet = db.DonHangPheDuyets.Find(id);
            if (donHangPheDuyet == null)
            {
                return HttpNotFound();
            }
            return View(donHangPheDuyet);
        }

        // GET: Admin/DonHangPheDuyets/Create
        public ActionResult Create()
        {
            ViewBag.hoaDonId = new SelectList(db.HoaDons, "hoaDonId", "tenKhachHang");
            return View();
        }

        // POST: Admin/DonHangPheDuyets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,hoaDonId,trangThaiDuyet,ngayPheDuyet")] DonHangPheDuyet donHangPheDuyet)
        {
            if (ModelState.IsValid)
            {
                db.DonHangPheDuyets.Add(donHangPheDuyet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hoaDonId = new SelectList(db.HoaDons, "hoaDonId", "tenKhachHang", donHangPheDuyet.hoaDonId);
            return View(donHangPheDuyet);
        }

        // GET: Admin/DonHangPheDuyets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangPheDuyet donHangPheDuyet = db.DonHangPheDuyets.Find(id);
            if (donHangPheDuyet == null)
            {
                return HttpNotFound();
            }
            ViewBag.hoaDonId = new SelectList(db.HoaDons, "hoaDonId", "tenKhachHang", donHangPheDuyet.hoaDonId);
            return View(donHangPheDuyet);
        }

        // POST: Admin/DonHangPheDuyets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,hoaDonId,trangThaiDuyet,ngayPheDuyet")] DonHangPheDuyet donHangPheDuyet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHangPheDuyet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hoaDonId = new SelectList(db.HoaDons, "hoaDonId", "tenKhachHang", donHangPheDuyet.hoaDonId);
            return View(donHangPheDuyet);
        }

        // GET: Admin/DonHangPheDuyets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangPheDuyet donHangPheDuyet = db.DonHangPheDuyets.Find(id);
            if (donHangPheDuyet == null)
            {
                return HttpNotFound();
            }
            return View(donHangPheDuyet);
        }

        // POST: Admin/DonHangPheDuyets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHangPheDuyet donHangPheDuyet = db.DonHangPheDuyets.Find(id);
            db.DonHangPheDuyets.Remove(donHangPheDuyet);
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
