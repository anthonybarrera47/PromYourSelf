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
using PromYourSelf.Models.SweetAlert;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    public class CitasController : BaseController
    {
        private readonly Contexto db; 
        private readonly IRepoWrapper _Repo;
        public static List<Citas> Lista;
       
        public CitasController(Contexto context, IRepoWrapper RepoCita)
        {
            db = context;
            _Repo = RepoCita;
        }

        // GET: Citas
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "FechaInicio", int PageSize = 5)
        {
            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.Citas.GetListAsync(x => x.FechaInicio.ToString().Contains(filter.ToUpper()));
            else
                Lista = await _Repo.Citas.GetListAsync(x => true);

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "FechaInicio");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _Repo.Citas.FindAsync(id);

            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Citas citas)
        {
            if (ModelState.IsValid)
            {
                await _Repo.Citas.SaveAsync(citas);
                return RedirectToAction(nameof(Index));
            }
            return View(citas);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _Repo.Citas.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }
            return View(citas);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Citas citas)
        {
            if (id != citas.CitaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Repo.Citas.ModifiedAsync(citas);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitasExists(citas.CitaID))
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
            return View(citas);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _Repo.Citas.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Repo.Citas.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CitasExists(int id)
        {
            return _Repo.Citas.Exists(id);
        }

     
    }
}
