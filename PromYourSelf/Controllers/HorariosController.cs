﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;

namespace PromYourSelf.Controllers
{
    public class HorariosController : Controller
    {
        private readonly Contexto db;
        private readonly IRepoWrapper _Repo;

        public HorariosController(Contexto context, IRepoWrapper RepoHorario)
        {
            db = context;
            _Repo = RepoHorario;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            return View(await _Repo.Horarios.GetListAsync(x => true));
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarios = await _Repo.Horarios.SearchAsync(id);

            if (horarios == null)
            {
                return NotFound();
            }

            return View(horarios);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                await _Repo.Horarios.SaveAsync(horarios);
                return RedirectToAction(nameof(Index));
            }
            return View(horarios);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarios = await _Repo.Horarios.SearchAsync(id);
            if (horarios == null)
            {
                return NotFound();
            }
            return View(horarios);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Horarios horarios)
        {
            if (id != horarios.HorarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Repo.Horarios.ModifiedAsync(horarios);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorariosExists(horarios.HorarioID))
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
            return View(horarios);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarios = await _Repo.Horarios.SearchAsync(id);
            if (horarios == null)
            {
                return NotFound();
            }

            return View(horarios);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Repo.Horarios.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool HorariosExists(int id)
        {
            return _Repo.Horarios.Exists(id);
        }
    }
}
