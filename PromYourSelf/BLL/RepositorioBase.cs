using Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly Contexto db;
        public RepositorioBase(Contexto contexto)
        {
            db = contexto;
        }
        ~RepositorioBase()
        {

        }
        public virtual async Task<T> SearchAsync(int? id)
        {
            T entity;
            try
            {
                entity = await db.Set<T>().FindAsync(id);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return entity;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public virtual async Task<bool> DeleteAsync(int? id)
        {
            bool paso = false;
            try
            {
                T entity = await db.Set<T>().FindAsync(id); 

                db.Set<T>().Remove(entity);
                paso = await db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = await db.Set<T>().Where(expression).ToListAsync() ?? new List<T>();
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return Lista;
        }
        public virtual async Task<bool> SaveAsync(T entity)
        {
            bool paso = false;
            try
            {
                if (db.Set<T>().AddAsync(entity) != null)
                    paso = await db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }

        public virtual async Task<bool> ModifiedAsync(T entity)
        {
            bool paso = false;
            try
            {
                db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = (await db.SaveChangesAsync() > 0);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }

        public bool Exists(int id)
        {
            return db.FindAsync<T>(id) !=null;
        }
    }
}
