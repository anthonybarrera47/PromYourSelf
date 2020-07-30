using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models.ControlUsers;
using PromYourSelf.ViewModels;
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
        private readonly IOptions<ErrorMsg> _errorMsg;
        private readonly ILogger _logger;
        public RepositorioUsuario(Contexto context, UserManager<Usuarios> userManager,
            IOptions<ErrorMsg> errorMsg,
            ILogger logger, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
            _userManager = userManager;
            _errorMsg = errorMsg;
            _logger = logger;
        }

        public static Usuarios UserViewModelToUser(RegisterViewModel viewModel)
        {
            Usuarios usuarios = new Usuarios();

            usuarios.Nombres = viewModel.Name;
            usuarios.Apellidos = viewModel.LastName;
            usuarios.Password = viewModel.Password;
            usuarios.Email = viewModel.Email;
            usuarios.UserName = viewModel.Email;
            return usuarios;
        }

        public Task<Usuarios> GetUserInfoByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }
        public async Task<string> GetUserNmaeById(int Id)
        {
            var Usuario = await _context.Usuarios.FindAsync(Id);
            return Usuario.Nombres;
        }
    }
}
