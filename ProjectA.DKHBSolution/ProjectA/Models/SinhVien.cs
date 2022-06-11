using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectA.Models
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            DangKyHocBongs = new HashSet<DangKyHocBong>();
        }
        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Mã sinh viên")]
        public string IdSinhVien { get; set; }

        [Required(ErrorMessage = "Lớp phải bắt buộc")]
        [DisplayName("Lớp")]
        public string IdLop { get; set; }

        [Required(ErrorMessage = "Tên sinh viên phải bắt buộc")]
        [DisplayName("Tên sinh viên")]
        public string TenSinhVien { get; set; }

        [Required(ErrorMessage = "Mật khẩu phải bắt buộc")]
        [DisplayName("Mật khẩu")]
        public string PasswordSv { get; set; }

        [Required(ErrorMessage = "Ngày sinh phải bắt buộc")]
        [DisplayName("Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        
        [DisplayName("Email")]
        public string Email { get; set; }

        
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Giới tính phải bắt buộc")]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
        public virtual Lop IdLopNavigation { get; set; }
        public virtual ICollection<DangKyHocBong> DangKyHocBongs { get; set; }
    }
}
