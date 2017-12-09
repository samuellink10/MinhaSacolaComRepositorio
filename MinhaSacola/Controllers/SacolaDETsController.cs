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
            var conexao = SacolaRepository.Instance.GetDetails(id);
            return View(await conexao.ToListAsync());
        }

   
   

      

        // GET: SacolaDETs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacolaDET = SacolaRepository.Instance.GetDetailSingle(id);
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
            var sacolaDET = SacolaRepository.Instance.GetDetailSingle(id);
            SacolaRepository.Instance.DeleteSacolaDetails(sacolaDET);
            return RedirectToAction(nameof(Index));
        }

        private bool SacolaDETExists(int id)
        {
            return _context.SacolaDETs.Any(e => e.Id == id);
        }
    }
}
