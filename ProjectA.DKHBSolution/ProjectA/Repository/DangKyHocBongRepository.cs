using Microsoft.EntityFrameworkCore;
using ProjectA.Models;
using ProjectA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Repository
{
    public class DangKyHocBongRepository : IDangKyHocBong
    {
        private ApplicationDbContext _context;
        public DangKyHocBongRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(DangKyHocBong dangKyHocBong)
        {
            throw new NotImplementedException();
        }

        public HocBong Create()
        {
            throw new NotImplementedException();
        }

        public HocBong Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DangKyHocBong> GetHocBongById(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DangKyHocBong> GetHocBongs => _context.DangKyHocBongs;
       

        public void Remove(string Id)
        {
            throw new NotImplementedException();
        }

        public void Update(HocBong hocBong)
        {
            throw new NotImplementedException();
        }
    }
}
