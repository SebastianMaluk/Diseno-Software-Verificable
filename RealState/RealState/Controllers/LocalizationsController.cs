using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealState.Data;
using RealState.Models;

namespace RealState.Controllers
{
    public class LocalizationsController : Controller
    {
        private readonly RealStateContext _context;

        public LocalizationsController(RealStateContext context)
        {
            _context = context;
        }

        // GET: Localizations
        public async Task<IActionResult> Index()
        {
              return _context.Localization != null ? 
                          View(await _context.Localization.ToListAsync()) :
                          Problem("Entity set 'RealStateContext.Localization'  is null.");
        }

        // GET: Localizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Localization == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization
                .FirstOrDefaultAsync(m => m.id == id);
            if (localization == null)
            {
                return NotFound();
            }

            return View(localization);
        }

        // GET: Localizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,comuna,manzana,predio")] Localization localization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localization);
        }

        // GET: Localizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Localization == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization.FindAsync(id);
            if (localization == null)
            {
                return NotFound();
            }
            return View(localization);
        }

        // POST: Localizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,comuna,manzana,predio")] Localization localization)
        {
            if (id != localization.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalizationExists(localization.id))
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
            return View(localization);
        }

        // GET: Localizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Localization == null)
            {
                return NotFound();
            }

            var localization = await _context.Localization
                .FirstOrDefaultAsync(m => m.id == id);
            if (localization == null)
            {
                return NotFound();
            }

            return View(localization);
        }

        // POST: Localizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Localization == null)
            {
                return Problem("Entity set 'RealStateContext.Localization'  is null.");
            }
            var localization = await _context.Localization.FindAsync(id);
            if (localization != null)
            {
                _context.Localization.Remove(localization);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalizationExists(int id)
        {
          return (_context.Localization?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
