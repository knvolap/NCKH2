using ProjectA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Service
{
    public interface ILop
    {
        IEnumerable<Lop> GetAllLops { get; }

        Lop GetLopById(string Id);

        void Add(Lop lop);

        void Remove(string Id);
    }
}
