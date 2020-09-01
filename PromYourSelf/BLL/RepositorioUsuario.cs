using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
using System.Security.Cryptography.X509Certificates;
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
            usuarios.Password = RepositorioUsuario.SHA1(viewModel.Password);
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
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Horarios.ToString("G"))));

            await signInManager.RefreshSignInAsync(usuarios);
        }

        public async Task UpdateClaimsUser(SignInManager<Usuarios> signInManager, UserManager<Usuarios> userManager, Usuarios usuarios)
        {
            var Claims = await _userManager.GetClaimsAsync(usuarios);

            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Nombres.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Foto.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Empresa.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Posicion.ToString("G"))));
            await userManager.RemoveClaimsAsync(usuarios, Claims.Where(x => x.Type.Equals(TypeClaims.Horarios.ToString("G"))));

            var Negocio = await _context.Negocios.Where(x => x.UsuarioID == usuarios.Id).FirstOrDefaultAsync() ?? new Negocios();
            var Horario = await _context.Horarios.Where(x => x.NegociosId == Negocio.NegocioID).FirstOrDefaultAsync() ?? new Horarios();
            ///agrega los claims nuevamente
            await userManager.AddClaimAsync(usuarios, new Claim(TypeClaims.Nombres.ToString("G"), $"{usuarios.Nombres} {usuarios.Apellidos}"));
            await userManager.AddClaimAsync(usuarios, new Claim(TypeClaims.Posicion.ToString("G"), $"{usuarios.Posicion}"));

            if (Negocio.NegocioID > 0)
                await userManager.AddClaimAsync(usuarios, new Claim(TypeClaims.Empresa.ToString("G"), $"{Negocio.NegocioID}"));
            if (Horario.HorarioID > 0)
                await userManager.AddClaimAsync(usuarios, new Claim(TypeClaims.Horarios.ToString("G"), $"{Horario.HorarioID}"));


            if (usuarios.Foto != null && usuarios.Foto != string.Empty && usuarios.Foto.Length > 0)
                await userManager.AddClaimAsync(usuarios, new Claim(TypeClaims.Foto.ToString("G"), usuarios.Foto));

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
