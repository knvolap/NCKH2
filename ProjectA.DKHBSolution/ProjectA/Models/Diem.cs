using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectA.Models
{
    public partial class Diem
    {

        [Required(ErrorMessage = "Học kỳ phải bắt buộc")]
        [DisplayName("Học kỳ")]
        public string IdHocKy { get; set; }

        [Required(ErrorMessage = "Sinh viên phải bắt buộc")]
        [DisplayName("Mã sinh viên")]
        public string IdSinhVien { get; set; }

        [Required(ErrorMessage = "Điểm thang 4 phải bắt buộc")]
        [DisplayName("Điểm thang 4")]
        public double? DiemThang4 { get; set; }

        [Required(ErrorMessage = "Điểm thang 10 phải bắt buộc")]
        [DisplayName("Điểm thang 10")]
        public double? DiemThang10 { get; set; }

        [Required(ErrorMessage = "Số tín chỉ phải bắt buộc")]
        [DisplayName("Số tín chỉ")]
        public int SoTinChi { get; set; }

        [Required(ErrorMessage = "Xếp loại phải bắt buộc")]
        [DisplayName("Xếp loại")]
        public string XepLoai { get; set; }

        [Required(ErrorMessage = "Điểm rèn luyện phải bắt buộc")]
        [DisplayName("Điểm rèn luyện")]
        public byte DiemRenLuyen { get; set; }

        public virtual HocKy IdHocKyNavigation { get; set; }
        public virtual SinhVien IdSinhVienNavigation { get; set; }
    }
}
