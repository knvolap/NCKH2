using ProjectA.Models;
using ProjectA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Service
{
    public interface IXetHocBong
    {
        public XetHocBongViewModel[] DanhSachDatHocBong();

        int numberPage(int totalProduct, int limit);

        public XetHocBongViewModel[] paginationProduct(int start, int limit);

        int totalProduct();
    }
}
