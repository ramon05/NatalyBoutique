using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NatalyBoutique.Models;

namespace NatalyBoutique.Controllers
{
    public class DetallePedidosController : Controller
    {
        private readonly NatalyBoutiqueContext _context;

        public DetallePedidosController(NatalyBoutiqueContext context)
        {
            _context = context;
        }

        // GET: DetallePedidos
        public async Task<IActionResult> Index()
        {
            var natalyBoutiqueContext = _context.DetallePedidos.Include(d => d.IdArticuloNavigation).Include(d => d.IdPedidoNavigation);
            return View(await natalyBoutiqueContext.ToListAsync());
        }

        // GET: DetallePedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedidos = await _context.DetallePedidos
                .Include(d => d.IdArticuloNavigation)
                .Include(d => d.IdPedidoNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (detallePedidos == null)
            {
                return NotFound();
            }

            return View(detallePedidos);
        }

        // GET: DetallePedidos/Create
        public IActionResult Create()
        {
            ViewData["IdArticulo"] = new SelectList(_context.Artículos, "IdArticulo", "IdArticulo");
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedidos", "IdPedidos");
            return View();
        }

        // POST: DetallePedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,IdArticulo,Descripcion,Tamaño,Color,SeccionBodega,NumeroEstante,CantidadOrdenada,CantidadSurtida")] DetallePedidos detallePedidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArticulo"] = new SelectList(_context.Artículos, "IdArticulo", "IdArticulo", detallePedidos.IdArticulo);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedidos", "IdPedidos", detallePedidos.IdPedido);
            return View(detallePedidos);
        }

        // GET: DetallePedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedidos = await _context.DetallePedidos.FindAsync(id);
            if (detallePedidos == null)
            {
                return NotFound();
            }
            ViewData["IdArticulo"] = new SelectList(_context.Artículos, "IdArticulo", "IdArticulo", detallePedidos.IdArticulo);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedidos", "IdPedidos", detallePedidos.IdPedido);
            return View(detallePedidos);
        }

        // POST: DetallePedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,IdArticulo,Descripcion,Tamaño,Color,SeccionBodega,NumeroEstante,CantidadOrdenada,CantidadSurtida")] DetallePedidos detallePedidos)
        {
            if (id != detallePedidos.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidosExists(detallePedidos.IdPedido))
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
            ViewData["IdArticulo"] = new SelectList(_context.Artículos, "IdArticulo", "IdArticulo", detallePedidos.IdArticulo);
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "IdPedidos", "IdPedidos", detallePedidos.IdPedido);
            return View(detallePedidos);
        }

        // GET: DetallePedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedidos = await _context.DetallePedidos
                .Include(d => d.IdArticuloNavigation)
                .Include(d => d.IdPedidoNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (detallePedidos == null)
            {
                return NotFound();
            }

            return View(detallePedidos);
        }

        // POST: DetallePedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedidos = await _context.DetallePedidos.FindAsync(id);
            _context.DetallePedidos.Remove(detallePedidos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidosExists(int id)
        {
            return _context.DetallePedidos.Any(e => e.IdPedido == id);
        }
    }
}
