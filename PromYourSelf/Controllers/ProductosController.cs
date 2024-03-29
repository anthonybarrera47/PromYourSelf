﻿using System;
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
using Newtonsoft.Json;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models.SweetAlert;
using PromYourSelf.Utils;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
    public class ProductosController : BaseController
    {
        private readonly Contexto db;
        private readonly IRepoWrapper _Repo;
        public static List<Productos> Lista;
        public ProductosController(Contexto context, IRepoWrapper RepoProducto)
        {
            db = context;
            _Repo = RepoProducto;
        }

        // GET: Productos
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Nombre", int PageSize = 5)
        {
            if (!string.IsNullOrWhiteSpace(filter))
                Lista = await _Repo.Productos.GetListAsync(x => x.NegocioID == User.GetEmpresaID().ToInt() && x.Nombre.ToUpper().Contains(filter.ToUpper()));
            else
                Lista = await _Repo.Productos.GetListAsync(x => x.NegocioID == User.GetEmpresaID().ToInt());

            var model = PagingList.Create(Lista, PageSize, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }


		// GET: GetProductos
		public async Task<IActionResult> GetProductos()
		{		
			int usuarioId = User.GetUserID().ToInt();
			List<Productos> lista = await _Repo.Productos.GetListAsync(x => x.UsuarioID == usuarioId);			

			return new JsonResult(JsonConvert.SerializeObject(lista));
		}

		// GET: GetEtiquetas
		public async Task<IActionResult> GetEtiquetas()
		{			
			List<Etiquetas> lista = await _Repo.Etiquetas.GetListAsync(x =>true);

			return new JsonResult(JsonConvert.SerializeObject(lista));
		}


		// POST/GET: Etiquetas		
		public async Task<IActionResult> AgregarEtiqueta(string nombre)
		{		
			List<Etiquetas> lista = await _Repo.Etiquetas.GetListAsync(x => x.Nombre.ToLower() == nombre.ToLower());
			if(lista.Count > 0)
			{
				return new JsonResult(JsonConvert.SerializeObject(false));
			}
			Etiquetas etiqueta = new Etiquetas()
			{
				Nombre = nombre,
				UsuarioID = User.GetUserID().ToInt(),				
			};
			bool paso = await _Repo.Etiquetas.SaveAsync(etiqueta);
			return new JsonResult(JsonConvert.SerializeObject(paso));
		}

		// GET: Productos/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _Repo.Productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View(new Productos());
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Productos productos)
        {
            if (ModelState.IsValid)
            {
				productos.NegocioID = User.GetEmpresaID().ToInt();
				productos.UsuarioID = User.GetUserID().ToInt();
                await _Repo.Productos.SaveAsync(productos);
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _Repo.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Productos productos)
        {			
            if (id != productos.ProductoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
				productos.Fotos.RemoveAll(x => !x.Foto.StartsWith("data"));
				productos.NegocioID = User.GetEmpresaID().ToInt();
				productos.UsuarioID = User.GetUserID().ToInt();
				try
                {
                    await _Repo.Productos.ModifiedAsync(productos);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.ProductoID))
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
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _Repo.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Repo.Productos.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _Repo.Productos.Exists(id);
        }
    }
}
