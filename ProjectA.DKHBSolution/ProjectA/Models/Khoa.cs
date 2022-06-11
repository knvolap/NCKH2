using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectA.Models
{
    public partial class Khoa
    {
        public Khoa()
        {
            Nganhs = new HashSet<Nganh>();
        }

        public string IdKhoa { get; set; }
        public string TenKhoa { get; set; }

        public virtual ICollection<Nganh> Nganhs { get; set; }
    }
}
