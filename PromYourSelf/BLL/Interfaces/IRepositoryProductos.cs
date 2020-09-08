using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.BLL.Interfaces
{
    public interface IRepositoryProductos : IRepository<Productos>
    {
        Task<Productos> FindAsyncWithoutTracking(int? id);
    }
}
