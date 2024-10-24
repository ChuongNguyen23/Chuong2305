using QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanHang.Repositories
{
    public class KHACHHANGRepository
    {

        private QLBanHangEntities objQLBanHangEntities;
        public KHACHHANGRepository()
        {
            objQLBanHangEntities = new QLBanHangEntities();
        }

        public IEnumerable<SelectListItem> GetAllKHACHHANG()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objQLBanHangEntities.KHACHHANGs
                                  select new SelectListItem()
                                  {
                                      Text = obj.TenKH,
                                      Value = obj.MaKH.ToString(),
                                      Selected = true
                                  }
                                ).ToList();

            return objSelectListItems;
        }
    }
}