using BLL;
using Models;
using PromYourSelf.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioEmpleado : RepositorioBase<Empleados>,IRepositoryEmpleados
    {
        private readonly Contexto _context;
        public RepositorioEmpleado(Contexto context) : base(context)
        {
            _context = context;
        }
    }
}
