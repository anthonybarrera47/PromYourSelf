using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.Models;
using PromYourSelf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PromYourSelf.BLL
{
    public class RepositorioProducto : RepositorioBase<Productos>, IRepositoryProductos
    {
        private readonly Contexto _context;
        public RepositorioProducto(Contexto context, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
        }

        public override async Task<Productos> FindAsync(int? id)
        {
            Productos entity;
            try
            {
                entity = await _context.Productos.Where(x => x.ProductoID == id).Include(x => x.Fotos).Include(x => x.Etiquetas).FirstOrDefaultAsync();
                if (entity != null && entity.Etiquetas != null)
                {
                    entity.Etiquetas = (from item in entity.Etiquetas
                                        select new EtiquetasDetails
                                        {
                                            ID = item.ID,
                                            EtiquetaID = item.EtiquetaID,
                                            ProductoID = item.ProductoID,
                                            Etiqueta = _context.Etiquetas.Find(item.EtiquetaID)

                                        }
                                                  ).ToList();
                }


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
        public override async Task<Productos> FindAsync(Expression<Func<Productos, bool>> expression)
        {
            Productos entity;
            try
            {
                entity = await _context.Productos.Where(expression).Include(x => x.Fotos).Include(x => x.Etiquetas).FirstOrDefaultAsync();
                entity.Etiquetas = (from item in entity.Etiquetas
                                    select new EtiquetasDetails
                                    {
                                        ID = item.ID,
                                        EtiquetaID = item.EtiquetaID,
                                        ProductoID = item.ProductoID,
                                        Etiqueta = _context.Etiquetas.Find(item.EtiquetaID)

                                    }
                              ).ToList();

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

        public async Task<Productos> FindAsyncWithoutTracking(int? id)
        {
            Productos entity;
            try
            {
                entity = await _context.Productos.Where(x => x.ProductoID == id).Include(x => x.Etiquetas).Include(x => x.Fotos).AsNoTracking().FirstOrDefaultAsync();
                entity.Etiquetas = (from item in entity.Etiquetas
                                    select new EtiquetasDetails
                                    {
                                        ID = item.ID,
                                        EtiquetaID = item.EtiquetaID,
                                        ProductoID = item.ProductoID,
                                        Etiqueta = _context.Etiquetas.AsNoTracking().FirstOrDefault(x => x.ID == item.EtiquetaID)
                                    }
                              ).ToList();
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

        public override async Task<List<Productos>> GetListAsync(Expression<Func<Productos, bool>> expression, bool GetNullFields = false)
        {
            List<Productos> Lista = new List<Productos>();
            try
            {
                Lista = await _context.Productos.Where(expression).Include(x => x.Etiquetas).Include(x => x.Fotos).ToListAsync();
                foreach (var producto in Lista)
                {
                    producto.Etiquetas = (from item in producto.Etiquetas
                                          select new EtiquetasDetails
                                          {
                                              ID = item.ID,
                                              EtiquetaID = item.EtiquetaID,
                                              ProductoID = item.ProductoID,
                                              Etiqueta = _context.Etiquetas.Find(item.EtiquetaID)

                                          }
                              ).ToList();
                }
                if (GetNullFields == false)
                {
                    if (typeof(Productos).BaseType == typeof(CamposEstandar))
                        Lista.RemoveAll(x => (x as CamposEstandar).EsNulo == true);

                }
            }
            catch (Exception)
            { throw; }
            return Lista;
        }
        public override async Task<bool> ModifiedAsync(Productos entity)
        {
            bool paso = false;
            var Anterior = await FindAsyncWithoutTracking(entity.ProductoID);
            try
            {
                if (entity.GetType().BaseType == typeof(CamposEstandar))
                {
                    (entity as CamposEstandar).FechaModificacion = DateTime.Now;
                    (entity as CamposEstandar).ModificadoPor = User.GetUserID().ToInt();
                }

                foreach (var item in Anterior.Etiquetas)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                foreach (var item in entity.Etiquetas)
                {
                    item.ID = 0;
                    _context.Entry(item).State = EntityState.Added;
                }
                foreach (var item in Anterior.Fotos)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                foreach (var item in entity.Fotos)
                {
                    item.FotoID = 0;
                    _context.Entry(item).State = EntityState.Added;
                }
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = (await _context.SaveChangesAsync() > 0);
            }
            catch (Exception)
            { throw; }
            return paso;
        }
    }
}
