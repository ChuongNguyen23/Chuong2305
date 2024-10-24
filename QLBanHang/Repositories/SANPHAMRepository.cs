using QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanHang.Repositories
{
    public class SANPHAMRepository
    {

        private QLBanHangEntities objQLBanHangEntities;
        public SANPHAMRepository()
        {
            objQLBanHangEntities = new QLBanHangEntities();
        }

        public IEnumerable<SelectListItem> GetAllSANPHAM()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objQLBanHangEntities.SANPHAMs
                                  select new SelectListItem()
                                  {
                                      Text = obj.TenSP,
                                      Value = obj.MaSP.ToString(),
                                      Selected = true
                                  }
                                ).ToList();

            return objSelectListItems;
        }
    }
}