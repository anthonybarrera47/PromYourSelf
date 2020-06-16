using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PromYourSelf.Controllers
{
    public class NegociosController : Controller
    {
        private readonly Contexto _context;

        public NegociosController(Contexto context)
        {
            _context = context;
        }

        // GET: Negocios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Negocios.ToListAsync());
        }

        // GET: Negocios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocios = await _context.Negocios
                .FirstOrDefaultAsync(m => m.NegocioID == id);
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
        public async Task<IActionResult> Create([Bind("NegocioID,NombreComercial,Direccion,Telefono1,Telefono2,Latitud,Longitud,CreadoPor,FechaCreacion,ModificadoPor,FechaModificacion")] Negocios negocios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(negocios);
                await _context.SaveChangesAsync();
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

            var negocios = await _context.Negocios.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("NegocioID,NombreComercial,Direccion,Telefono1,Telefono2,Latitud,Longitud,CreadoPor,FechaCreacion,ModificadoPor,FechaModificacion")] Negocios negocios)
        {
            if (id != negocios.NegocioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(negocios);
                    await _context.SaveChangesAsync();
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

            var negocios = await _context.Negocios
                .FirstOrDefaultAsync(m => m.NegocioID == id);
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
            var negocios = await _context.Negocios.FindAsync(id);
            _context.Negocios.Remove(negocios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NegociosExists(int id)
        {
            return _context.Negocios.Any(e => e.NegocioID == id);
        }
    }
}
