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
    public class ChuDeBaiVietsController : BaseController
    {
        private tourdb db = new tourdb();

        // GET: Admin/ChuDeBaiViets
        public ActionResult Index()
        {
            return View(db.ChuDeBaiViets.ToList());
        }

        // GET: Admin/ChuDeBaiViets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDeBaiViet chuDeBaiViet = db.ChuDeBaiViets.Find(id);
            if (chuDeBaiViet == null)
            {
                return HttpNotFound();
            }
            return View(chuDeBaiViet);
        }

        // GET: Admin/ChuDeBaiViets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChuDeBaiViets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChuDeBaiVietId,moTaChuDe")] ChuDeBaiViet chuDeBaiViet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ChuDeBaiViets.Add(chuDeBaiViet);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi tạo " + e.Message;
                return View(chuDeBaiViet);
            }
        }

        // GET: Admin/ChuDeBaiViets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDeBaiViet chuDeBaiViet = db.ChuDeBaiViets.Find(id);
            if (chuDeBaiViet == null)
            {
                return HttpNotFound();
            }
            return View(chuDeBaiViet);
        }

        // POST: Admin/ChuDeBaiViets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChuDeBaiVietId,moTaChuDe")] ChuDeBaiViet chuDeBaiViet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(chuDeBaiViet).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi sửa " + e.Message;
                return View(chuDeBaiViet);
            }
        }

        // GET: Admin/ChuDeBaiViets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDeBaiViet chuDeBaiViet = db.ChuDeBaiViets.Find(id);
            if (chuDeBaiViet == null)
            {
                return HttpNotFound();
            }
            return View(chuDeBaiViet);
        }

        // POST: Admin/ChuDeBaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuDeBaiViet chuDeBaiViet = db.ChuDeBaiViets.Find(id);
            try
            {
                db.ChuDeBaiViets.Remove(chuDeBaiViet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = "Lỗi xóa " + e.Message;
                return View(chuDeBaiViet);
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
