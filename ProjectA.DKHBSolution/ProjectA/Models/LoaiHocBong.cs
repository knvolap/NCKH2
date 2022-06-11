using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectA.Models
{
    public partial class LoaiHocBong
    {
        public LoaiHocBong()
        {
            HocBongs = new HashSet<HocBong>();
        }

        public string IdLhb { get; set; }
        public string TenLhb { get; set; }

        public virtual ICollection<HocBong> HocBongs { get; set; }
    }
}
