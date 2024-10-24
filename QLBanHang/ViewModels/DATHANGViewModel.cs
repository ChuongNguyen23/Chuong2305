using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBanHang.ViewModels
{
    public class DATHANGViewModel
    {
        public int IdDatHang { get; set; }
        public string MaDonBan { get; set; }
        public string MaKH { get; set; }
        public string SoDonHang { get; set; }
        public DateTime NgayDatHang { get { return DateTime.Now; } }
        public decimal TongSoCuoiCung { get; set; }
        public IEnumerable<CHITIETDATHANGViewModel> listCHITIETDATHANGViewModel { get; set; }

    }
}