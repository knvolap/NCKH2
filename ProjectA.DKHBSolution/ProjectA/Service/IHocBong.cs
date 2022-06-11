using ProjectA.Models;
using ProjectA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Service
{
    public interface IHocBong
    {
        Task<HocBongViewModel> GetHocBongById(string Id);

        HocBong Get(string id);

        HocBong Create();

        void Add(HocBong hocBong);

        void Remove(string Id);

        void Update(HocBong hocBong);        

        Task<IEnumerable<HocBongViewModel>> GetHocBongs();

        
    }
}
