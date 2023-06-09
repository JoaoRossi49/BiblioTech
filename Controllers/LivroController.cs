using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiblioTech.Data;
using BiblioTech.Models;

namespace BiblioTech.Controllers
{
    public class LivroController : Controller
    {
        private readonly BibliotechContext _context;

        public LivroController(BibliotechContext context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {      
              return _context.Livro != null ? 
                          View(await _context.Livro.ToListAsync()) :
                          Problem("Entity set 'BibliotechContext.Livro'  is null.");
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.IdLivo == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livro/Create

        public IActionResult Create()
        {
            ViewBag.Genero = new SelectList(_context.Genero, "IdGenero", "DescricaoGenero", null);
            ViewBag.Autor = new SelectList(_context.Autor, "IdAutor", "NomeAutor", null);
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLivo,NomeLivro,IdGenero,QuantidadePaginas,IdAutor")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewBag.Genero = new SelectList(_context.Genero, "IdGenero", "DescricaoGenero", null);
            ViewBag.Autor = new SelectList(_context.Autor, "IdAutor", "NomeAutor", null);
            return View(livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLivo,NomeLivro,IdGenero,QuantidadePaginas,IdAutor")] Livro livro)
        {
            if (id != livro.IdLivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.IdLivo))
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
            return View(livro);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.IdLivo == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Livro == null)
            {
                return Problem("Entity set 'BibliotechContext.Livro'  is null.");
            }
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
          return (_context.Livro?.Any(e => e.IdLivo == id)).GetValueOrDefault();
        }
    }
}
