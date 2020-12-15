using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOUR.Models;

namespace TOUR.Controllers
{
    public class HoaDonController : Controller
    {
        private tourdb db = new tourdb();
        // GET: HoaDon
        public ActionResult Index()
        {
            return View();
        }

        // GET: HoaDon/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: HoaDon/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hoaDonId,tenKhachHang,sdtKhachHang,idTour")] HoaDon hoaDon)
        {
            var tour = db.Tours.SingleOrDefault(t => t.idTour == hoaDon.idTour);
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                ViewBag.success = "Đặt tour thành công";
                //return RedirectToAction("DestinationDetail", "home", new { id = hoaDon.idTour });
                return RedirectToAction("DestinationDetail", "Home", new { id = hoaDon.idTour, successInt = 1 });
            }

            ViewBag.idTour = new SelectList(db.Tours, "idTour", "diaDiem", hoaDon.idTour);
            return View("DestinationDetail", "Home", new { id = hoaDon.idTour });
        }

        // GET: HoaDon/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: HoaDon/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: HoaDon/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: HoaDon/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
