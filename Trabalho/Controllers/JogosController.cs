using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;
using Trabalho.Models.Dominio;

namespace Trabalho.Controllers
{
    public class JogosController : Controller
    {
        private readonly Contexto _context;

        public JogosController(Contexto context)
        {
            _context = context;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Jogos.Include(j => j.plataforma).Include(j => j.usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .Include(j => j.plataforma)
                .Include(j => j.usuario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            ViewData["plataformaID"] = new SelectList(_context.Plataformas, "id", "nome");
            ViewData["usuarioID"] = new SelectList(_context.Usuarios, "id", "email");
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,usuarioID,plataformaID,nome,preco,genero")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["plataformaID"] = new SelectList(_context.Plataformas, "id", "nome", jogo.plataformaID);
            ViewData["usuarioID"] = new SelectList(_context.Usuarios, "id", "email", jogo.usuarioID);
            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }
            ViewData["plataformaID"] = new SelectList(_context.Plataformas, "id", "nome", jogo.plataformaID);
            ViewData["usuarioID"] = new SelectList(_context.Usuarios, "id", "email", jogo.usuarioID);
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,usuarioID,plataformaID,nome,preco,genero")] Jogo jogo)
        {
            if (id != jogo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.id))
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
            ViewData["plataformaID"] = new SelectList(_context.Plataformas, "id", "nome", jogo.plataformaID);
            ViewData["usuarioID"] = new SelectList(_context.Usuarios, "id", "email", jogo.usuarioID);
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .Include(j => j.plataforma)
                .Include(j => j.usuario)
                .FirstOrDefaultAsync(m => m.id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(int id)
        {
            return _context.Jogos.Any(e => e.id == id);
        }
    }
}
