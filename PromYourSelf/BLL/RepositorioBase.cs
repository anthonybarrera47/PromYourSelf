using Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using PromYourSelf.Utils;
using PromYourSelf.ViewModels;

namespace BLL
{
	public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
	{
		private readonly Contexto db;
		public ClaimsPrincipal User { get; }

		public RepositorioBase(Contexto contexto, IHttpContextAccessor accessor)
		{
			db = contexto;
			User = accessor.HttpContext.User;
		}

		public RepositorioBase(Contexto contexto)
		{
			db = contexto;
		}

		~RepositorioBase()
		{

		}
		public virtual async Task<T> FindAsync(int? id)
		{
			T entity;
			try
			{
				entity = await db.Set<T>().FindAsync(id);
				if (entity != null)
				{
					if (entity.GetType().BaseType == typeof(CamposEstandar))
					{
						if ((entity as CamposEstandar).EsNulo)
							entity = null;
					}
				}
			}
			catch (Exception)
			{ throw; }
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

				if (entity.GetType().BaseType == typeof(CamposEstandar))
					(entity as CamposEstandar).EsNulo = true;

				paso = await db.SaveChangesAsync() > 0;
			}
			catch (Exception)
			{ throw; }
			return paso;
		}
		public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, bool GetNullFields = false)
		{
			List<T> Lista = new List<T>();
			try
			{
				Lista = await db.Set<T>().Where(expression).ToListAsync() ?? new List<T>();

				if (GetNullFields == false)
				{
					if (typeof(T).BaseType == typeof(CamposEstandar))
						Lista.RemoveAll(x => (x as CamposEstandar).EsNulo == true);

				}
			}
			catch (Exception)
			{ throw; }
			return Lista;
		}
		public virtual async Task<bool> SaveAsync(T entity)
		{
			bool paso = false;
			try
			{
				if (entity.GetType().BaseType == typeof(CamposEstandar))
				{
					(entity as CamposEstandar).EsNulo = false;
					(entity as CamposEstandar).CreadoPor = User.GetUserID().ToInt();
					(entity as CamposEstandar).ModificadoPor = User.GetUserID().ToInt();
					(entity as CamposEstandar).FechaCreacion = DateTime.Now;
					(entity as CamposEstandar).FechaModificacion = DateTime.Now;
				}
				if (entity.GetType() == typeof(Usuarios))
				{
					(entity as Usuarios).EsNulo = false;
					(entity as Usuarios).CreadoPor = User.GetUserID().ToInt();
					(entity as Usuarios).ModificadoPor = User.GetUserID().ToInt();
					(entity as CamposEstandar).FechaCreacion = DateTime.Now;
					(entity as CamposEstandar).FechaModificacion = DateTime.Now;
				}
				if (db.Set<T>().AddAsync(entity) != null)
					paso = await db.SaveChangesAsync() > 0;

			}
			catch (Exception)
			{ throw; }
			return paso;
		}

		public virtual async Task<bool> ModifiedAsync(T entity)
		{
			bool paso = false;
			try
			{				
				if (entity.GetType().BaseType == typeof(CamposEstandar))
				{
					(entity as CamposEstandar).FechaModificacion = DateTime.Now;
					(entity as CamposEstandar).ModificadoPor = User.GetUserID().ToInt();
				}					

				if (entity.GetType() == typeof(Usuarios))
					(entity as Usuarios).ModificadoPor = User.GetUserID().ToInt();

				db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				paso = (await db.SaveChangesAsync() > 0);
			}
			catch (Exception)
			{ throw; }
			return paso;
		}

		public bool Exists(int id)
		{
			return db.FindAsync<T>(id) != null;
		}

		public Task<List<Generico>> GetGenericList()
		{
			throw new NotImplementedException();
		}

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
			T entity;
			try
			{
				entity = await db.Set<T>().Where(expression).FirstOrDefaultAsync();
				if (entity != null)
				{
					if (entity.GetType().BaseType == typeof(CamposEstandar))
					{
						if ((entity as CamposEstandar).EsNulo)
							entity = null;
					}
				}
			}
			catch (Exception)
			{ throw; }
			return entity;
		}
    }
}
