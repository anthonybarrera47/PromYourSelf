using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PromYourSelf.Models;

namespace Models
{
    public class Contexto : IdentityDbContext<
        Usuarios, Roles, int,
        IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Citas> Citas { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Etiquetas> Etiquetas { get; set; }
        public DbSet<FotosProductos> FotosProductos { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Mensajes> Mensaje { get; set; }
        public DbSet<Negocios> Negocios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }


        public Contexto(DbContextOptions<Contexto> options)
    : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Negocios>().HasData(
              new Negocios()
              {
                  NegocioID = 1,
                  NombreComercial = "JuanDupreCompany",
                  Direccion = "En todas partes , es omnipresente",
                  Telefono1 = "829-123-4567",
                  Telefono2 = "809-123-4567",
                  Latitud = "1000",
                  CiudadID = 1,
                  Longitud = "2000",
                  CreadoPor = 1,
                  FechaCreacion = DateTime.Now,
                  ModificadoPor = 1,
                  FechaModificacion = DateTime.Now
              }

              );

           
        }


        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var item in entries)
            {
                if (item.Entity is CamposEstandar camposEstandar)
                {
                    var now = DateTime.Now;

                    switch (item.State)
                    {
                        case EntityState.Modified:
                            camposEstandar.ModificadoPor = camposEstandar.UsuarioID;
                            camposEstandar.FechaModificacion = now;
                            break;
                        case EntityState.Added:
                            camposEstandar.CreadoPor = camposEstandar.UsuarioID;
                            camposEstandar.FechaCreacion = now;
                            camposEstandar.ModificadoPor = camposEstandar.UsuarioID;
                            camposEstandar.FechaModificacion = now;
                            break;
                    }
                }
            }
        }
        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
//https://entityframeworkcore.com/knowledge-base/50862525/seed-entity-with-owned-property