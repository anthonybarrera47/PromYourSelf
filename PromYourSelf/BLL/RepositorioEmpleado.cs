using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal;
using Microsoft.Extensions.Options;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.Models.ControlUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioEmpleado : RepositorioBase<Empleados>,IRepositoryEmpleados
    {
        private readonly Contexto _context;
        private readonly UserManager<Usuarios> _userManager;
        private readonly IOptions<ErrorMsg> _errorMsg;
        public RepositorioEmpleado(Contexto context,
            UserManager<Usuarios> userManager,
            IOptions<ErrorMsg> errorMsg, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
            _userManager = userManager;
            _errorMsg = errorMsg;
        }
    }
}
