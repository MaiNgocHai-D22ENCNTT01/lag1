using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lag1.Models;

namespace lag1.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        QLBANSACHEntities db = new QLBANSACHEntities();
        public ActionResult Index()
        {
            var lstsach = db.SACHes.OrderByDescending(s => s.NgayCapNhat).Take(7);
            return View(lstsach);
        }
        /// <summary>
        /// GetChuDe
        /// </summary>
        /// <returns>ReturnChuDe</returns>
        public ActionResult ChuDePartial()
        {
            var lstchude = db.CHUDEs.ToList();
            return PartialView(lstchude);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var lstNhaxuatban = db.NHAXUATBANs.ToList();
            return PartialView(lstNhaxuatban);
        }
        public ActionResult SliderPartial()
        {
            return PartialView();
        }
        public ActionResult NavbarPartial()
        {
            return PartialView();
        }
        public ActionResult SachBanNhieuPartial()
        {
            var lstSachBanNhieu = db.SACHes.OrderByDescending( s => s.Soluongban).Take(3).ToList();
            return PartialView(lstSachBanNhieu);
        }
        public ActionResult Sachtheochude(int id)
        {
            var lstSachchude = db.SACHes.Where(s => s.MaCD == id).ToList();
            return View("index",lstSachchude);
        }
        public ActionResult SachtheoNXB(int id)
        {
            var lstSachNXB = db.SACHes.Where(s => s.MaNXB == id).ToList();
            return View("index", lstSachNXB);
        }

    }
}