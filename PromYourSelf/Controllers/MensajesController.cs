﻿using System;
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
    public class MensajesController : Controller
    {
        private readonly RepositorioBase<Mensajes> db;

        public MensajesController(Contexto context)
        {
            db = new RepositorioBase<Mensajes>(context);
        }

        // GET: Mensajes
        public async Task<IActionResult> Index()
        {
            return View(await db.GetListAsync(x => true));
        }

        // GET: Mensajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajes = await db.SearchAsync(id);

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
                await db.SaveAsync(mensajes);
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

            var mensajes = await db.SearchAsync(id);
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
                    await db.ModifiedAsync(mensajes);
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

            var mensajes = await db.SearchAsync(id);
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
            await db.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MensajesExists(int id)
        {
            return db.Exists(id);
        }
    }
}