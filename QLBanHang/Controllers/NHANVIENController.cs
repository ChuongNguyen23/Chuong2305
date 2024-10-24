using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;


namespace QLBanHang.Controllers
{
    public class NHANVIENController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: NHANVIEN
        public ActionResult Index()
        {
            var ds = from ncc in db.NHANVIENs select ncc;
            return View(ds);
        }
        public ActionResult Create()
        {
                //dropdown phòng ban
                var dmnh = db.PHONGBANs;
                List<PHONGBAN> lstnh = dmnh.ToList();
                SelectList listnh = new SelectList(lstnh, "MaPB", "TenPB");
                ViewBag.dsnhomhang = listnh;

            //dropdown chức vụ
            var dmkh = db.CHUCVUs;
            List<CHUCVU> lstkho = dmkh.ToList();
            SelectList listkho = new SelectList(lstkho, "MaCV","TenCV");
            ViewBag.dskhohang = listkho;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NHANVIEN dl)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(dl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dl);
        }
        public ActionResult Delete(string id)
        {
            NHANVIEN ncc = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            NHANVIEN ncc = db.NHANVIENs.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaNV");
            NHANVIEN ncc = db.NHANVIENs.Find(ma);
            ncc.MaPB = f.Get("MaPB");
            ncc.MaCV = f.Get("MaCV");
            ncc.TenNV = f.Get("TenNV");
            ncc.NgaySinh = Convert.ToDateTime("NgaySinh");
            ncc.GioiTinh = f.Get("GioiTinh");
            ncc.DiaChi = f.Get("DiaChi");
            ncc.SDT = f.Get("SDT");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



