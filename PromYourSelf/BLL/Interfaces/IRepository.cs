using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRepository<T> where T : class
    {
        Task<bool> SaveAsync(T entity);
        Task<bool> ModifiedAsync(T entity);
        Task<bool> DeleteAsync(int? id);
        Task<T> SearchAsync(int? id);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression,bool GetNullFields = false);
        bool Exists(int id);
    }
}
