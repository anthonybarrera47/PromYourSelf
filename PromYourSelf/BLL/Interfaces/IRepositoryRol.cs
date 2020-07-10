using BLL;
using PromYourSelf.Models;
using PromYourSelf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL.Interfaces
{
    public interface IRepositoryRol : IRepository<Roles>
    {
        Task<ErrorResponse> CrearRolAsync(Roles rol);
        bool RolExiste(int Id);
        bool RolExiste(string nombreRol);
    }
}
