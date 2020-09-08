using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioHorario : RepositorioBase<Horarios>, IRepositoryHorarios
    {
        private readonly Contexto _context;
        public RepositorioHorario(Contexto context, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
        }
        public async Task<Horarios> FindAsyncByNegocio(int? id)
        {
            Horarios entity;
            try
            {
                entity = await _context.Horarios.FirstOrDefaultAsync(x => x.NegociosId == id) ?? new Horarios();

            }
            catch (Exception)
            { throw; }
            return entity;
        }
    }
}
