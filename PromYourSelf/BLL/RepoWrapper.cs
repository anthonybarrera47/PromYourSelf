using Models;
using PromYourSelf.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepoWrapper : IRepoWrapper
    {
        private readonly Contexto _RepoWrapper;
        private IRepositoryCitas _Citas;
        private IRepositoryEmpleados _Empleados;
        private IRepositoryHorarios _Horarios;
        private IRepositoryMensajes _Mensajes;
        private IRepositoryNegocios _Negocios;
        private IRepositoryProductos _Productos;
        private IRepositoryUsuarios _Usuarios;
        private IRepositoryVentas _Ventas;

        public RepoWrapper(Contexto contexto)
        {
            _RepoWrapper = contexto;
        }
        public IRepositoryCitas Citas
        {
            get
            {
                if (_Citas == null)
                {
                    _Citas = new RepositorioCitas(_RepoWrapper);
                }

                return _Citas;
            }
        }

        public IRepositoryEmpleados Empleados
        {
            get
            {
                if (_Empleados == null)
                {
                    _Empleados = new RepositorioEmpleado(_RepoWrapper);
                }

                return _Empleados;
            }
        }

        public IRepositoryHorarios Horarios
        {
            get
            {
                if (_Horarios == null)
                {
                    _Horarios = new RepositorioHorario(_RepoWrapper);
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
                    _Mensajes = new RepositorioMensaje(_RepoWrapper);
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
                    _Negocios = new RepositorioNegocio(_RepoWrapper);
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
                    _Productos = new RepositorioProducto(_RepoWrapper);
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
                    _Usuarios = new RepositorioUsuario(_RepoWrapper);
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
                    _Ventas = new RepositorioVenta(_RepoWrapper);
                }

                return _Ventas;
            }
        }

    }
}
