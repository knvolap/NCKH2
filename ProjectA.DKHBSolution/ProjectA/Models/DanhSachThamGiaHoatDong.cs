using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectA.Models
{
    public partial class DanhSachThamGiaHoatDong
    {
        public string IdDangKy { get; set; }
        public string IdHoatDong { get; set; }
        public string IdCapDo { get; set; }
        public string IdLoaiGiai { get; set; }
        public byte[] MinhChung { get; set; }
        public byte DiemHoatDong { get; set; }

        public virtual CapDoHoatDong IdCapDoNavigation { get; set; }
        public virtual DangKyHocBong IdDangKyNavigation { get; set; }
        public virtual HoatDong IdHoatDongNavigation { get; set; }
        public virtual LoaiGiai IdLoaiGiaiNavigation { get; set; }
    }
}
