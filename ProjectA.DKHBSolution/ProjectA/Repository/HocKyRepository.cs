using ProjectA.Models;
using ProjectA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Repository
{
    public class HocKyRepository : IHocKy
    {
        private readonly ApplicationDbContext _context;
        public HocKyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<HocKy> GetHocKies => _context.HocKies;
    }
}
