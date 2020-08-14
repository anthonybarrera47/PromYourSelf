using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PromYourSelf.Models;
using PromYourSelf.Models.ControlUsers;
using PromYourSelf.Utils;
using PromYourSelf.BLL;

namespace Models
{
    public class Contexto : IdentityDbContext<
        Usuarios, Roles, int,
        UserClaim, UserRole, IdentityUserLogin<int>,
        RoleClaim, IdentityUserToken<int>>
    {
        public DbSet<Citas> Citas { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Etiquetas> Etiquetas { get; set; }
        public DbSet<FotosProductos> FotosProductos { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Mensajes> Mensaje { get; set; }
        public DbSet<Negocios> Negocios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<CodeValidation> CodeValidation { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<PasswordGenerator> PasswordGenerators { get; set; }

        public Contexto()
        { }

        public Contexto(DbContextOptions<Contexto> options)
    : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>().HasData(
             new Usuarios()
             {
                 Id = 1,
                 Nombres = "Luis Felipe",
                 NormalizedEmail = "ApasLabs@gmail.com".ToUpper(),
                 NormalizedUserName = "ApasLabs".ToUpper(),
                 Apellidos = " Muños Florez",
                 Email = "ApasLabs@gmail.com",
                 Posicion = Posicion.Administrador.GetDescription(),
                 Password = RepositorioUsuario.SHA1("1234"),
                 Confirmado = true,
                 ConcurrencyStamp = DateTime.Now.ToString(),
                 UserName = "ApasLabs"
             },
             new Usuarios()
             {
                 Id = 2,
                 NormalizedEmail = "williamelnene@gmail.com".ToUpper(),
                 NormalizedUserName = "williambh98".ToUpper(),
                 Nombres = "William",
                 Apellidos = "Burgos Hernandez",
                 Email = "williamelnene@gmail.com",
                 Posicion = Posicion.Administrador.GetDescription(),
                 Password = RepositorioUsuario.SHA1("1234"),
                 Confirmado = true,
                 ConcurrencyStamp = DateTime.Now.ToString(),
                 UserName = "williambh98"
             },
              new Usuarios()
              {
                  Id = 3,
                  NormalizedEmail = "usuarionoimai@gmail.com".ToUpper(),
                  NormalizedUserName = "usuario".ToUpper(),
                  Nombres = "Usuario",
                  Apellidos = "Normal",
                  Email = "usuarionoimai@gmail.com",
                  Posicion = Posicion.Normal.GetDescription(),
                  Password = RepositorioUsuario.SHA1("1234"),
                  Confirmado = true,
                  ConcurrencyStamp = DateTime.Now.ToString(),
                  UserName = "usuario"
              }
             );

            //2547 ES EL ID DE SFM
            modelBuilder.Entity<Negocios>().HasData(
               new Negocios()
               {
                   NegocioID = 1,
                   NombreComercial = "JuanDupreCompany",
                   Direccion = "En todas partes , es omnipresente",
                   Telefono1 = "829-123-4567",
                   Telefono2 = "809-123-4567",
                   Latitud = "1000",
                   UsuarioID = 4,
                   CiudadID = 2547,
                   Longitud = "2000",
                   CreadoPor = 4,
                   FechaCreacion = DateTime.Now,
                   ModificadoPor = 4,
                   FechaModificacion = DateTime.Now
               }
               ,
               new Negocios()
               {
                   NegocioID = 2,
                   NombreComercial = "APAS LABS",
                   Direccion = "Cenovi, SFM",
                   Telefono1 = "809-754-0319",
                   Telefono2 = "",
                   Latitud = "1000",
                   CiudadID = 2547,
                   Longitud = "2000",
                   CreadoPor = 1,
                   FechaCreacion = DateTime.Now,
                   ModificadoPor = 1,
                   FechaModificacion = DateTime.Now,
                   UsuarioID = 1
               },
                new Negocios()
                {
                    NegocioID = 3,
                    NombreComercial = "BHTech",
                    Direccion = "Centro de la cuidad, SFM",
                    Telefono1 = "829-935-9510",
                    Telefono2 = "809-123-4567",
                    Latitud = "1000",
                    CiudadID = 2547,
                    Longitud = "2000",
                    CreadoPor = 3,
                    FechaCreacion = DateTime.Now,
                    ModificadoPor = 3,
                    FechaModificacion = DateTime.Now,
                    UsuarioID = 3
                }
               );
            modelBuilder.Entity<Productos>().HasData(
             new Productos()
             {
                 ProductoID = 1,
                 Nombre = "App Prestamo",
                 Descripcion = "PrestFast Lite",
                 Unidad = 1,
                 Precio = 10,
                 TipoProductos = TipoProducto.Producto,
                 NegocioID = 2,
                 CreadoPor = 3,
                 FechaCreacion = DateTime.Now,
                 ModificadoPor = 3,
                 FechaModificacion = DateTime.Now
             }
             ,
             new Productos()
             {
                 ProductoID = 2,
                 Nombre = "Consultor Informatico",
                 Descripcion = "Consultoria Informatica",
                 Unidad = 1,
                 Precio = 1000,
                 TipoProductos = TipoProducto.Servicio,
                 NegocioID = 2,
                 CreadoPor = 3,
                 FechaCreacion = DateTime.Now,
                 ModificadoPor = 3,
                 FechaModificacion = DateTime.Now
             }
             ,
             new Productos()
             {
                 ProductoID = 3,
                 Nombre = "Laptop",
                 Descripcion = "ASUS Q503",
                 Unidad = 1,
                 Precio = 15000,
                 TipoProductos = TipoProducto.Producto,
                 NegocioID = 3,
                 CreadoPor = 4,
                 FechaCreacion = DateTime.Now,
                 ModificadoPor = 4,
                 FechaModificacion = DateTime.Now
             },
             new Productos()
             {
                 ProductoID = 4,
                 Nombre = "Reparación",
                 Descripcion = "Reparación y Mantenimiento",
                 Unidad = 1,
                 Precio = 15000,
                 TipoProductos = TipoProducto.Servicio,
                 NegocioID = 3,
                 CreadoPor = 4,
                 FechaCreacion = DateTime.Now,
                 ModificadoPor = 4,
                 FechaModificacion = DateTime.Now
             }
              ,
             new Productos()
             {
                 ProductoID = 5,
                 Nombre = "Brugal Dupre",
                 Descripcion = "Brugal Dupre 200mg",
                 Unidad = 1,
                 Precio = 15000,
                 TipoProductos = TipoProducto.Producto,
                 NegocioID = 3,
                 CreadoPor = 4,
                 FechaCreacion = DateTime.Now,
                 ModificadoPor = 4,
                 FechaModificacion = DateTime.Now
             },
             new Productos()
             {
                 ProductoID = 6,
                 Nombre = "Catador de vinos",
                 Descripcion = "Catar Vinos",
                 Unidad = 1,
                 Precio = 15000,
                 TipoProductos = TipoProducto.Servicio,
                 NegocioID = 3,
                 CreadoPor = 4,
                 FechaCreacion = DateTime.Now,
                 ModificadoPor = 4,
                 FechaModificacion = DateTime.Now
             }
                 );

            //Application User
            modelBuilder.Entity<Usuarios>(entity =>
            {
                //entity.Property(e => e.Id).HasColumnName("Id");

                entity.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict); //Esto se debe hacer para evitar que sql server diga que hay referencias ondelete cíclicas.
                                                    //.IsRequired();
            });


            //---
            //Application Roles
            //--------------------------------
            modelBuilder.Entity<Roles>(entity =>
            {
                // entity.HasIndex(x => x.NormalizedName).HasName("RoleNameIndex").IsUnique(false); //permite que existan nombres duplicados
                entity.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
            //---
        }


        private void OnBeforeSaving()
        {
            //var entries = ChangeTracker.Entries();
            //foreach (var item in entries)
            //{
            //    if (item.Entity is CamposEstandar camposEstandar)
            //    {
            //        var now = DateTime.Now;

            //        switch (item.State)
            //        {
            //            case EntityState.Modified:
            //                camposEstandar.ModificadoPor = camposEstandar.UsuarioID;
            //                camposEstandar.FechaModificacion = now;
            //                break;
            //            case EntityState.Added:
            //                camposEstandar.CreadoPor = camposEstandar.UsuarioID;
            //                camposEstandar.FechaCreacion = now;
            //                camposEstandar.ModificadoPor = camposEstandar.UsuarioID;
            //                camposEstandar.FechaModificacion = now;
            //                break;
            //        }
            //    }
            //}
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
        public DbSet<PromYourSelf.ViewModels.ProfileViewModel> ProfileViewModel { get; set; }
    }
}
//https://entityframeworkcore.com/knowledge-base/50862525/seed-entity-with-owned-property