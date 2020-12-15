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
    public class PhanHoiLienHesController : BaseController
    {
        private tourdb db = new tourdb();

        // GET: Admin/PhanHoiLienHes
        public ActionResult Index()
        {
            return View(db.PhanHoiLienHes.ToList());
        }

        // GET: Admin/PhanHoiLienHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoiLienHe phanHoiLienHe = db.PhanHoiLienHes.Find(id);
            if (phanHoiLienHe == null)
            {
                return HttpNotFound();
            }
            return View(phanHoiLienHe);
        }

        // GET: Admin/PhanHoiLienHes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhanHoiLienHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tenKhachHang,sdtKhachHang,emailKhachHang,loiNhanKhachHang")] PhanHoiLienHe phanHoiLienHe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PhanHoiLienHes.Add(phanHoiLienHe);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Lỗi thêm " + e.Message;
                return View(phanHoiLienHe);
            }
        }

        // GET: Admin/PhanHoiLienHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoiLienHe phanHoiLienHe = db.PhanHoiLienHes.Find(id);
            if (phanHoiLienHe == null)
            {
                return HttpNotFound();
            }
            return View(phanHoiLienHe);
        }

        // POST: Admin/PhanHoiLienHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tenKhachHang,sdtKhachHang,emailKhachHang,loiNhanKhachHang")] PhanHoiLienHe phanHoiLienHe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(phanHoiLienHe).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Lỗi sửa " + e.Message;
                return View(phanHoiLienHe);
            }
        }

        // GET: Admin/PhanHoiLienHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoiLienHe phanHoiLienHe = db.PhanHoiLienHes.Find(id);
            if (phanHoiLienHe == null)
            {
                return HttpNotFound();
            }
            return View(phanHoiLienHe);
        }

        // POST: Admin/PhanHoiLienHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanHoiLienHe phanHoiLienHe = db.PhanHoiLienHes.Find(id);
            try
            {
                db.PhanHoiLienHes.Remove(phanHoiLienHe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Lỗi xóa " + e.Message;
                return View(phanHoiLienHe);
            }
            
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
