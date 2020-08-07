﻿using System;
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
using PromYourSelf.ViewModels;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    public class HorariosController : BaseController
    {
        private readonly Contexto db;
        private readonly IRepoWrapper _Repo;
        public static List<Horarios> Lista;

        public HorariosController(Contexto context, IRepoWrapper RepoHorario)
        {
            db = context;
            _Repo = RepoHorario;
        }

        // GET: Horarios
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Lunes", int PageSize = 5)
        {

            Lista = await _Repo.Horarios.GetListAsync(x => true);

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "Lunes");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarios = await _Repo.Horarios.FindAsync(id);

            if (horarios == null)
            {
                return NotFound();
            }

            return View(horarios);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            return View(new HorariosViewModel());
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HorariosViewModel horarios)
        {
            if (ModelState.IsValid)
            {
                Horarios horario = horarios.ConvertToHorario();
                await _Repo.Horarios.SaveAsync(horario);
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

            var horarios = await _Repo.Horarios.FindAsync(id);
            HorariosViewModel Horario = horarios.ConvertToHorariosViewModel();
            if (Horario == null)
            {
                return NotFound();
            }
            return View(Horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HorariosViewModel horarios)
        {
            if (id != horarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Horarios horario = horarios.ConvertToHorario();
                    await _Repo.Horarios.ModifiedAsync(horario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorariosExists(horarios.Id))
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

            var horarios = await _Repo.Horarios.FindAsync(id);
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
