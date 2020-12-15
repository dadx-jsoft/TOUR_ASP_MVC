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
    public class ToursController : BaseController
    {
        private tourdb db = new tourdb();

        // GET: Admin/Tours
        public ActionResult Index()
        {
            var tours = db.Tours.OrderByDescending(t=>t.ngayTao).Include(t => t.DongTour);
            return View(tours.ToList());
        }

        // GET: Admin/Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Admin/Tours/Create
        public ActionResult Create()
        {
            ViewBag.dongTourId = new SelectList(db.DongTours, "dongTourId", "moTaDongTour");
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create([Bind(Include = "idTour,dongTourId,diaDiem,anhTour,anhChiTietTour,giaGoc,giaKhuyenMai,khuyenMaiUuDai,tenTour,tenTieuDeTour,moTaTour,soNgay,ngayTao")] Tour tour)
        {
            try
            {
                tour.ngayTao = DateTime.Now;
                if (ModelState.IsValid)
                {
                    //tour.anhTour = "";
                    //tour.anhChiTietTour = "";
                    var f1 = Request.Files["ImageFile1"];

                    if(f1!=null && f1.ContentLength > 0)
                    {
                        string FileName1 = System.IO.Path.GetFileName(f1.FileName);
                        // Lấy tên file upload
                        string UploadPath = Server.MapPath("~/Areas/Admin/Assets/images/" + FileName1);
                        // Copy và lưu file vào server
                        f1.SaveAs(UploadPath);
                        // lưu tên file vào trường ảnh
                        tour.anhTour= FileName1;
                    }
                    else
                    {
                        tour.anhTour = Request["anhTour"];
                    }

                    var f2 = Request.Files["ImageFile2"];
                    if (f2 != null && f2.ContentLength > 0)
                    {
                        string FileName2 = System.IO.Path.GetFileName(f2.FileName);
                        // Lấy tên file upload
                        string UploadPath = Server.MapPath("~/Areas/Admin/Assets/images/" + FileName2);
                        // Copy và lưu file vào server
                        f2.SaveAs(UploadPath);
                        // lưu tên file vào trường ảnh
                        tour.anhChiTietTour = FileName2;
                    }
                    else
                    {
                        tour.anhChiTietTour = Request["anhChiTietTour"];
                    }
                    db.Tours.Add(tour);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi thêm: " + e.Message;
                ViewBag.dongTourId = new SelectList(db.DongTours, "dongTourId", "moTaDongTour", tour.dongTourId);
                return View(tour);
            }
            

            
        }

        // GET: Admin/Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.dongTourId = new SelectList(db.DongTours, "dongTourId", "moTaDongTour", tour.dongTourId);
            return View(tour);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "idTour,dongTourId,diaDiem,anhTour,anhChiTietTour,giaGoc,giaKhuyenMai,khuyenMaiUuDai,tenTour,tenTieuDeTour,moTaTour,soNgay")] Tour tour)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //tour.anhTour = "";
                    //tour.anhChiTietTour = "";
                    var f1 = Request.Files["ImageFile1"];
                    var f2 = Request.Files["ImageFile2"];

                    if (f1 != null && f1.ContentLength > 0)
                    {
                        string FileName1 = System.IO.Path.GetFileName(f1.FileName);
                        // Lấy tên file upload
                        string UploadPath = Server.MapPath("~/Areas/Admin/Assets/images/" + FileName1);
                        // Copy và lưu file vào server
                        f1.SaveAs(UploadPath);
                        // lưu tên file vào trường ảnh
                        tour.anhTour = FileName1.Trim();
                    }
                    if (f2 != null && f2.ContentLength > 0)
                    {
                        string FileName2 = System.IO.Path.GetFileName(f2.FileName);
                        // Lấy tên file upload
                        string UploadPath = Server.MapPath("~/Areas/Admin/Assets/images/" + FileName2);
                        // Copy và lưu file vào server
                        f2.SaveAs(UploadPath);
                        // lưu tên file vào trường ảnh
                        tour.anhChiTietTour = FileName2.Trim();
                    }

                    db.Entry(tour).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi sửa: " + e.Message;
                ViewBag.dongTourId = new SelectList(db.DongTours, "dongTourId", "moTaDongTour", tour.dongTourId);
                return View(tour);
            }
        }

        // GET: Admin/Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
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
