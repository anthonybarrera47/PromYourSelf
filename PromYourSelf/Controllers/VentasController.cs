using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    public class VentasController : Controller
    {
        private readonly RepositorioBase<Ventas> db;
        public static List<Ventas> Lista;
        private readonly IRepositoryVentas _RepoVenta;
        public VentasController(Contexto context, IRepositoryVentas RepoVenta)
        {
            db = new RepositorioBase<Ventas>(context);
            _RepoVenta = RepoVenta;
        }

        // GET: Ventas
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "FechaCreacion", int PageSize = 5)
        {
            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await db.GetListAsync(x => x.FechaCreacion.ToString().Contains(filter.ToUpper()));
            else
                Lista = await db.GetListAsync(x => true);

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "FechaCreacion");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await db.SearchAsync(id);

            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                await db.SaveAsync(ventas);
                return RedirectToAction(nameof(Index));
            }
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await db.SearchAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ventas ventas)
        {
            if (id != ventas.VentaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await db.ModifiedAsync(ventas);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasExists(ventas.VentaID))
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
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await db.SearchAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await db.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VentasExists(int id)
        {
            return db.Exists(id);
        }
    }
}
