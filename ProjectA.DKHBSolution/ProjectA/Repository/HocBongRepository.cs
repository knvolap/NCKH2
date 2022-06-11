using Microsoft.EntityFrameworkCore;
using ProjectA.Models;
using ProjectA.Service;
using ProjectA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Repository
{
    public class HocBongRepository : IHocBong
    {
        private readonly ApplicationDbContext _context;
        public HocBongRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       

        public HocBong Create()
        {
            var max = _context.HocBongs.Max(b => b.IdHocBong);

            var b = new HocBong()
            {
                IdHocBong = Convert.ToString(Convert.ToInt64(max) + 1)
            };
            return b;
        }

        public HocBong Get(string id) => _context.HocBongs.FirstOrDefault(s => s.IdHocBong == id);      

        public async Task<HocBongViewModel> GetHocBongById(string Id)
        {
            var hocbong = from hb in _context.HocBongs
                          join lhb in _context.LoaiHocBongs on hb.IdLhb equals lhb.IdLhb
                          where hb.IdHocBong == Id
                          select new { hb, lhb };
            var query = await hocbong.Select(x => new HocBongViewModel()
            {
                IdHocBong = x.hb.IdHocBong,
                TenLhb = x.lhb.TenLhb,
                TenHb = x.hb.TenHb,
                NoiDungHb = x.hb.NoiDungHb,
                DoiTuongApDung = x.hb.DoiTuongApDung,
                NgayBatDau = x.hb.NgayBatDau,
                NgayKetThuc = x.hb.NgayKetThuc,
                KinhPhi = x.hb.KinhPhi,
                SoLuong = x.hb.SoLuong,
                NgayDuKienPhatHb = x.hb.NgayDuKienPhatHb
            }).FirstOrDefaultAsync();
            return query;
        }

        public async Task<IEnumerable<HocBongViewModel>> GetHocBongs()
        {
            var hocbong = from hb in _context.HocBongs
                          join lhb in _context.LoaiHocBongs on hb.IdLhb equals lhb.IdLhb
                          select new { hb, lhb };
            var query = await hocbong.Select(x => new HocBongViewModel()
            {
                IdHocBong = x.hb.IdHocBong,
                TenLhb = x.lhb.TenLhb,
                TenHb = x.hb.TenHb,
                NoiDungHb = x.hb.NoiDungHb,
                DoiTuongApDung = x.hb.DoiTuongApDung,
                NgayBatDau = x.hb.NgayBatDau,
                NgayKetThuc = x.hb.NgayKetThuc,
                KinhPhi = x.hb.KinhPhi,
                SoLuong = x.hb.SoLuong,
                NgayDuKienPhatHb = x.hb.NgayDuKienPhatHb
            }).ToListAsync();   
            return query;
        }

        public void Remove(string Id)
        {
            var b = Get(Id);
            _context.HocBongs.Remove(b);
            _context.SaveChanges();
        }

        public void Update(HocBong hocBong)
        {
            _context.HocBongs.Update(hocBong);
            _context.SaveChanges();
        }

        public void Add(HocBong hocBong)
        {
            _context.HocBongs.Add(hocBong);
            _context.SaveChanges();
        }
    }
}
