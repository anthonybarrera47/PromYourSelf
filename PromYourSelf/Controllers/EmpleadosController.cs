﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using BLL;
using PromYourSelf.Utils;
using DNTBreadCrumb.Core;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models.SweetAlert;

namespace PromYourSelf.Controllers
{
    [BreadCrumb(Title = "Empleado", Url = "/Empleados/Index", Order = 0)]
    public class EmpleadosController : BaseController
    {
        private readonly Contexto db;
        private readonly IRepoWrapper _Repo;
        public static List<Empleados> Lista;
        public EmpleadosController(Contexto context, IRepoWrapper RepoEmpleado)
        {
            db = context;
            _Repo = RepoEmpleado;
        }

        // GET: Empleados
        [BreadCrumb(Title = "Listado de Empelado", Order = 1)]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Nombre", int PageSize = 5)
        {
            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.Empleados.GetListAsync(x => x.Nombre.ToUpper().Contains(filter.ToUpper()));
            else
                Lista = await _Repo.Empleados.GetListAsync(x => true);

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: Empleados/Details/5
        [BreadCrumb(Title = "Detalle del Empleado", Order = 2)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _Repo.Empleados.FindAsync(id);

            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        [BreadCrumb(Title = "Crear Empleado", Order = 3)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleados Empleado)
        {
            string strbase64 = await Utils.Utils.ImageToBase64(Empleado.FotoFile);
            Empleado.Foto = strbase64;


            if (ModelState.IsValid)
            {
                await _Repo.Empleados.SaveAsync(Empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(Empleado);
        }

        // GET: Empleados/Edit/5
        [BreadCrumb(Title = "Editar Empleado", Order = 4)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _Repo.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empleados empleados)
        {
            if (id != empleados.EmpleadoID)
            {
                return NotFound();
            }
            if (empleados.FotoFile != null)
            {
                string strbase64 = await Utils.Utils.ImageToBase64(empleados.FotoFile);
                empleados.Foto = strbase64;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Repo.Empleados.ModifiedAsync(empleados);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.EmpleadoID))
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
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        [BreadCrumb(Title = "Eliminar Empelado", Order = 5)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _Repo.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Repo.Empleados.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _Repo.Empleados.Exists(id);
        }
    }
}
