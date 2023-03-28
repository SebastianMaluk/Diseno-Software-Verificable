using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealState.Data;
using RealState.Models;
using RealState.ViewModels;

namespace RealState.Controllers
{
    public class InscriptionsController : Controller
    {
        private readonly RealStateContext _context;

        public InscriptionsController(RealStateContext context)
        {
            _context = context;
        }

        // GET: Inscriptions
        public async Task<IActionResult> Index()
        {
            var model = await _context.Inscription
                .Include(c => c.Cne)
                .Include(l => l.Localization)
                
                .AsNoTracking()
                .ToListAsync();
            return _context.Inscription != null ? 
                          View(model) :
                          Problem("Entity set 'RealStateContext.Inscription'  is null.");
        }

        // GET: Inscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscription == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscription
                .Include(c => c.Cne)
                .Include(l => l.Localization)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);
            
            // get all enajenantes and adquirientes with inscription id
            var enajenantes = await _context.Enajenante
                .Where(i => i.Inscription!.id == id)
                .AsNoTracking()
                .ToListAsync();
            var adquirientes = await _context.Adquiriente
                .Where(i => i.Inscription!.id == id)
                .AsNoTracking()
                .ToListAsync();
            
            var detailsViewModel = new InscriptionViewModel
            {
                Inscription = inscription,
                Enajenantes = enajenantes,
                Adquirientes = adquirientes,
            };
            
            if (inscription == null)
            {
                return NotFound();
            }

            return View(detailsViewModel);
        }

        // GET: Inscriptions/Create
        public IActionResult Create()
        {
            var viewModel = new InscriptionViewModel
            {
                Inscription = new Inscription(),
                Localization = new Localization(),
                Enajenantes = new List<Enajenante>() { new Enajenante() },
                Adquirientes = new List<Adquiriente>() { new Adquiriente() },
            };

        return View(viewModel);
        }

        // POST: Inscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InscriptionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var inscription = viewModel.Inscription;

                var cne = _context.Cne.FirstOrDefault(c => c.type == viewModel.Cne!.type);
                inscription!.Cne = cne;
                
                var localization = viewModel.Localization;
                inscription!.Localization = localization;
                
                var enajenantes = viewModel.Enajenantes!;
                if (enajenantes != null)
                {
                    foreach (var enaj in enajenantes)
                    {
                        enaj.Inscription = inscription;
                    }
                    _context.AddRange(enajenantes!);
                }

                var adquirientes = viewModel.Adquirientes!;
                if (adquirientes != null)
                {
                    foreach (var adq in adquirientes)
                    {
                        adq.Inscription = inscription;
                    }
                    _context.AddRange(adquirientes!);
                }

                _context.Add(inscription!);
                _context.Add(localization!);
                
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscription == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscription.FindAsync(id);
            if (inscription == null)
            {
                return NotFound();
            }
            return View(inscription);
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,attention_number,fojas,date,number")] Inscription inscription)
        {
            if (id != inscription.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscriptionExists(inscription.id))
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
            return View(inscription);
        }

        // GET: Inscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscription == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscription
                .FirstOrDefaultAsync(m => m.id == id);
            if (inscription == null)
            {
                return NotFound();
            }

            return View(inscription);
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscription == null)
            {
                return Problem("Entity set 'RealStateContext.Inscription'  is null.");
            }
            var inscription = await _context.Inscription.FindAsync(id);
            if (inscription != null)
            {
                _context.Inscription.Remove(inscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscriptionExists(int id)
        {
          return (_context.Inscription?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
