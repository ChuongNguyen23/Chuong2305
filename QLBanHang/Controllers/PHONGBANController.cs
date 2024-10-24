using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;


namespace QLBanHang.Controllers
{
    public class PHONGBANController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();

        // GET: PHONGBAN
        public ActionResult Index()
        {
            var ds = from ncc in db.PHONGBANs select ncc;
            return View(ds);
        }
        public ActionResult Create()
        {        
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PHONGBAN dl)
        {
            if (ModelState.IsValid)
            {
                db.PHONGBANs.Add(dl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dl);
        }
        public ActionResult Details(string id)
        {

            PHONGBAN ncc = db.PHONGBANs.Find(id);

            return View(ncc);
        }
        public ActionResult Delete(string id)
        {
            PHONGBAN ncc = db.PHONGBANs.Find(id);
            db.PHONGBANs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            PHONGBAN ncc = db.PHONGBANs.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaPB");
            PHONGBAN ncc = db.PHONGBANs.Find(ma);
            ncc.TenPB = f.Get("TenPB");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}