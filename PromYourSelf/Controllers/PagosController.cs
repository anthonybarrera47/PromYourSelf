using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.Models.SweetAlert;

namespace PromYourSelf.Controllers
{
    public class PagosController : BaseController
    {
        private readonly IRepoWrapper _Repo;
        public static List<Pagos> Lista;
        public PagosController(IRepoWrapper RepoEmpleado)
        {
            _Repo = RepoEmpleado;
        }

        // GET: Pagos
        public async Task<IActionResult> Index()
        {
            return View(await _Repo.Pagos.GetListAsync(x => true));
        }

        // GET: Pagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _Repo.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            return View(pagos);
        }

        // GET: Pagos/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.TipoClasificacion = await _Repo.TiposClasficacion.GetListAsync(x => true);
            return View(new Pagos());
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagoID,Fecha,NegocioID,Monto,Concepto")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                await _Repo.Pagos.SaveAsync(pagos);
                return RedirectToAction(nameof(Index));
            }
            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _Repo.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }
            return View(pagos);
        }

        // POST: Pagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagoID,Fecha,NegocioID,Monto,Concepto,UsuarioID,EsNulo,CreadoPor,FechaCreacion,ModificadoPor,FechaModificacion")] Pagos pagos)
        {
            if (id != pagos.PagoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(pagos);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PagosExists(pagos.PagoID))
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
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagos = await _Repo.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            return View(pagos);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Repo.Pagos.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PagosExists(int id)
        {
            List<Pagos> ListaPagos = await _Repo.Pagos.GetListAsync(x => true);
            return ListaPagos.Any(e => e.PagoID == id);
        }
    }
}
