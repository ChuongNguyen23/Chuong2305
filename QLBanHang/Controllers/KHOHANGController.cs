using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;


namespace QLBanHang.Controllers
{
    public class KHOHANGController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: KHOHANG
        public ActionResult Index()
        {
            var ds = from ncc in db.KHOHANGs select ncc;
            return View(ds);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KHOHANG dl)
        {
            if (ModelState.IsValid)
            {
                db.KHOHANGs.Add(dl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dl);
        }
       
        public ActionResult Delete(string id)
        {
            KHOHANG ncc = db.KHOHANGs.Find(id);
            db.KHOHANGs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            KHOHANG  ncc = db.KHOHANGs.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaKho");
            KHOHANG ncc = db.KHOHANGs.Find(ma);
            ncc.TenKho = f.Get("TenKho");
            ncc.DiaChi = f.Get("DiaChi");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}