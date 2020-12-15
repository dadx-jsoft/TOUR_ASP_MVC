using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOUR.Models;
using PagedList;
namespace TOUR.Controllers
{
    public class HomeController : Controller
    {
        private tourdb db = new tourdb();
        public ActionResult Index()
        {
            var tours = db.Tours.OrderByDescending(t => t.ngayTao).Take(6);

            return View(tours);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateDonHangPheDuyet([Bind(Include = "id,hoaDonId,trangThaiDuyet,ngayPheDuyet")] DonHangPheDuyet donHangPheDuyet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DonHangPheDuyets.Add(donHangPheDuyet);
                    db.SaveChanges();
                }
                return RedirectToAction("DestinationDetail", "Home", new { hoaDonid = donHangPheDuyet.hoaDonId });
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreatePhanHoiLienHe([Bind(Include = "id,tenKhachHang,sdtKhachHang,emailKhachHang,loiNhanKhachHang")] PhanHoiLienHe contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PhanHoiLienHes.Add(contact);
                    db.SaveChanges();
                }
                return RedirectToAction("Contact", "Home");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }


        [HttpGet]
        public PartialViewResult _CreatePhanHoiBlog()
        {
            return PartialView();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult _CreatePhanHoiBlog([Bind(Include = "id,tenKhachHang,sdtKhachHang,emailKhachHang,loiNhanKhachHang")] PhanHoiLienHe feedback, int id) // id bài viết
        {
            try
            {
                if (ModelState.IsValid)
                {
                    feedback.idBaiViet = id;
                    db.PhanHoiLienHes.Add(feedback);
                    db.SaveChanges();
                }
                return RedirectToAction("SingleBlog", "Home", new { id = id });
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
                //return RedirectToAction("SingleBlog", "Home", new { id = id });
            }
        }

        public ActionResult Blog(int? page, int? ChuDeBaiVietId, String searchString)
        {
            List<BaiViet> baiViets = new List<BaiViet>();
            int pageSize = 3; // Kích thước trang, hiển thị 3 bài trên trang blog
            int pageNumber = (page ?? 1); // Nếu page bằng null thì trả về 1

            if (ChuDeBaiVietId == null)
            {
                baiViets = baiViets.OrderByDescending(s => s.ngayTao).ToList();
                baiViets = db.BaiViets.Select(b => b).ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    // Tìm kiếm bài viết theo tên
                    baiViets = baiViets.Where(h => h.tieuDe.ToLower().Contains(searchString.ToLower())).ToList();
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    // Tìm kiếm bài viết theo tên
                    baiViets = db.BaiViets.Where(b => b.tieuDe.ToLower().Contains(searchString.ToLower())).Select(b => b).ToList();
                    return View(baiViets.ToPagedList(pageNumber, pageSize));
                }
                var baiViet = from bv in db.BaiViets
                              where bv.ChuDeBaiVietId == ChuDeBaiVietId
                              select bv;
                baiViets = baiViet.ToList();
            }
            return View(baiViets.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DestinationDetail(int? id, int? successInt)
        {
            var tour = db.Tours.Find(id);
            if(successInt != null)
            {
                ViewBag.success = "Đặt thành công!";
            }
            return View(tour);
        }

        public ActionResult Element()
        {
            return View();
        }

        public ActionResult SingleBlog(int id)
        {
            var baiViets = db.BaiViets.Find(id);
            return View(baiViets);
        }

        [ChildActionOnly]
        public PartialViewResult _RightSideBar(int? id)
        {
            var chuDeBaiViets = db.ChuDeBaiViets.Select(cd => cd);

            return PartialView(chuDeBaiViets);
        }

        public PartialViewResult _FilterTour()
        {
            var dongTours = db.DongTours.Select(dt => dt);

            return PartialView(dongTours);
        }
        [ChildActionOnly]
        public PartialViewResult _Join(int id)
        {
            var tour = db.Tours.Find(id);
            //var hd = db.HoaDons.Ad
            ViewBag.idTour = id;
            return PartialView(tour);
        }
        public ActionResult TravelDestination(int? page, int? dongTourId, String searchString)
        {
            List<Tour> tours = new List<Tour>();

            int pageSize = 4; // Kích thước trang, hiển thị 3 bài trên trang blog
            int pageNumber = (page ?? 1); // Nếu page bằng null thì trả về 1

            if (dongTourId == null)
            {
                tours = tours.OrderBy(t => t.tenTour).ToList();
                tours = db.Tours.Select(t => t).ToList();
                // Tìm kiếm theo tên tour
                if (!String.IsNullOrEmpty(searchString))
                {
                    tours = tours.Where(t => t.tenTour.ToLower().Contains(searchString.ToLower())).ToList();
                }
            }
            else
            {
                // Tìm kiếm theo tên tour
                if (!String.IsNullOrEmpty(searchString))
                {
                    tours = db.Tours.Where(tour => tour.tenTour.ToLower().Contains(searchString.ToLower())).Select(tour => tour).ToList();
                    return View(tours.ToPagedList(pageNumber, pageSize));
                }
                var t = from tour in db.Tours
                        where tour.dongTourId == dongTourId
                        select tour;
                tours = t.ToList();
            }
            return View(tours.ToPagedList(pageNumber, pageSize));

        }
        public PartialViewResult _CommentBlog(int id)
        {
            var phanHois = db.PhanHoiLienHes.Where(ph=>ph.idBaiViet == id).Select(ph => ph);
            return PartialView(phanHois);
        }
    }
}