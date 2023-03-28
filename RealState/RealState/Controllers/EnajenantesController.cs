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
    public class EnajenantesController : Controller
    {
        private readonly RealStateContext _context;

        public EnajenantesController(RealStateContext context)
        {
            _context = context;
        }

        // GET: Enajenantes
        public async Task<IActionResult> Index()
        {
              return _context.Enajenante != null ? 
                          View(await _context.Enajenante.ToListAsync()) :
                          Problem("Entity set 'RealStateContext.Enajenante'  is null.");
        }

        // GET: Enajenantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enajenante == null)
            {
                return NotFound();
            }

            var enajenante = await _context.Enajenante
                .FirstOrDefaultAsync(m => m.id == id);
            if (enajenante == null)
            {
                return NotFound();
            }

            return View(enajenante);
        }

        // GET: Enajenantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enajenantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Rut,Percentage_right,Check_percentage_not_credited")] Enajenante enajenante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enajenante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enajenante);
        }

        // GET: Enajenantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enajenante == null)
            {
                return NotFound();
            }

            var enajenante = await _context.Enajenante.FindAsync(id);
            if (enajenante == null)
            {
                return NotFound();
            }
            return View(enajenante);
        }

        // POST: Enajenantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Rut,Percentage_right,Check_percentage_not_credited")] Enajenante enajenante)
        {
            if (id != enajenante.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enajenante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnajenanteExists(enajenante.id))
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
            return View(enajenante);
        }

        // GET: Enajenantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enajenante == null)
            {
                return NotFound();
            }

            var enajenante = await _context.Enajenante
                .FirstOrDefaultAsync(m => m.id == id);
            if (enajenante == null)
            {
                return NotFound();
            }

            return View(enajenante);
        }

        // POST: Enajenantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enajenante == null)
            {
                return Problem("Entity set 'RealStateContext.Enajenante'  is null.");
            }
            var enajenante = await _context.Enajenante.FindAsync(id);
            if (enajenante != null)
            {
                _context.Enajenante.Remove(enajenante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnajenanteExists(int id)
        {
          return (_context.Enajenante?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
