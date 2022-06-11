using ProjectA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Service
{
    public interface IDangKyHocBong
    {
        Task<DangKyHocBong> GetHocBongById(string Id);

        HocBong Get(string id);

        HocBong Create();

        void Add(DangKyHocBong dangKyHocBong);

        void Remove(string Id);

        void Update(HocBong hocBong);

        IEnumerable<DangKyHocBong> GetHocBongs { get; }
    }
}
