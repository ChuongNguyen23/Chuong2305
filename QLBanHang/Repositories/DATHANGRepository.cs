using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLBanHang.Models;
using QLBanHang.ViewModels;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;

namespace QLBanHang.Repositories
{
    public class DATHANGRepository
    {
        private readonly QLBanHangEntities restaurantDBEntities;
        public DATHANGRepository()
        {
            restaurantDBEntities = new QLBanHangEntities();
        }

        public bool AddOrder(DATHANGViewModel orderViewModel)
        {
            try
            {
                DATHANG objDATHANG = new DATHANG()
                {
                    MaKH = orderViewModel.MaKH,
                    TongSoCuoiCung = orderViewModel.TongSoCuoiCung,
                    NgayDatHang = orderViewModel.NgayDatHang,
                    SoDonHang = String.Format("{0:ddmmyyyyhhmmss}", DateTime.Now),
                    MaDonBan = orderViewModel.MaDonBan,
                };
                restaurantDBEntities.DATHANGs.Add(objDATHANG);
                restaurantDBEntities.SaveChanges();

                foreach (var item in orderViewModel.listCHITIETDATHANGViewModel)
                {
                    var objCHITIETDATHANG= new CHITIETDATHANG()
                    {
                        GiamGia = item.GiamGia,
                        MaSP = item.MaSP,
                        SoLuong = item.SoLuong,
                        IdDatHang = objDATHANG.IdDatHang,
                        TongCong = item.TongCong,
                        DonGia = item.DonGia
                    };
                    restaurantDBEntities.CHITIETDATHANGs.Add(objCHITIETDATHANG);
                    restaurantDBEntities.SaveChanges();

                    GIAODICH objGIAODICH = new GIAODICH()
                    {
                        MaSP = item.MaSP,
                        SoLuong = (-1) * item.SoLuong,
                        NgayGiaoDich = orderViewModel.NgayDatHang,
                 
                    };
                    restaurantDBEntities.GIAODICHes.Add(objGIAODICH);
                    restaurantDBEntities.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}