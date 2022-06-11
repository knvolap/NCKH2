using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable

namespace ProjectA.Models
{
    public partial class Lop
    {
        public Lop()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public string IdLop { get; set; }
        public string IdNganh { get; set; }
        public string TenLop { get; set; }
        public string NienKhoa { get; set; }

        
        public virtual Nganh IdNganhNavigation { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
