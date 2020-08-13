using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.Models.SweetAlert;
using PromYourSelf.Utils;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    [BreadCrumb(Title = "Pagos", Url = "/Pagos/Index", Order = 0)]
    public class PagosController : BaseController
    {
        private readonly IRepoWrapper _Repo;
        public static List<Pagos> Lista;
        public PagosController(IRepoWrapper RepoEmpleado)
        {
            _Repo = RepoEmpleado;
        }

        // GET: Pagos
        [BreadCrumb(Title = "Listado de Pagos", Order = 1)]
        public async Task<IActionResult> Index(string filter, string Desde, string Hasta, int page = 1, string sortExpression = "Monto")
        {
            int PageSize = 10;
            var Modelo = await FillIndex(filter,Desde,Hasta, page, sortExpression, PageSize);
            return View(Modelo);
        }
        public async Task<ActionResult> PartialIndex(string filter, string Desde, string Hasta, int page = 1, string sortExpression = "Monto")
        {
            int PageSize = 10;
            var Modelo = await FillIndex(filter, Desde, Hasta, page, sortExpression,PageSize);
            return PartialView("Index", Modelo);
        }
        public async Task<PagingList<Pagos>> FillIndex(string filter,string Desde,string Hasta, int page = 1, string sortExpression = "Monto", int PageSize = 10)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            if (Desde is null)
                Desde = firstDayOfMonth.ToString("dd/MM/yyyy");
            if (Hasta is null)
                Hasta = lastDayOfMonth.ToString("dd/MM/yyyy");

            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.Pagos.GetListAsync(x => true);
            else
                Lista = await _Repo.Pagos.GetListAsync(x => true);

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "Fecha");
            var RoutesValues = new RouteValueDictionary {
                            { "filter", filter},{"Desde",Desde},{"Hasta",Hasta}
            };
            model.RouteValue = RoutesValues;
            model.Action = "Index";
            return model;
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
            ViewBag.Productos = await _Repo.Productos.GetListAsync(x => true);
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
