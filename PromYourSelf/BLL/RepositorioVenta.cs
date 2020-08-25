using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Utils;
using PromYourSelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
	public class RepositorioVenta : RepositorioBase<Ventas>, IRepositoryVentas
	{
		private readonly Contexto _context;
		public RepositorioVenta(Contexto context, IHttpContextAccessor accessor) : base(context, accessor)
		{
			_context = context;
		}

		public async Task<List<VentasIndexViewModel>> GetListAsync(Expression<Func<Ventas, bool>> expression)
		{
			List<Ventas> ListaVentas = await _context.Ventas.Where(expression).AsNoTracking().ToListAsync();
			//join users in _context.Usuarios on items.UsuarioClienteID equals users.Id
			var Lista = (from items in ListaVentas
						 select new VentasIndexViewModel
						 {
							 VentaID = items.VentaID,
							 UsuarioClienteID = items.UsuarioClienteID,
							 NegocioID = items.NegocioID,
							 Fecha = items.Fecha,
							 Monto = items.Monto,
							 CitaID = items.CitaID,
							 FechaCreacion = items.FechaCreacion,
							 FechaModificacion = items.FechaModificacion,
							 CreadoPor = items.CreadoPor,
							 ModificadoPor = items.ModificadoPor,
							 Details = items.Details
						 }
							   ).ToList();
			return Lista;
		}

		public override async Task<Ventas> FindAsync(int? id)
		{
			Ventas entity;
			try
			{
				entity = await _context.Ventas.Where(x => x.VentaID == id).Include(i => i.Details).FirstOrDefaultAsync();
				entity.Details = (from item in entity.Details
				 select new VentasDetalle
				 {
					Cantidad = item.Cantidad,
					Precio = item.Precio,
					Producto = _context.Productos.Find(item.ProductoID),
					ProductoID = item.ProductoID,
					ID = item.ID					
				 }
							  ).ToList();
				//entity = await _context.Ventas
				//.Include(i => i.Details.Select(s => s.Producto))				
				//.FirstOrDefaultAsync(x => x.VentaID == id);
				//			entity = await _context.Ventas
				//.Include(b => b.Details)
				//	.ThenInclude(p => p.Producto)
				//.FirstOrDefaultAsync();
				if (entity != null)
				{
					if (entity.GetType().BaseType == typeof(CamposEstandar))
					{
						if ((entity as CamposEstandar).EsNulo)
							entity = null;
					}
				}
			}
			catch (Exception)
			{ throw; }
			return entity;
		}
	}
}
