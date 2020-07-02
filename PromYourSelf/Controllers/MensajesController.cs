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
    public class MensajesController : Controller
    {
        private readonly Contexto db;
        private readonly IRepoWrapper _Repo;
        public static List<Mensajes> Lista;

        public MensajesController(Contexto context, IRepoWrapper RepoMensaje)
        {
            db = context;
            _Repo = RepoMensaje;
        }

        // GET: Mensajes
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Contenido", int PageSize = 5)
        {
            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.Mensajes.GetListAsync(x => x.Contenido.ToUpper().Contains(filter.ToUpper()));
            else
                Lista = await _Repo.Mensajes.GetListAsync(x => true);

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "Contenido");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: Mensajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajes = await _Repo.Mensajes.SearchAsync(id);

            if (mensajes == null)
            {
                return NotFound();
            }

            return View(mensajes);
        }

        // GET: Mensajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mensajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mensajes mensajes)
        {
            if (ModelState.IsValid)
            {
                await _Repo.Mensajes.SaveAsync(mensajes);
                return RedirectToAction(nameof(Index));
            }
            return View(mensajes);
        }

        // GET: Mensajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajes = await _Repo.Mensajes.SearchAsync(id);
            if (mensajes == null)
            {
                return NotFound();
            }
            return View(mensajes);
        }

        // POST: Mensajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mensajes mensajes)
        {
            if (id != mensajes.MensajeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Repo.Mensajes.ModifiedAsync(mensajes);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensajesExists(mensajes.MensajeID))
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
            return View(mensajes);
        }

        // GET: Mensajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajes = await _Repo.Mensajes.SearchAsync(id);
            if (mensajes == null)
            {
                return NotFound();
            }

            return View(mensajes); ;
        }

        // POST: Mensajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Repo.Mensajes.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MensajesExists(int id)
        {
            return _Repo.Mensajes.Exists(id);
        }
    }
}
