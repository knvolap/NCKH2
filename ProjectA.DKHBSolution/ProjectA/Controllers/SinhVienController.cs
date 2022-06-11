using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using ProjectA.Models;
using ProjectA.Service;
using ProjectA.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    [Authorize]
    public class SinhVienController : Controller
    {
        private readonly ISinhVien _SinhVien;
        private readonly ILop _Lop;
        private readonly IHocKy _HocKy;
        private readonly ApplicationDbContext _context;
       
        public SinhVienController(ISinhVien SinhVien, ILop Lop, IHocKy HocKy, ApplicationDbContext context)
        {
            _SinhVien = SinhVien;
            _Lop = Lop;
            _HocKy = HocKy;
            _context = context;
        }

        public IActionResult Index(int? page = 0)
        {
            int limit = 7;
            int start;
            if (page > 0)
            {
               page = page + 0;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;

            ViewBag.pageCurrent = page;

            int totalProduct = _SinhVien.totalProduct();

            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = _SinhVien.numberPage(totalProduct, limit);

            var data = _SinhVien.paginationProduct(start, limit);

            return View(data.ToList());
        }

        //public async Task<List<XetHocBongViewModel>> Index(IFormFile file)
        //{
        //    var sinhVien = from sv in _context.SinhViens
        //                   join d in _context.Diems on sv.IdSinhVien equals d.IdSinhVien                          
        //                   join hk in _context.HocKies on d.IdHocKy equals hk.IdHocKy
        //                   select new { sv, d, hk };
        //    var list = new List<XetHocBongViewModel>();
        //    using (var stream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(stream);
        //        using (var package = new ExcelPackage(stream))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //            var rowcount = worksheet.Dimension.Rows;
        //            for (int row = 2; row <= rowcount; row++)
        //            {
        //                list.Add(new XetHocBongViewModel
        //                {
        //                    IdSinhVien = worksheet.Cells[row, 1].Value.ToString().Trim(),
        //                    TenSinhVien = worksheet.Cells[row, 2].Value.ToString().Trim(),
        //                    DiemThang10 = Convert.ToDouble(worksheet.Cells[row, 3].Value),
        //                    DiemThang4 = Convert.ToDouble(worksheet.Cells[row, 4].Value),
        //                    IdHocKy = worksheet.Cells[row, 5].Value.ToString().Trim(),
        //                    DiemRenLuyen = Convert.ToByte(worksheet.Cells[row, 6].Value),
        //                    XepLoai = worksheet.Cells[row, 7].Value.ToString().Trim(),
        //                    SoTinChi = Convert.ToInt32(worksheet.Cells[row, 8].Value),
        //                });
        //            }
        //        }
                
        //        return list;
        //    }
        //}


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SinhViens = _SinhVien.GetStudents;
            ViewBag.HocKies = _HocKy.GetHocKies;
            ViewBag.Lops = _Lop.GetAllLops;
            return View(_SinhVien.Create());
        }

        [HttpPost]
        public IActionResult Create(Diem sinhVien)
        {
            if (ModelState.IsValid)
            {
                _SinhVien.Add(sinhVien);

                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult CreateNewSinhVien()
        {          
            ViewBag.Lops = _Lop.GetAllLops;
            return View(_SinhVien.CreateNewSinhVien());
        }

        [HttpPost]
        public IActionResult CreateNewSinhVien(SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _SinhVien.AddNewSinhVien(sinhVien);

                return RedirectToAction("Create");
            }
            return View("Create");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var b = _SinhVien.Get(id);
            if (b == null)
                return NotFound();
            else
                return View(b);
        }

        [HttpPost]
        public IActionResult Delete(SinhVien sinhVien)
        {
            _SinhVien.Remove(sinhVien.IdSinhVien);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.Lops = _Lop.GetAllLops;
            return base.View(_SinhVien.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.Lops = _Lop.GetAllLops;
                _SinhVien.Update(sinhVien);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var sinhVien = _SinhVien.GetSinhVienById(id);
            if (sinhVien == null)
                return NotFound();
            else
                return View(sinhVien);
        }       
    }
}
