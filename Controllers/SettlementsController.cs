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
    public class SettlementsController : Controller
    {
        private readonly CountryDBContext _context;

        public SettlementsController(CountryDBContext context)
        {
            _context = context;
        }
        
        // GET: Settlements/5
        public IActionResult Index(string i)
        {
            ViewData["IdSelectedDistrict"] = Int32.Parse(i);
            List<Settlements> settlements = new List<Settlements>();
            settlements = _context.Settlements.Where(item => item.Iddistrict == Int32.Parse(i)).ToList();
            return View(settlements);
        }

        // GET: Settlements/Details/5
        public async Task<IActionResult> Details(int? i)
        {
            if (i == null)
            {
                return NotFound();
            }

            var settlements = await _context.Settlements
                .SingleOrDefaultAsync(m => m.SettlementId == i);
            if (settlements == null)
            {
                return NotFound();
            }

            return View(settlements);
        }

        // GET: Settlements/Create/5
        public IActionResult Create(int? i)
        {
            ViewData["IdSelectedDistrict"] = i;
            return View();
        }

        // POST: Settlements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SettlementId,Iddistrict,Name,Type,Population")] Settlements settlements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(settlements);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Settlements", new { i = settlements.Iddistrict });
            }
            ViewData["IdSelectedDistrict"] = settlements.Iddistrict;
            return View(settlements);
        }

        // GET: Settlements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settlements = await _context.Settlements.SingleOrDefaultAsync(m => m.SettlementId == id);
            if (settlements == null)
            {
                return NotFound();
            }
            ViewData["IdSelectedDistrict"] = settlements.Iddistrict;
            return View(settlements);
        }

        // POST: Settlements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SettlementId,Iddistrict,Name,Type,Population")] Settlements settlements)
        {
            if (id != settlements.SettlementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settlements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettlementsExists(settlements.SettlementId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
             return RedirectToAction("Index", "Settlements", new { i = settlements.Iddistrict });
            }
            ViewData["IdSelectedDistrict"] = settlements.Iddistrict;
            return View(settlements);
        }

        // GET: Settlements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settlements = await _context.Settlements
                .SingleOrDefaultAsync(m => m.SettlementId == id);
            if (settlements == null)
            {
                return NotFound();
            }
            ViewData["IdSelectedDistrict"] = settlements.Iddistrict;
            return View(settlements);
        }

        // POST: Settlements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var settlements = await _context.Settlements.SingleOrDefaultAsync(m => m.SettlementId == id);
            _context.Settlements.Remove(settlements);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Settlements", new { i = settlements.Iddistrict });
        }

        private bool SettlementsExists(int i)
        {
            return _context.Settlements.Any(e => e.SettlementId == i);
        }
    }
}
