//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETKM
    {
        public string MaKM { get; set; }
        public string MaSP { get; set; }
        public string ThoiHanKM { get; set; }
        public Nullable<double> GiaTriKM { get; set; }
        public string GhiChu { get; set; }
    
        public virtual HANGKHUYENMAI HANGKHUYENMAI { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}