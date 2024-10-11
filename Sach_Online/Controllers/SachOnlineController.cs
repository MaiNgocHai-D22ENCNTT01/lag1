using Sach_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sach_Online.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        QLBANSACHEntities1 db = new QLBANSACHEntities1();
        public ActionResult Index()
        {
            var lsSach = db.SACHes.OrderByDescending(s => s.NgayCapNhat).Take(6).ToList();
            return View(lsSach);
        }

        // 
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in db.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult NXBPartical()
        {
            var listNXB = from nxb in db.NHAXUATBANs select nxb;
            return PartialView(listNXB);
        }


        public class NavViewModel
        {
            public List<CHUDE> ChuDeList { get; set; }
            public List<NHAXUATBAN> NXBList { get; set; }
        }
        public ActionResult NavPartial()
        {
            var listChuDe = db.CHUDEs.ToList();
            var listNXB = db.NHAXUATBANs.ToList();

            var model = new NavViewModel
            {
                ChuDeList = listChuDe,
                NXBList = listNXB
            };

            return PartialView(model);
        }


        public ActionResult SliderPartial()
        {
            return PartialView();
        }

        public ActionResult SachBanNhieuPartical()
        {
            var listSachBanNhieu = db.SACHes.OrderByDescending(s => s.Soluongban).Take(6).ToList();
            return PartialView(listSachBanNhieu);
        }
        public ActionResult SachTheoChuDe(int id)
        {
            var lsCD = db.SACHes.Where (s => s.MaCD == id).ToList();
            return View("Index",lsCD);
        }

        public ActionResult SachTheoNXB(int id)
        {
            var lsNXB = db.SACHes.Where(s => s.MaNXB == id).ToList();
            return View("Index", lsNXB);
        }

        public ActionResult TimKiem(string keyword)
        {
            var lsSach = db.SACHes.Where(s => s.TenSach.Contains(keyword) || s.MoTa.Contains(keyword)).ToList();
            return View("Index", lsSach);
        }

        public ActionResult Chitietsach(int id)
        {
            var sach =  db.SACHes.FirstOrDefault(s => s.MaSach == id);

            return View(sach);
        }

    }
}