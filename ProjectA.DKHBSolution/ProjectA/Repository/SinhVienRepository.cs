using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using ProjectA.ViewModel;
namespace ProjectA.Models
{
    public class SinhVienRepository : ISinhVien
    {
        private ApplicationDbContext _context;
        public SinhVienRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SinhVien> GetStudents => _context.SinhViens.Include(x=>x.IdLopNavigation);

        public Diem Create()
        {
            var b = new Diem()
            {
                
            };
            return b;
        }

        public void Add(Diem sinhVien)
        {
            _context.Diems.Add(sinhVien);
            _context.SaveChanges();
        }

        public XetHocBongViewModel GetSinhVienById(string Id)
        {
            var sinhVien = from sv in _context.SinhViens
                           join d in _context.Diems on sv.IdSinhVien equals d.IdSinhVien
                           join l in _context.Lops on sv.IdLop equals l.IdLop
                           where sv.IdSinhVien == Id
                           select new { sv, d, l };
            var query = sinhVien.Select(x => new XetHocBongViewModel()
            {
                IdSinhVien = x.sv.IdSinhVien,
                TenSinhVien = x.sv.TenSinhVien,
                IdLop = x.l.IdLop,
                PasswordSv = x.sv.PasswordSv,
                NgaySinh = x.sv.NgaySinh,
                Email = x.sv.Email,
                SoDienThoai = x.sv.SoDienThoai,
                GioiTinh = x.sv.GioiTinh,
                DiaChi = x.sv.DiaChi
            }).FirstOrDefault();
            return query;
        }

        public void Remove(string Id)
        {
            var b = Get(Id);
            _context.SinhViens.Remove(b);
            _context.SaveChanges();
        }
        public void Update(SinhVien sinhVien)
        {
            _context.SinhViens.Update(sinhVien);
            _context.SaveChanges();
        }
        public SinhVien Get(string id) => _context.SinhViens.Include(b=>b.Diems).FirstOrDefault(s => s.IdSinhVien == id);

        public SinhVien[] GetListSV(string search)
        {
            var movies = from m in _context.SinhViens
                         select m;

            if (!String.IsNullOrEmpty(search))
            {
                movies = movies.Where(
                    s => s.IdSinhVien.Contains(search) ||
                    s.TenSinhVien.Contains(search) ||
                    s.IdLop.Contains(search));
            }
            return movies.ToArray();
        }

        public async Task<List<SinhVienViewModel>> GetSinhViens()
        {
            var query = from p in _context.SinhViens
                        join pt in _context.Lops on p.IdLop equals pt.IdLop
                        select new { p, pt };

            return await query.Select(x => new SinhVienViewModel()
            {
                IdSinhVien = x.p.IdSinhVien,
                TenSinhVien = x.p.TenSinhVien,
                TenLop = x.pt.TenLop,
                NgaySinh = x.p.NgaySinh,
                GioiTinh = x.p.GioiTinh
            }).ToListAsync();
        }
        

        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = totalProduct / limit;
            return (int)Math.Ceiling(numberpage);

        }

        public IEnumerable<XetHocBongViewModel> paginationProduct(int start, int limit)
        {
            var sinhVien = from sv in _context.SinhViens
                           join d in _context.Diems on sv.IdSinhVien equals d.IdSinhVien
                           join l in _context.Lops on sv.IdLop equals l.IdLop
                           join hk in _context.HocKies on d.IdHocKy equals hk.IdHocKy
                           select new { sv, d, l, hk };
            var query = sinhVien.Select(x => new XetHocBongViewModel()
            {
                IdSinhVien = x.sv.IdSinhVien,
                TenSinhVien = x.sv.TenSinhVien,
                IdHocKy = x.hk.IdHocKy,
                IdLop = x.l.IdLop,
                SoTinChi = x.d.SoTinChi,
                DiemThang10 = x.d.DiemThang10,
                DiemThang4 = x.d.DiemThang4,
                XepLoai = x.d.XepLoai,
                DiemRenLuyen = x.d.DiemRenLuyen
            }).OrderByDescending(x => x.DiemThang4).Skip(start).Take(limit);
            return query.ToList();
        }

        public int totalProduct()
        {
            return _context.SinhViens.Count();
        }

        

        public SinhVien CreateNewSinhVien()
        {
            var max = _context.SinhViens.Max(b => b.IdSinhVien);
            var b = new SinhVien()
            {
                IdSinhVien = Convert.ToString(Convert.ToInt64(max) + 1)           
            };
            return b;
        }

        public void AddNewSinhVien(SinhVien sinhVien)
        {
            _context.SinhViens.Add(sinhVien);
            _context.SaveChanges();
        }
    }
}
