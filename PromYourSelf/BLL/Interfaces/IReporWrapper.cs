﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL.Interfaces
{
    public interface IRepoWrapper
    {
        IRepositoryCitas Citas { get; }
        IRepositoryHorarios Horarios { get; }
        IRepositoryMensajes Mensajes { get; }
        IRepositoryNegocios Negocios { get;  }
        IRepositoryProductos Productos { get; }
		IRepositoryEtiquetas Etiquetas { get; }
		IRepositoryUsuarios Usuarios { get; }
        IRepositoryVentas Ventas { get; }
        IRepositoryRol Rol { get; }
        IRepositoryCodeValidation CodeValidation { get; }
        IRepositoryPagos Pagos{ get; }
        IRepositoryTipoClasificacion TiposClasificacion{ get; }

    }
}

