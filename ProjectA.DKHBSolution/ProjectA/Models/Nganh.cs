using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectA.Models
{
    public partial class Nganh
    {
        public Nganh()
        {
            Lops = new HashSet<Lop>();
        }

        public string IdNganh { get; set; }
        public string IdKhoa { get; set; }
        public string TenNganh { get; set; }

        public virtual Khoa IdKhoaNavigation { get; set; }
        public virtual ICollection<Lop> Lops { get; set; }
    }
}
