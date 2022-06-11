using Microsoft.AspNetCore.Mvc;
using ProjectA.Models;
using ProjectA.Service;
using ProjectA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    public class HocBongController : Controller
    {
        
        private readonly IHocBong _HocBong;
        private readonly ILoaiHocBong _LoaiHocBong;
        public HocBongController(IHocBong HocBong, ILoaiHocBong LoaiHocBong)
        {
            _HocBong = HocBong;
            _LoaiHocBong = LoaiHocBong;
        }
        public async Task<IActionResult> Index()
        {
            var hocBong = await _HocBong.GetHocBongs();
            return View(hocBong);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.HocBongs = _LoaiHocBong.GetLoaiHocBongs;
            return View(_HocBong.Create());
        }

        [HttpPost]
        public IActionResult Create(HocBong hocBong)
        {
            if (ModelState.IsValid)
            {
                _HocBong.Add(hocBong);

                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var b = _HocBong.Get(id);
            if (b == null)
                return NotFound();
            else
                return View(b);
        }

        [HttpPost]
        public IActionResult Delete(HocBong hocBong)
        {
            _HocBong.Remove(hocBong.IdHocBong);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.HocBongs = _LoaiHocBong.GetLoaiHocBongs;
            return base.View(_HocBong.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(HocBong hocBong)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.Lops = _Lop.GetAllLops;
                _HocBong.Update(hocBong);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var hocBong = await _HocBong.GetHocBongById(id);
            if (hocBong == null)
                return NotFound();
            else
                return View(hocBong);
        }
    }
}
