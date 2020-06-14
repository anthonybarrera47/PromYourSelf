using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades;

namespace PromYourSelf.Controllers
{
    public class MensajesController : Controller
    {
        private readonly Contexto _context;

        public MensajesController(Contexto context)
        {
            _context = context;
        }

        // GET: Mensajes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mensaje.ToListAsync());
        }

        // GET: Mensajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajes = await _context.Mensaje
                .FirstOrDefaultAsync(m => m.MensajeID == id);
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
        public async Task<IActionResult> Create([Bind("MensajeID,Contenido,Tipo,CreadoPor,FechaCreacion,ModificadoPor,FechaModificacion")] Mensajes mensajes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensajes);
                await _context.SaveChangesAsync();
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

            var mensajes = await _context.Mensaje.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("MensajeID,Contenido,Tipo,CreadoPor,FechaCreacion,ModificadoPor,FechaModificacion")] Mensajes mensajes)
        {
            if (id != mensajes.MensajeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensajes);
                    await _context.SaveChangesAsync();
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

            var mensajes = await _context.Mensaje
                .FirstOrDefaultAsync(m => m.MensajeID == id);
            if (mensajes == null)
            {
                return NotFound();
            }

            return View(mensajes);
        }

        // POST: Mensajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensajes = await _context.Mensaje.FindAsync(id);
            _context.Mensaje.Remove(mensajes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensajesExists(int id)
        {
            return _context.Mensaje.Any(e => e.MensajeID == id);
        }
    }
}
