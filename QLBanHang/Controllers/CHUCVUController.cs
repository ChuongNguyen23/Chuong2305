using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;


namespace QLBanHang.Controllers
{
    public class CHUCVUController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: CHUCVU
        public ActionResult Index()
        {
            var ds = from ncc in db.CHUCVUs select ncc;
            return View(ds);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CHUCVU dl)
        {
            if (ModelState.IsValid)
            {
                db.CHUCVUs.Add(dl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dl);
        }
        public ActionResult Details(string id)
        {

            CHUCVU ncc = db.CHUCVUs.Find(id);

            return View(ncc);
        }
        public ActionResult Delete(string id)
        {
            CHUCVU ncc = db.CHUCVUs.Find(id);
            db.CHUCVUs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            CHUCVU ncc = db.CHUCVUs.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaCV");
            CHUCVU ncc = db.CHUCVUs.Find(ma);
            ncc.TenCV = f.Get("TenCV");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}