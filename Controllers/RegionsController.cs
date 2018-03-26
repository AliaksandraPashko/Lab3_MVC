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
    public class RegionsController : Controller
    {
        private readonly CountryDBContext _context;

        public RegionsController(CountryDBContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            ViewData["RegionsList"] = new SelectList(_context.Regions,"Id","Name"); 
            return View();
          //  return View(await _context.Regions.ToListAsync());
        }

    }
}
