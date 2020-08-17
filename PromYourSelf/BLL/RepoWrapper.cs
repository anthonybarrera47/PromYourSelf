using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
    public class RepoWrapper : IRepoWrapper
    {
        private readonly Contexto _RepoContexto;
        private readonly RoleManager<Roles> _rolManager;
        private readonly UserManager<Usuarios> _userManager;
        private readonly IOptions<ErrorMsg> _errorMsg;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _accessor;
        private IRepositoryCitas _Citas;
        private IRepositoryHorarios _Horarios;
        private IRepositoryMensajes _Mensajes;
        private IRepositoryNegocios _Negocios;
        private IRepositoryProductos _Productos;
        private IRepositoryUsuarios _Usuarios;
        private IRepositoryVentas _Ventas;
        private IRepositoryRol _rol;
        private IRepositoryCodeValidation _CodeValidation;
        private IRepositoryPagos _RepositoryPagos;
        private IRepositoryTipoClasificacion _RepositoryTipoClasificacion;

        public RepoWrapper(Contexto contexto, UserManager<Usuarios> userManager, 
                RoleManager<Roles> rolManager,
                IOptions<ErrorMsg> errorMsg,
                ILogger<RepoWrapper> logger,
                IHttpContextAccessor accessor)
        {
            _RepoContexto = contexto;
            _userManager = userManager;
            _rolManager = rolManager;
            _errorMsg = errorMsg;
            _userManager = userManager;
            _logger = logger;
            _accessor = accessor;
        }
        public IRepositoryCitas Citas
        {
            get
            {
                if (_Citas == null)
                {
                    _Citas = new RepositorioCitas(_RepoContexto, _accessor);
                }

                return _Citas;
            }
        }


        public IRepositoryHorarios Horarios
        {
            get
            {
                if (_Horarios == null)
                {
                    _Horarios = new RepositorioHorario(_RepoContexto, _accessor);
                }

                return _Horarios;
            }
        }

        public IRepositoryMensajes Mensajes
        {
            get
            {
                if (_Mensajes == null)
                {
                    _Mensajes = new RepositorioMensaje(_RepoContexto, _accessor);
                }

                return _Mensajes;
            }
        }

        public IRepositoryNegocios Negocios
        {
            get
            {
                if (_Negocios == null)
                {
                    _Negocios = new RepositorioNegocio(_RepoContexto, _accessor);
                }

                return _Negocios;
            }
        }

        public IRepositoryProductos Productos
        {
            get
            {
                if (_Productos == null)
                {
                    _Productos = new RepositorioProducto(_RepoContexto, _accessor);
                }

                return _Productos;
            }
        }
        public IRepositoryUsuarios Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new RepositorioUsuario(_RepoContexto, _userManager, _errorMsg, _logger, _accessor);
                }

                return _Usuarios;
            }
        }

        public IRepositoryVentas Ventas
        {
            get
            {
                if (_Ventas == null)
                {
                    _Ventas = new RepositorioVenta(_RepoContexto, _accessor);
                }

                return _Ventas;
            }
        }
        public IRepositoryRol Rol
        {
            get
            {
                if (_rol == null)
                {
                    _rol = new RepositorioRoles(_RepoContexto, _rolManager, _errorMsg, _accessor);
                }

                return _rol;
            }
        }

        public IRepositoryCodeValidation CodeValidation
        {
            get
            {
                if (_CodeValidation == null)
                {
                    _CodeValidation = new RepositorioCodeValidation(_RepoContexto, _accessor);
                }

                return _CodeValidation;
            }
        }
        public IRepositoryPagos Pagos
        {
            get
            {
                if (_RepositoryPagos == null)
                {
                    _RepositoryPagos = new RepositorioPagos(_RepoContexto, _accessor);
                }

                return _RepositoryPagos;
            }
        }
        public IRepositoryTipoClasificacion TiposClasficacion
        {
            get
            {
                if (_RepositoryTipoClasificacion == null)
                {
                    _RepositoryTipoClasificacion = new RepositorioTipoClasificacion(_RepoContexto, _accessor);
                }

                return _RepositoryTipoClasificacion;
            }
        }
    }
}
