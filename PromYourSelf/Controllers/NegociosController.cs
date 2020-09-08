using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
	public class NegociosController : BaseController
	{
		private readonly Contexto db;
		private readonly UserManager<Usuarios> _userManager;
		private readonly SignInManager<Usuarios> _signInManager;
		private readonly IRepoWrapper _Repo;
		public static List<Negocios> Lista;
		public NegociosController(Contexto context, IRepoWrapper RepoNegocio, SignInManager<Usuarios> signInManager, UserManager<Usuarios> userManager)
		{
			db = context;
			_Repo = RepoNegocio;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		// GET: GetNegocios	
		public async Task<IActionResult> GetNegocios(string filter, string sortExpression = "NombreComercial", int PageSize = 5)
		{
			if (!string.IsNullOrWhiteSpace(filter))
				Lista = await _Repo.Negocios.GetListAsync(x => x.NombreComercial.ToUpper().Contains(filter.ToUpper()));
			else
				Lista = await _Repo.Negocios.GetListAsync(x => true);

			return new JsonResult(JsonConvert.SerializeObject(Lista));
		}


		public async Task<IActionResult> GetUsuariosMensajes()
		{
			try
			{
				//int userId = (User.GetPosicion() == Posicion.Administrador.GetDescription()) ? User.GetEmpresaID().ToInt() : User.GetUserID().ToInt();
				int userId = User.GetUserID().ToInt();
				string sql = @"SELECT 0 As Id, m.Contenido, m.UsuarioID as UsuarioId, m.ReceptorID , u.Posicion, ISNULL(n.NombreComercial,u.Nombres+' '+u.Apellidos)AS Nombre,m.MensajeID FROM Mensaje as m 
INNER JOIN AspNetUsers as u ON u.Id = m.UsuarioID
LEFT JOIN Negocios as n ON n.UsuarioID = u.Id
WHERE m.UsuarioID = {0} OR m.ReceptorID = {0}";
				var ListaInterna = db.UsuariosMensajes.FromSql(sql, userId)
					.AsNoTracking().ToList();

				return new JsonResult(JsonConvert.SerializeObject(ListaInterna));
			}
			catch (Exception ex)
			{
				new Exception(ex.Message);
				throw;
			}
		}


		public async Task<IActionResult> GetProductosByNegocio(int negocioId, int page = 1, string sortExpression = "NombreComercial", int PageSize = 5)
		{
			List<Productos> lista = new List<Productos>();
			lista = await _Repo.Productos.GetListAsync(x => x.NegocioID == negocioId);

			return new JsonResult(JsonConvert.SerializeObject(lista));
		}

		// GET: s
		public async Task<IActionResult> GetProductos(string filter, int page = 1, string sortExpression = "NombreComercial", int PageSize = 5)
		{
			List<Productos> lista = new List<Productos>();
			if (!string.IsNullOrWhiteSpace(filter))
				lista = await _Repo.Productos.GetListAsync(x => x.Nombre.ToUpper().Contains(filter.ToUpper()) || x.Etiquetas.Exists(y => y.Etiqueta.Nombre.ToUpper().Contains(filter.ToUpper())));
			else
				lista = await _Repo.Productos.GetListAsync(x => true);

			return new JsonResult(JsonConvert.SerializeObject(lista));
		}


		// GET: Negocios
		public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "NombreComercial", int PageSize = 5)
		{
			if (!string.IsNullOrWhiteSpace(filter))
				Lista = await _Repo.Negocios.GetListAsync(x => x.NombreComercial.ToUpper().Contains(filter.ToUpper()));
			else
				Lista = await _Repo.Negocios.GetListAsync(x => true);

			var model = PagingList.Create(Lista, PageSize, page, sortExpression, "NombreComercial");
			model.RouteValue = new RouteValueDictionary {
							{ "filter", filter}
			};
			model.Action = "Index";

			return View(model);
		}

		// GET: Negocios/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var negocios = await _Repo.Negocios.FindAsync(id);

			if (negocios == null)
			{
				return NotFound();
			}
			negocios.Horarios = await _Repo.Horarios.FindAsyncByNegocio(negocios.NegocioID);
			return View(negocios);
		}

		// GET: Negocios/Details/5
		public async Task<IActionResult> MiNegocio(int? id)
		{
			Negocios negocio = (await _Repo.Negocios.GetListAsync(m => m.UsuarioID == id)).FirstOrDefault();
			negocio.Horarios = await _Repo.Horarios.FindAsyncByNegocio(negocio.NegocioID);

			if (negocio == null)
			{
				return NotFound();
			}

			return View(negocio);
		}

		// GET: Negocios/Create
		public IActionResult Create()
		{
			return View(new Negocios());
		}

		// POST: Negocios/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Create(Negocios negocios)
		{
			if (ModelState.IsValid)
			{
				int UsuarioId = User.GetUserID().ToInt();
				negocios.UsuarioID = UsuarioId;

				if (await _Repo.Negocios.SaveAsync(negocios))
				{
					var Usuario = await _Repo.Usuarios.FindAsync(UsuarioId);
					Usuario.Posicion = Posicion.Administrador.GetDescription();
					await _Repo.Usuarios.UpdateClaimsUser(_signInManager, _userManager, Usuario);
				}

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

			var negocios = await _Repo.Negocios.FindAsync(id);
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
		[Authorize]
		public async Task<IActionResult> Edit(int id, Negocios negocios)
		{
			if (id != negocios.NegocioID)
			{
				return View("NotFoundView");
			}

			if (ModelState.IsValid)
			{
				try
				{
					negocios.UsuarioID = User.GetUserID().ToInt();
					await _Repo.Negocios.ModifiedAsync(negocios);
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

			var negocios = await _Repo.Negocios.FindAsync(id);
			if (negocios == null)
			{
				return NotFound();
			}

			return View(negocios);
		}

		// POST: Negocios/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _Repo.Negocios.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		private bool NegociosExists(int id)
		{
			return _Repo.Negocios.Exists(id);
		}
	}
}
