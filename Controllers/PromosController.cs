using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HaylandMontalvo_tablaBD.Data;
using HaylandMontalvo_tablaBD.Models;

namespace HaylandMontalvo_tablaBD.Controllers
{
    public class PromosController : Controller
    {
        private readonly HaylandMontalvo_tablaBDContext _context;

        public PromosController(HaylandMontalvo_tablaBDContext context)
        {
            _context = context;
        }

        // GET: Promos
        public async Task<IActionResult> Index()
        {
              return _context.Promo != null ? 
                          View(await _context.Promo.ToListAsync()) :
                          Problem("Entity set 'HaylandMontalvo_tablaBDContext.Promo'  is null.");
        }

        // GET: Promos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // GET: Promos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoId,PromoName,PromoDescription,Id")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promo);
        }

        // GET: Promos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }
            return View(promo);
        }

        // POST: Promos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoId,PromoName,PromoDescription,Id")] Promo promo)
        {
            if (id != promo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoExists(promo.Id))
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
            return View(promo);
        }

        // GET: Promos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Promo == null)
            {
                return NotFound();
            }

            var promo = await _context.Promo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        // POST: Promos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Promo == null)
            {
                return Problem("Entity set 'HaylandMontalvo_tablaBDContext.Promo'  is null.");
            }
            var promo = await _context.Promo.FindAsync(id);
            if (promo != null)
            {
                _context.Promo.Remove(promo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoExists(int id)
        {
          return (_context.Promo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
