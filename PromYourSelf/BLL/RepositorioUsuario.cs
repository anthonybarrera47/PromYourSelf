﻿using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models.ControlUsers;
using PromYourSelf.Utils;
using PromYourSelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

        public async Task RemoveClaimsUser(SignInManager<Usuarios> signInManager, UserManager<Usuarios> userManager, Usuarios usuarios)
        {
            var Claims = await _userManager.GetClaimsAsync(usuarios);
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Nombres.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Foto.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Empresa.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Posicion.ToString("G"))));
            await signInManager.RefreshSignInAsync(usuarios);
        }

        public async Task UpdateClaimsUser(SignInManager<Usuarios> signInManager, UserManager<Usuarios> userManager, Usuarios usuarios)
        {
            var Claims = await _userManager.GetClaimsAsync(usuarios);

            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Nombres.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Foto.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Empresa.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Posicion.ToString("G"))));

            ///agrega los claims nuevamente
            await userManager.AddClaimAsync(usuarios, new Claim(TypeClaims.Nombres.ToString("G"), $"{usuarios.Nombres} {usuarios.Apellidos}"));
            await userManager.AddClaimAsync(usuarios, new Claim(TypeClaims.Posicion.ToString("G"), $"{Posicion.Administrador.GetDescription()}"));

            if (usuarios.Foto != null && usuarios.Foto != string.Empty && usuarios.Foto.Length > 0)
                await userManager.AddClaimAsync(usuarios, new Claim("Foto", usuarios.Foto));

            await signInManager.RefreshSignInAsync(usuarios);
        }
        public static string SHA1(object password)
        {
            using (System.Security.Cryptography.SHA1Managed SHa1 = new System.Security.Cryptography.SHA1Managed())
            {
                var hash = SHa1.ComputeHash(Encoding.UTF8.GetBytes(password.ToString()));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte item in hash)
                {
                    sb.Append(item.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
