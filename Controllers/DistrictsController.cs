using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3_MVC_.Models;

namespace Lab3_MVC_.Controllers
{
    public class DistrictsController : Controller
    {
        private readonly CountryDBContext _context;

        public DistrictsController(CountryDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(string id)
        {
           
            ViewData["DistrictsList"] = new SelectList(_context.Districts.Where(item => item.Idregion == Int32.Parse(id)), "Id", "Name");
            return View();
        }

    }
}
