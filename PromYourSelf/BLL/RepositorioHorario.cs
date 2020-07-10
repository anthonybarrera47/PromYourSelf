using BLL;
using Microsoft.AspNetCore.Http;
using Models;
using PromYourSelf.BLL.Interfaces;
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
    }
}
