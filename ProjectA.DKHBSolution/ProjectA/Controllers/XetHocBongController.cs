using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectA.Models;
using ProjectA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    public class XetHocBongController : Controller
    {
        private readonly IXetHocBong _XetHocBong;
        private readonly ApplicationDbContext _context;
        public XetHocBongController(IXetHocBong XetHocBong, ApplicationDbContext context)
        {
            _XetHocBong = XetHocBong;
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

            int totalProduct = _XetHocBong.totalProduct();

            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = _XetHocBong.numberPage(totalProduct, limit);

            var data = _XetHocBong.paginationProduct(start, limit);

            return View(data.ToList());
        }

       
    }
}
