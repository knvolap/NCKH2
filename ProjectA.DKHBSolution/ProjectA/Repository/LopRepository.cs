using ProjectA.Models;
using ProjectA.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Repository
{
    public class LopRepository : ILop
    {
        private ApplicationDbContext _context;
        public LopRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Lop> GetAllLops => _context.Lops;

        public void Add(Lop lop)
        {
            _context.Lops.Add(lop);
            _context.SaveChanges();
        }

        public Lop GetLopById(string Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
