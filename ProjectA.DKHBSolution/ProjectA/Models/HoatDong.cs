using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectA.Models
{
    public partial class HoatDong
    {
        public string IdHoatDong { get; set; }
        public string TenHoatDong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string GhiChu { get; set; }
    }
}
