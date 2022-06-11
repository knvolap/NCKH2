using ProjectA.Models;
using ProjectA.Service;
using ProjectA.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Repository
{
    public class XetHocBongRepository : IXetHocBong
    {
        private readonly ApplicationDbContext _context;
        public XetHocBongRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public XetHocBongViewModel[] DanhSachDatHocBong()
        {
            double heSo = 1;
            double soTien = 5320000;
            var sinhVien = from sv in _context.SinhViens
                           join d in _context.Diems on sv.IdSinhVien equals d.IdSinhVien
                           join l in _context.Lops on sv.IdLop equals l.IdLop
                           join hk in _context.HocKies on d.IdHocKy equals hk.IdHocKy                          
                           select new { sv,l, d, hk };
            var query = sinhVien.Select(x => new XetHocBongViewModel()
            {
                IdSinhVien = x.sv.IdSinhVien,
                TenSinhVien = x.sv.TenSinhVien,
                IdLop = x.l.IdLop,
                IdHocKy = x.hk.IdHocKy,
                SoTinChi = x.d.SoTinChi,
                DiemThang10 = x.d.DiemThang4,
                DiemThang4 = x.d.DiemThang10,
                XepLoai = x.d.XepLoai,
                SoTien = heSo * soTien
            });
            return query.ToArray();
        }

        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = totalProduct / limit;
            return (int)Math.Ceiling(numberpage);

        }

        public XetHocBongViewModel[] paginationProduct(int start, int limit)
        {
            int tongSoSV = 2000;
            int soSVKhoaDien = 700;
            int soSVKhoaCo = 600;
            int soSVKhoaCNMT = 150;
            int soSVKhoaKTXD = 350;
            int soSVKhoaSP = 200;
            int tongSoHocBong = 50;

            float phanTramSVKhoaDien = (soSVKhoaDien * 100) / tongSoSV;
            float phanTramSVKhoaCo = (soSVKhoaCo * 100) / tongSoSV;
            float phanTramSVKhoaCNMT = (soSVKhoaCNMT * 100) / tongSoSV;
            float phanTramSVKhoaKTXD = (soSVKhoaKTXD * 100) / tongSoSV;
            float phanTramSVKhoaSP = (soSVKhoaSP * 100) / tongSoSV;

            int hbKhoaDien = Convert.ToInt32((phanTramSVKhoaDien * 50) / 100);
            double heSo = 1;
            double soTien = 5320000;
            var sinhVien = from sv in _context.SinhViens
                           join d in _context.Diems on sv.IdSinhVien equals d.IdSinhVien
                           join l in _context.Lops on sv.IdLop equals l.IdLop
                           join hk in _context.HocKies on d.IdHocKy equals hk.IdHocKy
                           orderby d.DiemThang4 descending
                           select new { sv, d, l, hk };
            var query = sinhVien.Select(x => new XetHocBongViewModel()
            {
                IdSinhVien = x.sv.IdSinhVien,
                TenSinhVien = x.sv.TenSinhVien,
                IdLop = x.l.IdLop,
                IdHocKy = x.hk.IdHocKy,
                SoTinChi = x.d.SoTinChi,
                DiemThang10 = x.d.DiemThang10,
                DiemThang4 = x.d.DiemThang4,
                XepLoai = x.d.XepLoai,
                SoTien = heSo * soTien
            });
            var dataProduct = query.OrderByDescending(x => x.DiemThang4).Skip(start).Take(limit);

            return dataProduct.ToArray();
        }

        public int totalProduct()
        {
            return _context.Diems.Count();
        }
    }
}
