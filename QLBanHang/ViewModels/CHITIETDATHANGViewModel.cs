using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBanHang.ViewModels
{
    public class CHITIETDATHANGViewModel
    {
        public int IdChiTietDatHang { get; set; }
        public int IdDatHang { get; set; }
        public string MaSP { get; set; }
        public decimal DonGia { get; set; }
        public decimal SoLuong { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongCong { get; set; }

    }
}