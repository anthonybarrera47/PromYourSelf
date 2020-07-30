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

            var Lista = (from items in ListaVentas
                               join users in _context.Usuarios on items.UsuarioClienteID equals users.Id
                               select new VentasIndexViewModel
                               {
                                   VentaID = items.VentaID,
                                   UsuarioClienteID = items.UsuarioClienteID,
                                   NegocioID = items.NegocioID,
                                   Nombres = users.Nombres,
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
    }
}
