using BLL;
using Models;
using PromYourSelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PromYourSelf.BLL.Interfaces
{
    public interface IRepositoryVentas : IRepository<Ventas>
    {
        Task<List<VentasIndexViewModel>> GetListAsync(Expression<Func<Ventas,bool>> expression);
    }
}
