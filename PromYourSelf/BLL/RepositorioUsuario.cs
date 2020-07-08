using BLL;
using Microsoft.AspNetCore.Identity;
using Models;
using PromYourSelf.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioUsuario : RepositorioBase<Usuarios>, IRepositoryUsuarios
    {
        private readonly Contexto _context;
        private readonly UserManager<Usuarios> _userManager;
        public RepositorioUsuario(Contexto context, UserManager<Usuarios> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}
