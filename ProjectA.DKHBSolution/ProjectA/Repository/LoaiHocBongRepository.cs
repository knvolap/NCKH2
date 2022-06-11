using ProjectA.Models;
using ProjectA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Repository
{
    public class LoaiHocBongRepository : ILoaiHocBong
    {
        private ApplicationDbContext _context;
        public LoaiHocBongRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<LoaiHocBong> GetLoaiHocBongs => _context.LoaiHocBongs;
    }
}
