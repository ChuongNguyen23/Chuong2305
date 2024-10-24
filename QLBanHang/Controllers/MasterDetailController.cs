using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;
using QLBanHang.Repositories;
using QLBanHang.ViewModels;

namespace QLBanHang.Controllers
{
    public class MasterDetailController : Controller
    {
        private QLBanHangEntities objQLBanHangEntities;
        public MasterDetailController()
        {
            objQLBanHangEntities = new QLBanHangEntities();

        }
        // GET: MasterDetail
        public ActionResult Index()
        {
            KHACHHANGRepository objKHACHHANGRepository = new KHACHHANGRepository();
            SANPHAMRepository objSANPHAMRepository = new SANPHAMRepository();
            DONBANHANGRepository objDONBANHANGRepository = new DONBANHANGRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                    (objKHACHHANGRepository.GetAllKHACHHANG(), objSANPHAMRepository.GetAllSANPHAM(), objDONBANHANGRepository.GetAllDONBANHANG());
            return View(objMultipleModels);
        }

        [HttpPost]
        public JsonResult Index(DATHANGViewModel objDATHANGViewModel)
        {
            DATHANGRepository objDATHANGRepository = new DATHANGRepository();
            bool isStatus = objDATHANGRepository.AddOrder(objDATHANGViewModel);
            string SuccessMessage = String.Empty;

            if (isStatus)
            {
                SuccessMessage = "Đơn hàng của bạn đã được đặt thành công.";
            }
            else
            {
                SuccessMessage = "Có một số vấn đề trong khi đặt hàng.";
            }
            return Json(SuccessMessage, JsonRequestBehavior.AllowGet);
        }
    }
}