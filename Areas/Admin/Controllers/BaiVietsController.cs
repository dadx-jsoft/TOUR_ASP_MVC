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
    public class BaiVietsController : BaseController
    {
        private tourdb db = new tourdb();

        // GET: Admin/BaiViets
        public ActionResult Index()
        {
            var baiViets = db.BaiViets.OrderByDescending(b=>b.ngayTao).Include(b => b.ChuDeBaiViet);
            return View(baiViets.ToList());
        }

        // GET: Admin/BaiViets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: Admin/BaiViets/Create
        public ActionResult Create()
        {
            ViewBag.ChuDeBaiVietId = new SelectList(db.ChuDeBaiViets, "ChuDeBaiVietId", "moTaChuDe");
            return View();
        }

        // POST: Admin/BaiViets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,tieuDe,anhBaiViet,noiDung,ngayTao,ChuDeBaiVietId")] BaiViet baiViet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    baiViet.anhBaiViet = "";
                    var f = Request.Files["ImageFile"];
                    
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        // Lấy tên file upload
                        string UploadPath = Server.MapPath("~/Areas/Admin/Assets/images/baiviet/" + FileName);
                        // Copy và lưu file vào server
                        f.SaveAs(UploadPath);
                        // lưu tên file vào trường ảnh
                        baiViet.anhBaiViet = FileName;
                    }
                    db.BaiViets.Add(baiViet);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi thêm: " + e.Message;
                ViewBag.ChuDeBaiVietId = new SelectList(db.ChuDeBaiViets, "ChuDeBaiVietId", "moTaChuDe", baiViet.ChuDeBaiVietId);
                return View(baiViet);
            }            
        }

        // GET: Admin/BaiViets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChuDeBaiVietId = new SelectList(db.ChuDeBaiViets, "ChuDeBaiVietId", "moTaChuDe", baiViet.ChuDeBaiVietId);
            return View(baiViet);
        }

        // POST: Admin/BaiViets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,tieuDe,anhBaiViet,noiDung,ngayTao,ChuDeBaiVietId")] BaiViet baiViet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //baiViet.anhBaiViet = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        // Lấy tên file upload
                        string UploadPath = Server.MapPath("~/Areas/Admin/Assets/images/baiviet/" + FileName);
                        // Copy và lưu file vào server
                        f.SaveAs(UploadPath);
                        // lưu tên file vào trường ảnh
                        baiViet.anhBaiViet = FileName;
                    }
                    else
                    {
                        baiViet.anhBaiViet = Request["oldImage"];
                    }
                    db.Entry(baiViet).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi thêm: " + e.Message;
                ViewBag.ChuDeBaiVietId = new SelectList(db.ChuDeBaiViets, "ChuDeBaiVietId", "moTaChuDe", baiViet.ChuDeBaiVietId);
                return View(baiViet);
            }
        }

        // GET: Admin/BaiViets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // POST: Admin/BaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet baiViet = db.BaiViets.Find(id);
            try
            {
                db.BaiViets.Remove(baiViet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi thêm " + e.Message;
                return View(baiViet);
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
