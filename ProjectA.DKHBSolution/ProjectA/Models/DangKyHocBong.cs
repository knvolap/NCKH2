using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectA.Models
{
    public partial class DangKyHocBong
    {
        
        [DisplayName("Mã đăng ký")]
        public string IdDangKy { get; set; }

        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Mã sinh viên")]
        public string IdSinhVien { get; set; }

        
        [DisplayName("Mã học bổng")]
        public string IdHocBong { get; set; }

        
        [DisplayName("Thời gian")]
        public DateTime TgDangKy { get; set; }

        [DisplayName("Tình trạng")]
        public string TinhTrang { get; set; }

        public virtual HocBong IdHocBongNavigation { get; set; }
        public virtual SinhVien IdSinhVienNavigation { get; set; }
    }
}
