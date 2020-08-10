using PromYourSelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRepository<T> where T : class
    {
        Task<bool> SaveAsync(T entity);
        Task<bool> ModifiedAsync(T entity);
        Task<bool> DeleteAsync(int? id);
        Task<T> FindAsync(int? id);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression,bool GetNullFields = false);
        bool Exists(int id);
        ClaimsPrincipal User { get; }
        Task<List<Generico>> GetGenericList();
    }
}
