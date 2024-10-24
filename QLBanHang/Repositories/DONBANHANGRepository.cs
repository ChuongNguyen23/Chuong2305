using QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanHang.Repositories
{
    public class DONBANHANGRepository
    {
        private QLBanHangEntities objQLBanHangEntities;
        public DONBANHANGRepository()
        {
            objQLBanHangEntities = new QLBanHangEntities();
        }

        public IEnumerable<SelectListItem> GetAllDONBANHANG()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objQLBanHangEntities.DONBANHANGs
                                  select new SelectListItem()
                                  {
                                      Text = obj.KieuThanhToan,
                                      Value = obj.MaDonBan.ToString(),
                                      Selected = true
                                  }
                                ).ToList();

            return objSelectListItems;
        }
    }
}