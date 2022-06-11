using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectA.Models
{
    public partial class HocKy
    {
        public string IdHocKy { get; set; }
        public string TenHocKy { get; set; }
        public DateTime NamHoc { get; set; }
        public DateTime TgBatDau { get; set; }
        public DateTime TgKetThuc { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
    }
}
