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
    public class HoaDonsController : BaseController
    {
        private tourdb db = new tourdb();

        // GET: Admin/HoaDons
        public ActionResult Index()
        {
            //var hoaDons = db.HoaDons.Include(h => h.Tour);
            var hoaDons = db.HoaDons.Select(h => h);

            //var donHangPheDuyet = db.DonHangPheDuyets.Select(dh => dh);

            var hoaDonIds = db.DonHangPheDuyets.Select(dh => dh.hoaDonId).ToArray();

            List<HoaDon> dsHoaDonChoDuyet = new List<HoaDon>();
            foreach (var item in hoaDons)
            {
                if (!hoaDonIds.Contains(item.hoaDonId))
                {
                    dsHoaDonChoDuyet.Add(item);
                }
            }

            return View(dsHoaDonChoDuyet);
        }

        // GET: Admin/HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hoaDonId,tenKhachHang,sdtKhachHang,idTour")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem", hoaDon.idTour);
            return View(hoaDon);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Sequence(int id)
        {
            //var hoaDon = db.HoaDons.Find(hoaDonId);
            var ngayPheDuyet = DateTime.Now;

            var dh = new DonHangPheDuyet();
            dh.hoaDonId = id;
            dh.trangThaiDuyet = 1;
            dh.ngayPheDuyet = ngayPheDuyet;

            db.DonHangPheDuyets.Add(dh);

            //db.HoaDons.Add(hoaDon);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        // GET: Admin/HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem", hoaDon.idTour);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hoaDonId,tenKhachHang,sdtKhachHang,idTour")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem", hoaDon.idTour);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
