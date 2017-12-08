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
    public class SacolaDETsController : Controller
    {
        private readonly Conexao _context;

        public SacolaDETsController(Conexao context)
        {
            _context = context;
        }

        // GET: SacolaDETs
        public async Task<IActionResult> Index(int id)
        {
            var conexao = _context.SacolaDETs.Where(s => s.SacolaCAB.Id == id).Include(s => s.Produto).Include(s => s.SacolaCAB); 
            return View(await conexao.ToListAsync());
        }

        // GET: SacolaDETs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var sacolaDET = await _context.SacolaDETs
            //    .Include(s => s.Produto)
            //    .Include(s => s.SacolaCAB)
            //    .SingleOrDefaultAsync(m => m.Id == id);
            //if (sacolaDET == null)
            //{
            //    return NotFound();
            //}

            var produtos = await _context.Produtos.ToListAsync();

            return View(produtos);
        }

        // GET: SacolaDETs/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao");
            ViewData["SacolaCABId"] = new SelectList(_context.SacolaCABs, "Id", "Descricao");
            return View();
        }

        // POST: SacolaDETs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,SacolaCABId")] SacolaDET sacolaDET)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sacolaDET);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", sacolaDET.ProdutoId);
            ViewData["SacolaCABId"] = new SelectList(_context.SacolaCABs, "Id", "Descricao", sacolaDET.SacolaCABId);
            return View(sacolaDET);
        }

        // GET: SacolaDETs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacolaDET = await _context.SacolaDETs.SingleOrDefaultAsync(m => m.Id == id);
            if (sacolaDET == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", sacolaDET.ProdutoId);
            ViewData["SacolaCABId"] = new SelectList(_context.SacolaCABs, "Id", "Descricao", sacolaDET.SacolaCABId);
            return View(sacolaDET);
        }

        // POST: SacolaDETs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,SacolaCABId")] SacolaDET sacolaDET)
        {
            if (id != sacolaDET.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacolaDET);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacolaDETExists(sacolaDET.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", sacolaDET.ProdutoId);
            ViewData["SacolaCABId"] = new SelectList(_context.SacolaCABs, "Id", "Descricao", sacolaDET.SacolaCABId);
            return View(sacolaDET);
        }

        // GET: SacolaDETs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacolaDET = await _context.SacolaDETs
                .Include(s => s.Produto)
                .Include(s => s.SacolaCAB)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sacolaDET == null)
            {
                return NotFound();
            }

            return View(sacolaDET);
        }

        // POST: SacolaDETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sacolaDET = await _context.SacolaDETs.SingleOrDefaultAsync(m => m.Id == id);
            _context.SacolaDETs.Remove(sacolaDET);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacolaDETExists(int id)
        {
            return _context.SacolaDETs.Any(e => e.Id == id);
        }
    }
}
