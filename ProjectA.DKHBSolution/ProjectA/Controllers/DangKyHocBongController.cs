using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    [Authorize]
    public class DangKyHocBongController : Controller
    {
        private readonly IDangKyHocBong _DangKyHocBong;
        public DangKyHocBongController(IDangKyHocBong DangKyHocBong)
        {
            _DangKyHocBong = DangKyHocBong;
        }
        public IActionResult Index()
        {
            return View(_DangKyHocBong.GetHocBongs);
        }
    }
}
