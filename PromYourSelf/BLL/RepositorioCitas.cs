using BLL;
using Models;
using PromYourSelf.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioCitas : RepositorioBase<Citas>,IRepositoryCitas
    {
        private readonly Contexto _context;
        public RepositorioCitas(Contexto context) : base(context)
        {
            _context = context;
        }
    }
}
