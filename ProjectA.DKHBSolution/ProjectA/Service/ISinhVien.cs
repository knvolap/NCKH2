using Microsoft.AspNetCore.Http;
using ProjectA.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectA.Models
{
    public interface ISinhVien
    {
        IEnumerable<SinhVien> GetStudents { get; }

        XetHocBongViewModel GetSinhVienById(string Id);

        SinhVien Get(string id);

        SinhVien CreateNewSinhVien();

        void AddNewSinhVien(SinhVien sinhVien);

        Diem Create();

        void Add(Diem sinhVien);

        void Remove(string Id);

        void Update(SinhVien sinhVien);

        SinhVien[] GetListSV(string search);

        Task<List<SinhVienViewModel>> GetSinhViens();

        int numberPage(int totalProduct, int limit);

        IEnumerable<XetHocBongViewModel> paginationProduct(int start, int limit);

        int totalProduct();

        
    }
}
