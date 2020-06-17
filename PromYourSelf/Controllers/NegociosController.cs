using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PromYourSelf.Controllers
{
    public class NegociosController : Controller
    {
        private readonly RepositorioBase<Negocios> db;
        public NegociosController(Contexto context)
        {
            db = new RepositorioBase<Negocios>(context);
        }

        // GET: Negocios
        public async Task<IActionResult> Index()
        {
            return View(await db.GetListAsync(x => true));
        }

        // GET: Negocios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocios = await db.SearchAsync(id);

            if (negocios == null)
            {
                return NotFound();
            }

            return View(negocios);
        }

        // GET: Negocios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Negocios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Negocios negocios)
        {
            if (ModelState.IsValid)
            {
                await db.SaveAsync(negocios);
                return RedirectToAction(nameof(Index));
            }
            return View(negocios);
        }

        // GET: Negocios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocios = await db.SearchAsync(id);
            if (negocios == null)
            {
                return NotFound();
            }
            return View(negocios);
        }

        // POST: Negocios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Negocios negocios)
        {
            if (id != negocios.NegocioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await db.ModifiedAsync(negocios);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NegociosExists(negocios.NegocioID))
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
            return View(negocios);
        }

        // GET: Negocios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocios = await db.SearchAsync(id);
            if (negocios == null)
            {
                return NotFound();
            }

            return View(negocios);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await db.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool NegociosExists(int id)
        {
            return db.Exists(id);
        }
    }
}
