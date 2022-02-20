using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPPweb2122.Data;
using TPPweb2122.Models;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TPPweb2122.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace TPPweb2122.Controllers
{
    
    public class ImovelsController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public ImovelsController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // GET: Imovels
        public async Task<IActionResult> Index(int? page)
        {
            var imoveisview = new ImoveisViewModel();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IQueryable<Imovel> imovel;
            if (User.IsInRole("Gestor"))
            {
                imovel = _context.Imoveis.Include(c => c.Categoria)
                    .Where(f => f.gestorId == int.Parse(userId));
            }else if (User.IsInRole("Funcionario"))
            {

                var funcionario = await _context.Funcionario
              .Include(f => f.Gestor)
              .FirstOrDefaultAsync(m => m.Id == int.Parse(userId));

                imovel = _context.Imoveis.Include(c => c.Categoria)
                    .Where(f => f.gestorId == funcionario.gestorId);
            }
            else
            {
                imovel = _context.Imoveis.Include(i => i.Categoria);
            }
            int pagina = (page == null || page < 1) ? 1 : page.Value;
            int nReg = 8;
            imoveisview.paginacao(imovel, pagina, nReg);
            return View(imoveisview);
        }

        // GET: Imovels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imovels/Create
        [Authorize(Roles = "Admin,Gestor")]
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "NomeCategoria");
            return View();
        }

        // POST: Imovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Gestor")]
        public async Task<IActionResult> Create([Bind("ImovelId,NomeAlojamento,Localizacao,Descricao,Preco,dataInicio,dataFinal,CategoriaId")] Imovel imovel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                imovel.gestorId = int.Parse(userId);
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "NomeCategoria", imovel.CategoriaId);
            return View(imovel);
        }

        // GET: Imovels/Edit/5
        [Authorize(Roles = "Admin,Gestor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "NomeCategoria", imovel.CategoriaId);
            return View(imovel);
        }

        // POST: Imovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Gestor")]
        public async Task<IActionResult> Edit(int id, [Bind("ImovelId,NomeAlojamento,Localizacao,Descricao,Preco,dataInicio,dataFinal,CategoriaId,gestorId")] Imovel imovel)
        {
            if (id != imovel.ImovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.ImovelId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", imovel.CategoriaId);
            return View(imovel);
        }

        // GET: Imovels/Delete/5
        [Authorize(Roles = "Admin,Gestor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Gestor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imoveis.Any(e => e.ImovelId == id);
        }
    }
}
