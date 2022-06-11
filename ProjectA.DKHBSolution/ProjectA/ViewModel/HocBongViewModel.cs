using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.ViewModel
{
    public class HocBongViewModel
    {
        [Required(ErrorMessage = "Mã học bổng phải bắt buộc")]
        [DisplayName("Mã học bổng")]
        public string IdHocBong { get; set; }

        [DisplayName("Loại học bổng")]
        public string TenLhb { get; set; }

        [Required(ErrorMessage = "Tên học bổng phải bắt buộc")]
        [DisplayName("Tên học bổng")]
        public string TenHb { get; set; }


        [DisplayName("Nội dung")]
        public string NoiDungHb { get; set; }

        [Required(ErrorMessage = "Đối tượng áp dụng phải bắt buộc")]
        [DisplayName("Đối tượng áp dụng")]
        public string DoiTuongApDung { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu phải bắt buộc")]
        [DisplayName("Ngày bắt đầu")]
        public DateTime NgayBatDau { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc phải bắt buộc")]
        [DisplayName("Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }

        [Required(ErrorMessage = "Kinh phí phải bắt buộc")]
        [DisplayName("Kinh phí")]
        public decimal? KinhPhi { get; set; }

        [Required(ErrorMessage = "Số lượng phải bắt buộc")]
        [DisplayName("Số lượng")]
        public short SoLuong { get; set; }


        [DisplayName("Ngày dự kiến")]
        public DateTime? NgayDuKienPhatHb { get; set; }
    }
}
