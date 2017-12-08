using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaSacola.Data;
using MinhaSacola.Models;

namespace MinhaSacola.Controllers
{
    public class SacolaCABsController : Controller
    {
        private readonly Conexao _context;

        public SacolaCABsController(Conexao context)
        {
            _context = context;
        }

        // GET: SacolaCABs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SacolaCABs.ToListAsync());
        }

        // GET: SacolaCABs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos.ToListAsync();

            return View(produtos);
        }

        // GET: SacolaCABs/Create
        public IActionResult Create()
        {
            SacolaCABProduto sp = new SacolaCABProduto();
            sp.produto = Conexao.Instance.Produtos.ToList();
            return View(sp);
        }

        // POST: SacolaCABs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public async Task<IActionResult> CreateSacola(string Descricao, List<int> produtos)
        {
            if (ModelState.IsValid)
            {
                SacolaCAB s = new SacolaCAB();
                SacolaDET d = new SacolaDET();
                s.Descricao = Descricao;
                s.DataCriacao = DateTime.Now;
                _context.SacolaCABs.Add(s);                
                await _context.SaveChangesAsync();
                foreach (var item in produtos)
                {
                    d.ProdutoId = item;
                    d.SacolaCABId = s.Id;
                    _context.SacolaDETs.Add(d);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: SacolaCABs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacolaCAB = await _context.SacolaCABs.SingleOrDefaultAsync(m => m.Id == id);
            if (sacolaCAB == null)
            {
                return NotFound();
            }
            return View(sacolaCAB);
        }

        // POST: SacolaCABs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,DataCriacao")] SacolaCAB sacolaCAB)
        {
            if (id != sacolaCAB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacolaCAB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacolaCABExists(sacolaCAB.Id))
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
            return View(sacolaCAB);
        }

        // GET: SacolaCABs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacolaCAB = await _context.SacolaCABs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sacolaCAB == null)
            {
                return NotFound();
            }

            return View(sacolaCAB);
        }

        // POST: SacolaCABs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sacolaCAB = await _context.SacolaCABs.SingleOrDefaultAsync(m => m.Id == id);
            _context.SacolaCABs.Remove(sacolaCAB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacolaCABExists(int id)
        {
            return _context.SacolaCABs.Any(e => e.Id == id);
        }
    }
}
