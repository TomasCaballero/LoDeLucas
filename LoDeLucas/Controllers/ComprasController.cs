using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoDeLucas.Context;
using LoDeLucas.Models;
using System.Text.Json;

namespace LoDeLucas.Controllers
{
    public class ComprasController : Controller
    {
        private readonly EcommerceContext _context;

        public ComprasController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compra.Include(c => c.Producto).Include(c => c.Cliente).ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.Include(c => c.Producto).Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            // Recupero los datos del cliente y del producto
            var clienteJson = HttpContext.Session.GetString("Cliente");
            var productoJson = HttpContext.Session.GetString("Producto");

            if (clienteJson == null || productoJson == null)
            {
                return RedirectToAction("Cliente y Producto requeridos");
            }

            var cliente = JsonSerializer.Deserialize<Cliente>(clienteJson);
            var producto = JsonSerializer.Deserialize<Producto>(productoJson);

            Compra model = new Compra();
            model.Producto = producto;
            model.Cliente = cliente;
            model.Cantidad = 1;
            return View(model);
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,EnvioADomicilio")] Compra compra)
        {
            var clienteJson = HttpContext.Session.GetString("Cliente");
            var productoJson = HttpContext.Session.GetString("Producto");

            if (clienteJson == null || productoJson == null)
            {
                return RedirectToAction("Cliente y Producto requeridos");
            }

            var cliente = JsonSerializer.Deserialize<Cliente>(clienteJson);
            var producto = JsonSerializer.Deserialize<Producto>(productoJson);

            compra.Producto = _context.Productos.Find(producto.Id);
            compra.Cliente = _context.Clientes.Find(cliente.Id);

            HttpContext.Session.Remove("Producto");
            HttpContext.Session.Remove("Cliente");

            if (compra.Producto != null && compra.Cliente != null && compra.Cantidad >= 1)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else {
                return RedirectToAction(nameof(Error),compra);
            }
        }

        // GET: Compras/Error
        public IActionResult Error(Compra compra)
        {
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,CreatedAt,EnvioADomicilio")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

             if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
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
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.Include(c => c.Producto).Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compra.FindAsync(id);
            if (compra != null)
            {
                _context.Compra.Remove(compra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compra.Any(e => e.Id == id);
        }
    }
}
