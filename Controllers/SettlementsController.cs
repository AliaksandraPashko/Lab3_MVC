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

        // GET: Settlements
        public IActionResult Index(string id)
        {
            List<Settlements> settlements = new List<Settlements>();
            settlements = _context.Settlements.Where(item => item.Iddistrict == Int32.Parse(id)).ToList();
            return View(settlements);
        }

        // GET: Settlements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settlements = await _context.Settlements
                .SingleOrDefaultAsync(m => m.Id == id);
            if (settlements == null)
            {
                return NotFound();
            }

            return View(settlements);
        }

        // GET: Settlements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Settlements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Iddistrict,Name,Type,Population")] Settlements settlements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(settlements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(settlements);
        }

        // GET: Settlements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settlements = await _context.Settlements.SingleOrDefaultAsync(m => m.Id == id);
            if (settlements == null)
            {
                return NotFound();
            }
            return View(settlements);
        }

        // POST: Settlements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Iddistrict,Name,Type,Population")] Settlements settlements)
        {
            if (id != settlements.Id)
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
                    if (!SettlementsExists(settlements.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
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
                .SingleOrDefaultAsync(m => m.Id == id);
            if (settlements == null)
            {
                return NotFound();
            }

            return View(settlements);
        }

        // POST: Settlements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var settlements = await _context.Settlements.SingleOrDefaultAsync(m => m.Id == id);
            _context.Settlements.Remove(settlements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettlementsExists(int id)
        {
            return _context.Settlements.Any(e => e.Id == id);
        }
    }
}
