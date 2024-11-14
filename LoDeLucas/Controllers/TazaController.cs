using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoDeLucas;
using LoDeLucas.Context;

namespace LoDeLucas.Controllers
{
    public class TazaController : Controller
    {
        private readonly EcommerceContext _context;

        public TazaController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Taza
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taza.ToListAsync());
        }

        // GET: Taza/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taza = await _context.Taza
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taza == null)
            {
                return NotFound();
            }

            return View(taza);
        }

        // GET: Taza/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taza/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Material,Id,Nombre,Precio,Descuento")] Taza taza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taza);
        }

        // GET: Taza/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taza = await _context.Taza.FindAsync(id);
            if (taza == null)
            {
                return NotFound();
            }
            return View(taza);
        }

        // POST: Taza/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Material,Id,Nombre,Precio,Descuento")] Taza taza)
        {
            if (id != taza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TazaExists(taza.Id))
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
            return View(taza);
        }

        // GET: Taza/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taza = await _context.Taza
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taza == null)
            {
                return NotFound();
            }

            return View(taza);
        }

        // POST: Taza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taza = await _context.Taza.FindAsync(id);
            if (taza != null)
            {
                _context.Taza.Remove(taza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TazaExists(int id)
        {
            return _context.Taza.Any(e => e.Id == id);
        }
    }
}
