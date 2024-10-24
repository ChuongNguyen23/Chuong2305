using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;
using PagedList;

namespace QLBanHang.Controllers
{
    public class SANPHAMController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();


        public ActionResult Index(int? page)
        {
            int pageSize = 3; // Số mục trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại, mặc định là trang 1
            var products = db.SANPHAMs.OrderBy(p => p.TenSP).ToPagedList(pageNumber, pageSize);
            return View(products);
        }
        public ActionResult Create()
        {
            //dropdown nhóm hàng
            var dmnh = db.NHOMHANGs;
            List<NHOMHANG> lstnh = dmnh.ToList();
            SelectList listnh = new SelectList(lstnh, "MaNH", "TenNH");
            ViewBag.dsnhomhang = listnh;

            //dropdown kho hàng
            var dmkh = db.KHOHANGs;
            List<KHOHANG> lstkho = dmkh.ToList();
            SelectList listkho = new SelectList(lstkho, "MaKho", "TenKho");
            ViewBag.dskhohang = listkho;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SANPHAM dl)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(dl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dl);
        }
        public ActionResult Details(string id)
        {

            SANPHAM ncc = db.SANPHAMs.Find(id);

            return View(ncc);
        }
        public ActionResult Delete(string id)
        {
            SANPHAM ncc = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            SANPHAM ncc = db.SANPHAMs.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaSP");
            SANPHAM ncc = db.SANPHAMs.Find(ma);
            ncc.MaNH = f.Get("MaNH");
            ncc.MaKho = f.Get("MaKho");
            ncc.TenSP = f.Get("TenSP");
            ncc.CPU = f.Get("CPU");
            ncc.RAM = f.Get("RAM");
            ncc.DungLuong = f.Get("DungLuong");
            ncc.KichThuoc = f.Get("KichThuoc");
            ncc.NhaSX = f.Get("NhaSX");
            ncc.NuocSX = f.Get("NuocSX");
            ncc.GiaBan = f.Get("GiaBan");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
