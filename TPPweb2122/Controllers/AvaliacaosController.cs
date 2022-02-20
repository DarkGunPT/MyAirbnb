using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPPweb2122.Data;
using TPPweb2122.Models;
using TPPweb2122.ViewModels;

namespace TPPweb2122.Controllers
{
    public class AvaliacaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Avaliacaos
        public async Task<IActionResult> Index(int? page)
        {
            var imoveisview = new HistoricoViewModelo();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IQueryable<Avaliacao> avaliacao;
            if (User.IsInRole("Cliente"))
            {
                avaliacao = _context.Avaliacoes.Include(a => a.cliente).Include(a => a.Imovel).Where(c => (c.clienteId == int.Parse(userId)));
            }
            else
            {
                avaliacao = _context.Avaliacoes.Include(a => a.cliente).Include(a => a.Imovel);
            }
            int pagina = (page == null || page < 1) ? 1 : page.Value;
            int nReg = 8;
            imoveisview.paginacao(avaliacao, pagina, nReg);
            return View(imoveisview);
        }

        // GET: Avaliacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes
                .Include(a => a.Imovel)
                .Include(a => a.cliente)
                .FirstOrDefaultAsync(m => m.AvaliacaoId == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        [Authorize(Roles = "Cliente")]

        public IActionResult Create()
        {
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "NomeAlojamento");
            return View();
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]

        public async Task<IActionResult> Create([Bind("AvaliacaoId,PontuacaoAvaliacao,DescricaoAvaliacao,ImovelId,clienteId")] Avaliacao avaliacao)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                avaliacao.clienteId = int.Parse(userId);
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "NomeAlojamento", avaliacao.ImovelId);
            ViewData["clienteId"] = new SelectList(_context.Cliente, "Id", "Nome", avaliacao.clienteId);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Edit/5
        [Authorize(Roles = "Cliente")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "ImovelId", avaliacao.ImovelId);
            ViewData["clienteId"] = new SelectList(_context.Cliente, "Id", "Discriminator", avaliacao.clienteId);
            return View(avaliacao);
        }

        // POST: Avaliacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]

        public async Task<IActionResult> Edit(int id, [Bind("AvaliacaoId,PontuacaoAvaliacao,DescricaoAvaliacao,ImovelId,clienteId")] Avaliacao avaliacao)
        {
            if (id != avaliacao.AvaliacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.AvaliacaoId))
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
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "ImovelId", avaliacao.ImovelId);
            ViewData["clienteId"] = new SelectList(_context.Cliente, "Id", "Discriminator", avaliacao.clienteId);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        [Authorize(Roles = "Admin,Funcionario,Gestor,Cliente")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacoes
                .Include(a => a.Imovel)
                .Include(a => a.cliente)
                .FirstOrDefaultAsync(m => m.AvaliacaoId == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Funcionario,Gestor,Cliente")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacoes.Any(e => e.AvaliacaoId == id);
        }
    }
}
