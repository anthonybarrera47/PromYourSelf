using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.ViewModels;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    public class VentasController : Controller
    {
        private readonly Contexto db;
        private readonly IRepoWrapper _Repo;
        private readonly IHttpContextAccessor _accesor;
        public static List<VentasIndexViewModel> Lista;
        public VentasController(Contexto context, IRepoWrapper RepoVenta,IHttpContextAccessor accessor)
        {
            db = context;
            _Repo = RepoVenta;
            _accesor = accessor;
        }

        // GET: Ventas
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "FechaCreacion", int PageSize = 5)
        {
            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.Ventas.GetListAsync(x => x.FechaCreacion.ToString().Contains(filter.ToUpper()));
            else
                Lista = await _Repo.Ventas.GetListAsync(x => true);

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

            var ventas = await _Repo.Ventas.SearchAsync(id);

            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // GET: Ventas/Create
        public async Task< IActionResult> Create()
        {
            //var lista = await (from datos in db.Productos.AsNoTracking().AsQueryable()
            //               .Where(x => x.EsNulo == false)
            //                   select new Generico
            //                   {
            //                       Id = datos.ProductoID.ToString(),
            //                       Name = datos.Nombre
            //                   }).ToListAsync();
            ViewBag.Clientes = await _Repo.Usuarios.GetListAsync(x => true);
            ViewBag.Productos = await _Repo.Productos.GetListAsync(x => true);
            return View(new Ventas());
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ventas ventas)
        {
            //buscar producto
            //calcular
            //guardar
            if (ModelState.IsValid)
            {

                await _Repo.Ventas.SaveAsync(ventas);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = await _Repo.Usuarios.GetListAsync(x => true);
            ViewBag.Productos = await _Repo.Productos.GetListAsync(x => true);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _Repo.Ventas.SearchAsync(id);
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
                    await _Repo.Ventas.ModifiedAsync(ventas);
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

            var ventas = await _Repo.Ventas.SearchAsync(id);
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
            await _Repo.Ventas.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VentasExists(int id)
        {
            return _Repo.Ventas.Exists(id);
        }
    }
}
