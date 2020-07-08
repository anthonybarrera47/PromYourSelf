using BLL;
using Microsoft.AspNetCore.Identity;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioRoles : RepositorioBase<Roles>, IRepositoryRol
    {
        private readonly Contexto _context;
        private readonly RoleManager<Roles> _roleManager;
        public RepositorioRoles(Contexto contexto,
             RoleManager<Roles> roleManager) : base(contexto)
        {
            _context = contexto;
            _roleManager = roleManager;
        }
    }
}
