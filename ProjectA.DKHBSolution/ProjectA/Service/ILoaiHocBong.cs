using ProjectA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Service
{
    public interface ILoaiHocBong
    {
        IEnumerable<LoaiHocBong> GetLoaiHocBongs { get; }
    }
}
