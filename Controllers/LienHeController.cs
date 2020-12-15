using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOUR.Models;

namespace TOUR.Controllers
{
    public class LienHeController : Controller
    {
        private tourdb db = new tourdb();
        // GET: LienHe
        //[ChildActionOnly]
        public PartialViewResult _LienHe()
        {
            var congTy = db.LienHes.SingleOrDefault();

            return PartialView(congTy);
        }
    }
}