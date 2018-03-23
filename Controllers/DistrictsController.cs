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

        // GET: Districts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Districts.ToListAsync());
        }

        // GET: Districts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var districts = await _context.Districts
                .SingleOrDefaultAsync(m => m.Id == id);
            if (districts == null)
            {
                return NotFound();
            }

            return View(districts);
        }

        // GET: Districts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idregion,Name")] Districts districts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(districts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(districts);
        }

        // GET: Districts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var districts = await _context.Districts.SingleOrDefaultAsync(m => m.Id == id);
            if (districts == null)
            {
                return NotFound();
            }
            return View(districts);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idregion,Name")] Districts districts)
        {
            if (id != districts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(districts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictsExists(districts.Id))
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
            return View(districts);
        }

        // GET: Districts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var districts = await _context.Districts
                .SingleOrDefaultAsync(m => m.Id == id);
            if (districts == null)
            {
                return NotFound();
            }

            return View(districts);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var districts = await _context.Districts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Districts.Remove(districts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistrictsExists(int id)
        {
            return _context.Districts.Any(e => e.Id == id);
        }
    }
}
