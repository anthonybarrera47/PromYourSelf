using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Authorization;
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
using PromYourSelf.ViewModels;
using QRCoder;
using ReflectionIT.Mvc.Paging;

namespace PromYourSelf.Controllers
{
	public class CitasController : BaseController
	{
		private readonly Contexto db;
		private readonly IRepoWrapper _Repo;
		public static List<Citas> Lista;

		public CitasController(Contexto context, IRepoWrapper RepoCita)
		{
			db = context;
			_Repo = RepoCita;
		}

		// GET: Citas
		[Authorize]
		public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "FechaInicio", int PageSize = 5)
		{
			if (!string.IsNullOrWhiteSpace(filter))
				Lista = await _Repo.Citas.GetListAsync(x => x.FechaInicio.ToString().Contains(filter.ToUpper()));
			else
				Lista = await _Repo.Citas.GetListAsync(x => true);

			var model = PagingList.Create(Lista, PageSize, page, sortExpression, "FechaInicio");
			model.RouteValue = new RouteValueDictionary {
							{ "filter", filter}
			};
			model.Action = "Index";

			return View(model);
		}

		// GET: Historial
		[Authorize]
		public async Task<IActionResult> Historial(string filter, int page = 1, string sortExpression = "FechaInicio", int PageSize = 5)
		{
			if (!string.IsNullOrWhiteSpace(filter))
				Lista = await _Repo.Citas.GetListAsync(x => x.UsuarioID == User.GetUserID().ToInt() && x.FechaInicio.ToString().Contains(filter.ToUpper()));
			else
				Lista = await _Repo.Citas.GetListAsync(x => true && x.UsuarioID == User.GetUserID().ToInt());

			var model = PagingList.Create(Lista, PageSize, page, sortExpression, "FechaInicio");
			model.RouteValue = new RouteValueDictionary {
							{ "filter", filter}
			};
			model.Action = "Index";

			return View(model);
		}

		// GET: GetCitas
		[Authorize]
		public async Task<IActionResult> GetCitas()
		{
			List<object> lista_anonima = new List<object>();
			int empresaId = User.GetEmpresaID().ToInt();
			List<Citas> lista_citas = await _Repo.Citas.GetListAsync(x => x.UsuarioID == User.GetUserID().ToInt() || x.NegocioID == empresaId);
			foreach (Citas cita in lista_citas)
			{
				Productos producto = await _Repo.Productos.FindAsync(cita.ProductoID);
				Negocios negocio = await _Repo.Negocios.FindAsync(cita.NegocioID);
				Usuarios usuario = await _Repo.Usuarios.FindAsync(cita.UsuarioID);
				lista_anonima.Add(new { cita, producto, negocio, usuario });
			}

			return new JsonResult(JsonConvert.SerializeObject(lista_anonima));
		}

		// GET: Citas/Details/5
		[Authorize]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Citas cita = await _Repo.Citas.FindAsync(id);
			Productos producto = await _Repo.Productos.FindAsync(cita.ProductoID);
			Negocios negocio = await _Repo.Negocios.FindAsync(cita.NegocioID);
			CitasViewModel cvm = new CitasViewModel()
			{
				Nombre = producto.Nombre,
				Descripcion = producto.Descripcion,
				Notas = cita.Notas,
				Precio = producto.Precio,
				NombreComercial = negocio.NombreComercial,
				CodigoComprobacion = cita.CodigoComprobacion,
				FechaInicio = cita.FechaInicio,
				CreatedAt = cita.FechaCreacion,
				NegocioID = cita.NegocioID,
				UsuarioNegocioID = negocio.UsuarioID
				};
			string url = "https://localhost:44386/Citas/Comprobar?codigo=" + cvm.CodigoComprobacion;
			ViewBag.txtQRCode = url;
			QRCodeGenerator qrGenerator = new QRCodeGenerator();
			QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
			QRCode qrCode = new QRCode(qrCodeData);
			//System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
			//imgBarCode.Height = 150;
			//imgBarCode.Width = 150;
			using (Bitmap bitMap = qrCode.GetGraphic(20))
			{
				using (MemoryStream ms = new MemoryStream())
				{
					bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
					ViewBag.imageBytes = ms.ToArray();
					//imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
				}
			}
			if (cita == null)
			{
				return NotFound();
			}
			return View(cvm);
		}

		[Authorize]
		public async Task<IActionResult> Comprobar(string codigo)
		{
			bool comprobado = (await _Repo.Citas.GetListAsync(x => x.CodigoComprobacion == codigo && x.Estado != EstadoCita.Cancelada && x.Estado != EstadoCita.Finalizado)).ToList().Count() > 0;
			ViewBag.Comprobado = comprobado;
			return View();
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Aceptar(int? id, int estado = -1)
		{
			if (estado < 0) estado = (int)EstadoCita.Aceptada;
			Citas cita = (await _Repo.Citas.GetListAsync(x => x.CitaID == id)).FirstOrDefault();
			if (cita != null)
			{
				cita.Estado = (EstadoCita)estado;
				bool paso = await _Repo.Citas.ModifiedAsync(cita);
				return new JsonResult(JsonConvert.SerializeObject(paso));
			}
			else
			{
				return new JsonResult(JsonConvert.SerializeObject(false));
			}
		}




		// GET: Citas/Create
		public async Task<IActionResult> Create(int servicio)
		{
			Productos producto = await _Repo.Productos.FindAsync(x => x.ProductoID == servicio);
			Negocios negocio = await _Repo.Negocios.FindAsync(x => x.NegocioID == producto.NegocioID);
			Citas cita = new Citas() { NegocioID = negocio.NegocioID, ProductoID = producto.ProductoID };
			CitasViewModel model = new CitasViewModel(producto.Nombre, producto.Precio, producto.Descripcion, producto.Etiquetas, negocio.NombreComercial, negocio.NegocioID, producto.ProductoID);
			return View(model);
		}

		// POST: Citas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Create(CitasViewModel cvm)
		{
			ModelState.Remove("CodigoComprobacion");
			if (ModelState.IsValid)
			{
				Citas cita = new Citas()
				{
					Notas = cvm.Notas,
					CodigoComprobacion = Utils.Utils.GenerarToken(),
					UsuarioID = User.GetUserID().ToInt(),
					ProductoID = cvm.ProductoID,
					NegocioID = cvm.NegocioID,
					FechaInicio = cvm.FechaInicio
				};
				await _Repo.Citas.SaveAsync(cita);
				return RedirectToAction("Details", "Citas", new { id = cita.CitaID });
			}
			return View(cvm);
		}

		// GET: Citas/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var citas = await _Repo.Citas.FindAsync(id);
			if (citas == null)
			{
				return NotFound();
			}
			return View(citas);
		}

		// POST: Citas/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Edit(int id, Citas citas)
		{
			if (id != citas.CitaID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _Repo.Citas.ModifiedAsync(citas);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CitasExists(citas.CitaID))
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
			return View(citas);
		}

		// GET: Citas/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var citas = await _Repo.Citas.FindAsync(id);
			if (citas == null)
			{
				return NotFound();
			}

			return View(citas);
		}

		// POST: Citas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _Repo.Citas.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		private bool CitasExists(int id)
		{
			return _Repo.Citas.Exists(id);
		}


	}
}
