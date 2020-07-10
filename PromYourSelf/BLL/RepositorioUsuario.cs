using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models.ControlUsers;
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
    }
}
