using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealState.Data;
using RealState.Models;

namespace RealState.Views.Shared
{
    public class CnesController : Controller
    {
        private readonly RealStateContext _context;

        public CnesController(RealStateContext context)
        {
            _context = context;
        }

        // GET: Cnes
        public async Task<IActionResult> Index()
        {
              return _context.Cne != null ? 
                          View(await _context.Cne.ToListAsync()) :
                          Problem("Entity set 'RealStateContext.Cne'  is null.");
        }

        // GET: Cnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cne == null)
            {
                return NotFound();
            }

            var cne = await _context.Cne
                .FirstOrDefaultAsync(m => m.id == id);
            if (cne == null)
            {
                return NotFound();
            }

            return View(cne);
        }

        // GET: Cnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,type")] Cne cne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cne);
        }

        // GET: Cnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cne == null)
            {
                return NotFound();
            }

            var cne = await _context.Cne.FindAsync(id);
            if (cne == null)
            {
                return NotFound();
            }
            return View(cne);
        }

        // POST: Cnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,type")] Cne cne)
        {
            if (id != cne.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CneExists(cne.id))
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
            return View(cne);
        }

        // GET: Cnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cne == null)
            {
                return NotFound();
            }

            var cne = await _context.Cne
                .FirstOrDefaultAsync(m => m.id == id);
            if (cne == null)
            {
                return NotFound();
            }

            return View(cne);
        }

        // POST: Cnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cne == null)
            {
                return Problem("Entity set 'RealStateContext.Cne'  is null.");
            }
            var cne = await _context.Cne.FindAsync(id);
            if (cne != null)
            {
                _context.Cne.Remove(cne);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CneExists(int id)
        {
          return (_context.Cne?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
