using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.Models.ControlUsers;
using PromYourSelf.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioRoles : RepositorioBase<Roles>, IRepositoryRol
    {
        private readonly Contexto _context;
        private readonly RoleManager<Roles> _roleManager;
        private readonly IOptions<ErrorMsg> _errorMsg;
        public RepositorioRoles(Contexto contexto,
             RoleManager<Roles> roleManager,
             IOptions<ErrorMsg> errorMsg, IHttpContextAccessor accessor) : base(contexto, accessor)
        {
            _context = contexto;
            _roleManager = roleManager;
            _errorMsg = errorMsg;
        }

        public async Task<ErrorResponse> CrearRolAsync(Roles rol)
        {
            ErrorResponse result = new ErrorResponse();
            try
            {
                if (RolExiste(rol.Name)) //valida que el rol no existe por el nombre
                {
                    result.OK = false;
                    result.AddDescripcion(_errorMsg.Value.ROL_EXISTE); //mensaje personalizado.
                    return result;
                }
               
                IdentityResult r = await _roleManager.CreateAsync(rol); //utiliza el api de IdentitydbContext roleManager.
                if (!r.Succeeded)
                {
                    result.OK = false;
                    foreach (IdentityError error in r.Errors)
                    {
                        result.AddDescripcion(error.Description); // este error lo devuelve el rolManager en ingles
                    }
                }
                else
                {
                    result.OK = true;
                }

            }
            catch (Exception ex)
            {
                result.AddDescripcion(ex.Message);
                result.OK = false;
            }
            return result;
        }

        public bool RolExiste(int Id)
        {
            return _context.Roles.Any(e => e.Id == Id);
        }

        public bool RolExiste(string nombreRol)
        {
            return _context.Roles.Any(x => x.Name.Contains(nombreRol));
        }
    }
}
