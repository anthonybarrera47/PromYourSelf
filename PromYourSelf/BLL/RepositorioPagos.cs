using BLL;
using Microsoft.AspNetCore.Http;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioPagos : RepositorioBase<Pagos>, IRepositoryPagos
    {
        private readonly Contexto _context;
        public RepositorioPagos(Contexto context, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
        }
    }
}

