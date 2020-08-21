using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    public class TipoClasificacionsController : Controller
    {
        private readonly IRepoWrapper _Repo;
        private readonly Contexto _context;
        public static List<TipoClasificacion> Lista;
        public TipoClasificacionsController(IRepoWrapper RepoTipo,Contexto contexto)
        {
            _Repo = RepoTipo;
            _context = contexto;
        }

        public async Task<PagingList<TipoClasificacion>> FillIndex(string filter, string Desde, string Hasta, int page = 1, string sortExpression = "Descripcion", int PageSize = 10)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            if (Desde is null)
                Desde = firstDayOfMonth.ToString("dd/MM/yyyy");
            if (Hasta is null)
                Hasta = lastDayOfMonth.ToString("dd/MM/yyyy");

            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.TiposClasificacion.GetListAsync(x => true);
            else
                Lista = await _Repo.TiposClasificacion.GetListAsync(x => true);

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "Fecha");
            var RoutesValues = new RouteValueDictionary {
                            { "filter", filter},{"Desde",Desde},{"Hasta",Hasta}
            };
            model.RouteValue = RoutesValues;
            model.Action = "Index";
            return model;
        }
        // GET: TipoClasificacions
        public async Task<IActionResult> Index(string filter, string Desde, string Hasta, int page = 1, string sortExpression = "Descripcion")
        {
            int PageSize = 10;
            var Modelo = await FillIndex(filter, Desde, Hasta, page, sortExpression, PageSize);
            return View(Modelo);
        }

        // GET: TipoClasificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClasificacion = await _Repo.TiposClasificacion.FindAsync(m => m.TipoClasificacionID == id);
            if (tipoClasificacion == null)
            {
                return NotFound();
            }

            return View(tipoClasificacion);
        }

        // GET: TipoClasificacions/Create
        public IActionResult Create()
        {
            return View(new TipoClasificacion());
        }

        // POST: TipoClasificacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion")] TipoClasificacion tipoClasificacion)
        {
            if (ModelState.IsValid)
            {
               await _Repo.TiposClasificacion.SaveAsync(tipoClasificacion);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoClasificacion);
        }

        // GET: TipoClasificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClasificacion = await _Repo.TiposClasificacion.FindAsync(id);
            if (tipoClasificacion == null)
            {
                return NotFound();
            }
            return View(tipoClasificacion);
        }

        // POST: TipoClasificacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoClasificacionID,Descripcion")] TipoClasificacion tipoClasificacion)
        {
            if (id != tipoClasificacion.TipoClasificacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Repo.TiposClasificacion.ModifiedAsync(tipoClasificacion);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoClasificacionExists(tipoClasificacion.TipoClasificacionID))
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
            return View(tipoClasificacion);
        }

        // GET: TipoClasificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClasificacion = await _Repo.TiposClasificacion.FindAsync(m => m.TipoClasificacionID == id);
            if (tipoClasificacion == null)
            {
                return NotFound();
            }

            return View(tipoClasificacion);
        }

        // POST: TipoClasificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoClasificacion = await _Repo.TiposClasificacion.FindAsync(id);
            await _Repo.TiposClasificacion.DeleteAsync(tipoClasificacion.TipoClasificacionID);
            return RedirectToAction(nameof(Index));
        }

        private bool TipoClasificacionExists(int id)
        {
            return _context.TipoClasificacion.Any(e => e.TipoClasificacionID == id);
        }
    }
}
