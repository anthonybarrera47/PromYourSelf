using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioProducto : RepositorioBase<Productos>, IRepositoryProductos
    {
        private readonly Contexto _context;
        public RepositorioProducto(Contexto context, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
        }

		public override async Task<Productos> FindAsync(int? id)
		{
			Productos entity;
			try
			{
				entity = await _context.Productos.Where(x => x.ProductoID == id).Include(x => x.Etiquetas).Include(x => x.Fotos).FirstOrDefaultAsync();
				entity.Etiquetas = (from item in entity.Etiquetas
								  select new EtiquetasDetails
								  {
									  ID = item.ID,
									  EtiquetaID = item.EtiquetaID,
									  ProductoID = item.ProductoID,
									  Etiqueta = _context.Etiquetas.Find(item.EtiquetaID)

								  }
							  ).ToList();			
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
