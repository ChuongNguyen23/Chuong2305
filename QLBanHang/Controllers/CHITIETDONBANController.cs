using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;


namespace QLBanHang.Controllers
{
    public class CHITIETDONBANController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: CHUCVU
        public ActionResult Index()
        {
            var ds = from ncc in db.CHITIETDONBANs select ncc;
            return View(ds);
        }
        public ActionResult Create()
        {
            //dropdown 
         
            var dmnh = db.SANPHAMs;
            List<SANPHAM> lstnh = dmnh.ToList();
            SelectList listnh = new SelectList(lstnh, "MaSP", "TenSP");
            ViewBag.dsnhomhang = listnh;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CHITIETDONBAN dl)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDONBANs.Add(dl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dl);
        }
      
        public ActionResult Delete(string id)
        {
            CHITIETDONBAN ncc = db.CHITIETDONBANs.Find(id);
            db.CHITIETDONBANs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            CHITIETDONBAN ncc = db.CHITIETDONBANs.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaDonBan");
            CHITIETDONBAN ncc = db.CHITIETDONBANs.Find(ma);
            ncc.MaSP = f.Get("MaSP");
            ncc.GiaBan = Convert.ToDouble("GiaBan");
            ncc.SoLuong = (int?)Convert.ToInt64("SoLuong");
            ncc.MaSP = f.Get("MaSP");
            ncc.TenSP = f.Get("TenSP");

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}