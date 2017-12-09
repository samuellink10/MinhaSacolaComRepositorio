using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhaSacola.Data;
using MinhaSacola.Models;
using MinhaSacola.Repository;

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
            var p = SacolaRepository.Instance.GetAll();
            return View(p);
        }

        // GET: SacolaCABs/Details/5

        // GET: SacolaCABs/Create
        public IActionResult Create()
        {
            SacolaCABProduto sp = new SacolaCABProduto();
            sp.produto = ProdutoRepository.Instance.GetAll();
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
                SacolaRepository.Instance.Create(Descricao, produtos);
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

            var sacolaCAB = SacolaRepository.Instance.Edit(id);
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
                    SacolaRepository.Instance.Update(sacolaCAB);
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

            var sacolaCAB = SacolaRepository.Instance.Edit(id);
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
            var sacolaCAB = SacolaRepository.Instance.Edit(id);
            SacolaRepository.Instance.Delete(sacolaCAB);
            return RedirectToAction(nameof(Index));
        }

        private bool SacolaCABExists(int id)
        {
            return _context.SacolaCABs.Any(e => e.Id == id);
        }


    }
}
