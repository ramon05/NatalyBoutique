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
    public class ArtículosController : Controller
    {
        private readonly NatalyBoutiqueContext _context;

        public ArtículosController(NatalyBoutiqueContext context)
        {
            _context = context;
        }

        // GET: Artículos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artículos.ToListAsync());
        }

        // GET: Artículos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artículos = await _context.Artículos
                .FirstOrDefaultAsync(m => m.IdArticulo == id);
            if (artículos == null)
            {
                return NotFound();
            }

            return View(artículos);
        }

        // GET: Artículos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artículos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArticulo,Descripcion,Precio,CantidadExistencia")] Artículos artículos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artículos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artículos);
        }

        // GET: Artículos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artículos = await _context.Artículos.FindAsync(id);
            if (artículos == null)
            {
                return NotFound();
            }
            return View(artículos);
        }

        // POST: Artículos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArticulo,Descripcion,Precio,CantidadExistencia")] Artículos artículos)
        {
            if (id != artículos.IdArticulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artículos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtículosExists(artículos.IdArticulo))
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
            return View(artículos);
        }

        // GET: Artículos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artículos = await _context.Artículos
                .FirstOrDefaultAsync(m => m.IdArticulo == id);
            if (artículos == null)
            {
                return NotFound();
            }

            return View(artículos);
        }

        // POST: Artículos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artículos = await _context.Artículos.FindAsync(id);
            _context.Artículos.Remove(artículos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtículosExists(int id)
        {
            return _context.Artículos.Any(e => e.IdArticulo == id);
        }
    }
}
