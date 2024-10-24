using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;


namespace QLBanHang.Controllers
{
    public class NHOMHANGController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: NHOMHANG
        public ActionResult Index()
        {
            var ds = from ncc in db.NHOMHANGs select ncc;
            return View(ds);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NHOMHANG dl)
        {
            if (ModelState.IsValid)
            {
                db.NHOMHANGs.Add(dl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dl);
        }
       
        public ActionResult Delete(string id)
        {
            NHOMHANG ncc = db.NHOMHANGs.Find(id);
            db.NHOMHANGs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            NHOMHANG ncc = db.NHOMHANGs.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaNH");
            NHOMHANG ncc = db.NHOMHANGs.Find(ma);
            ncc.TenNH = f.Get("TenNH");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}