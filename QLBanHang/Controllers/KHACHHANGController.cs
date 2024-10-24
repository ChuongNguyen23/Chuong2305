using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;


namespace QLBanHang.Controllers
{
    public class KHACHHANGController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: KHACHHANG

        //private  QLBanHangEntities objQLBanHangEntities;
        //public KHACHHANGController()
        //{
        //    objQLBanHangEntities = new QLBanHangEntities();
        //}

        //public IEnumerable<SelectListItem> GetAllKHACHHANG()
        //{
        //    var objSelectListItems = new List<SelectListItem>();
        //    objSelectListItems =(from obj in objQLBanHangEntities.KHACHHANGs

        //                            select new SelectListItem()
        //                            {
        //                                Text = obj.TenKH,
        //                                Value = obj.MaKH.ToString(),
        //                                Selected = true
        //                            }
        //                        ).ToList();

        //    return objSelectListItems;
        //}


        public ActionResult Index()
        {
            var ds = from ncc in db.KHACHHANGs select ncc;
            return View(ds);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KHACHHANG dl)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(dl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dl);
        }
  
        public ActionResult Delete(string id)
        {
            KHACHHANG ncc = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            KHACHHANG ncc = db.KHACHHANGs.Find(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaKH");
            KHACHHANG ncc = db.KHACHHANGs.Find(ma);
            ncc.TenKH = f.Get("TenKH");
            ncc.DiaChi = f.Get("DiaChi");
            ncc.SDT = f.Get("SDT");
            ncc.email = f.Get("email");
            ncc.STK = f.Get("STK");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}