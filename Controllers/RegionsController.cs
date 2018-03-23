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
            List<Regions> list = new List<Regions>();
            list = _context.Regions.ToList();
            list.Insert(0, new Regions {  Id=0 , Name="-Select-" });
            ViewBag.ListOfRegions = list;   

            return View();
          //  return View(await _context.Regions.ToListAsync());
        }

        public IActionResult IndexDistricts(int? id)
        {
            List<Districts> list = new List<Districts>();
            list = _context.Districts.Where(item => item.Idregion == id).ToList();
            ViewBag.ListOfDistricts = list;

            return View();
  
        }
    }
}
