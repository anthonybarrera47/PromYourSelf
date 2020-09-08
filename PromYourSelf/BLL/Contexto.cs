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
        public DbSet<UsuariosMensaje> UsuariosMensajes { get; set; }


        public Contexto()
        { }

        public Contexto(DbContextOptions<Contexto> options)
    : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //2547 ES EL ID DE SFM
            modelBuilder.Entity<Negocios>().HasData(
               new Negocios()
               {
                   NegocioID = 1,
                   NombreComercial = "JuanDupreCompany",
                   Direccion = "Tienda de licores",
                   Telefono1 = "829-123-4567",
                   Telefono2 = "809-123-4567",
                   Latitud = "19.187340530798558",
                   UsuarioID = 1,
                   CiudadID = 2547,
                   Longitud = " -70.22277173397258",
                   CreadoPor = 1,
                   FechaCreacion = DateTime.Now,
                   ModificadoPor = 1,
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
                   Latitud = "19.229372",
                   CiudadID = 2547,
                   Longitud = " -70.360117",
                   CreadoPor = 3,
                   FechaCreacion = DateTime.Now,
                   ModificadoPor = 3,
                   FechaModificacion = DateTime.Now,
                   UsuarioID = 3
               },
                new Negocios()
                {
                    NegocioID = 3,
                    NombreComercial = "BHTech",
                    Direccion = "Centro de la cuidad, SFM",
                    Telefono1 = "829-935-9510",
                    Telefono2 = "809-123-4567",
                    Latitud = "19.30789",
                    CiudadID = 2547,
                    Longitud = "-70.27587",
                    CreadoPor = 4,
                    FechaCreacion = DateTime.Now,
                    ModificadoPor = 4,
                    FechaModificacion = DateTime.Now,
                    UsuarioID = 4
                },
                new Negocios()
                {
                    NegocioID = 4,
                    NombreComercial = "Edward Computadoras",
                    Direccion = "La Cruz, San Francisco de Macorís 31000",
                    Telefono1 = "809-725-3444",
                    Latitud = " 19.296691",
                    CiudadID = 2547,
                    Longitud = "-70.254814",
                    CreadoPor = 8,
                    FechaCreacion = DateTime.Now,
                    ModificadoPor = 8,
                    FechaModificacion = DateTime.Now,
                    UsuarioID = 8
                },
                new Negocios()
                {
                    NegocioID = 5,
                    NombreComercial = "Omega Tech",
                    Direccion = "Calle Frank Grullón, No 60 Local 1, San Francisco de Macorís 31000",
                    Telefono1 = "829-935-9510",
                    Telefono2 = "809-123-4567",
                    Latitud = "19.2907871",
                    CiudadID = 2547,
                    Longitud = "-70.252591",
                    CreadoPor = 9,
                    FechaCreacion = DateTime.Now,
                    ModificadoPor = 9,
                    FechaModificacion = DateTime.Now,
                    UsuarioID = 9
                },
                new Negocios()
                {
                    NegocioID = 6,
                    NombreComercial = "Edificio Herrera Salazar",
                    Direccion = "San Francisco de Macorís 31000",
                    Telefono1 = "+18096754184",
                    Latitud = "19.3047922",
                    CiudadID = 2547,
                    Longitud = "-70.2673545",
                    CreadoPor = 10,
                    FechaCreacion = DateTime.Now,
                    ModificadoPor = 10,
                    FechaModificacion = DateTime.Now,
                    UsuarioID = 10
                }
               );
            Etiquetas etiqueta1 = new Etiquetas()
            {
                ID = 1,
                Nombre = "Computadoras"
            };
            Etiquetas etiqueta2 = new Etiquetas()
            {
                ID = 2,
                Nombre = "Servicios Informáticos"
            };
            Etiquetas etiqueta3 = new Etiquetas()
            {
                ID = 3,
                Nombre = "Asesoria Informática"
            };
            Etiquetas etiqueta4 = new Etiquetas()
            {
                ID = 4,
                Nombre = "Reparaciones"
            };
            Etiquetas etiqueta5 = new Etiquetas()
            {
                ID = 5,
                Nombre = "Cervezas"
            };
            Etiquetas etiqueta6 = new Etiquetas()
            {
                ID = 6,
                Nombre = "Aplicaciones"
            };
            Etiquetas etiqueta7 = new Etiquetas()
            {
                ID = 7,
                Nombre = "Alcohol"
            };
            Etiquetas etiqueta8 = new Etiquetas()
            {
                ID = 8,
                Nombre = "Laptop"
            };
            Etiquetas etiqueta9 = new Etiquetas()
            {
                ID = 9,
                Nombre = "Desarrollo"
            };
            Etiquetas etiqueta10 = new Etiquetas()
            {
                ID = 10,
                Nombre = "Comida"
            };
            modelBuilder.Entity<Etiquetas>().HasData(
                etiqueta1, etiqueta2, etiqueta3, etiqueta4, etiqueta5, etiqueta6
                , etiqueta7, etiqueta8, etiqueta9, etiqueta10);
            Productos productos1 = new Productos()
            {
                ProductoID = 1,
                Nombre = "App Prestamo",
                Descripcion = "PrestFast Lite",
                Unidad = "UND",
                Precio = 10,
                TipoProductos = TipoProducto.Producto,
                NegocioID = 2,
                UsuarioID = 3,
                CreadoPor = 3,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 3,
                FechaModificacion = DateTime.Now
            };
            //productos1.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 1, EtiquetaID = 9 });
            //productos1.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 1, EtiquetaID = 6 });
            Productos productos2 = new Productos()
            {
                ProductoID = 2,
                Nombre = "Consultor Informatico",
                Descripcion = "Consultoria Informatica",
                Unidad = "UND",
                Precio = 1000,
                TipoProductos = TipoProducto.Servicio,
                NegocioID = 2,
                UsuarioID = 3,
                CreadoPor = 3,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 3,
                FechaModificacion = DateTime.Now
            };
            //productos2.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 2, EtiquetaID = 2 });
            //productos2.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 2, EtiquetaID = 3 });

            Productos productos3 = new Productos()
            {
                ProductoID = 3,
                Nombre = "Laptop",
                Descripcion = "ASUS Q503",
                Unidad = "UND",
                Precio = 15000,
                TipoProductos = TipoProducto.Producto,
                NegocioID = 3,
                UsuarioID = 4,
                CreadoPor = 4,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 4,
                FechaModificacion = DateTime.Now
            };
            //productos3.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 3, EtiquetaID = 1 });
            //productos3.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 3, EtiquetaID = 8 });

            Productos productos4 = new Productos()
            {
                ProductoID = 4,
                Nombre = "Reparación",
                Descripcion = "Reparación y Mantenimiento",
                Unidad = "UND",
                Precio = 15000,
                TipoProductos = TipoProducto.Servicio,
                NegocioID = 3,
                UsuarioID = 4,
                CreadoPor = 4,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 4,
                FechaModificacion = DateTime.Now
            };
            //productos4.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 4, EtiquetaID = 1 });
            //productos4.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 4, EtiquetaID = 4 });

            Productos productos5 = new Productos()
            {
                ProductoID = 5,
                Nombre = "Brugal Extraviejo",
                Descripcion = "Brugal Extraviejo 200mg",
                Unidad = "UND",
                Precio = 15000,
                TipoProductos = TipoProducto.Producto,
                NegocioID = 1,
                UsuarioID = 1,
                CreadoPor = 1,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 1,
                FechaModificacion = DateTime.Now
            };
            //productos5.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 5, EtiquetaID = 7 });

            Productos productos6 = new Productos()
            {
                ProductoID = 6,
                Nombre = "Catador de vinos",
                Descripcion = "Catar Vinos",
                Unidad = "UND",
                Precio = 15000,
                TipoProductos = TipoProducto.Servicio,
                NegocioID = 1,
                UsuarioID = 1,
                CreadoPor = 1,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 1,
                FechaModificacion = DateTime.Now
            };
            //productos6.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 6, EtiquetaID = 7 });

            Productos productos7 = new Productos()
            {
                ProductoID = 7,
                Nombre = "Reparación de Computadoras",
                Descripcion = "Reparación de Computadoras",
                Unidad = "UND",
                Precio = 2000,
                TipoProductos = TipoProducto.Servicio,
                NegocioID = 4,
                UsuarioID = 8,
                CreadoPor = 8,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 8,
                FechaModificacion = DateTime.Now
            };
            //productos7.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 7, EtiquetaID = 4 });

            Productos productos8 = new Productos()
            {
                ProductoID = 8,
                Nombre = "Servicio de instalación de camaras",
                Descripcion = "Servicio de instalación de camaras",
                Unidad = "UND",
                Precio = 1000,
                TipoProductos = TipoProducto.Servicio,
                NegocioID = 4,
                UsuarioID = 8,
                CreadoPor = 8,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 8,
                FechaModificacion = DateTime.Now
            };
            //productos8.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 8, EtiquetaID = 4 });

            Productos productos9 = new Productos()
            {
                ProductoID = 9,
                Nombre = "Computadoras",
                Descripcion = "Venta de computadoras",
                Unidad = "UND",
                Precio = 1000,
                TipoProductos = TipoProducto.Producto,
                NegocioID = 5,
                UsuarioID = 9,
                CreadoPor = 9,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 9,
                FechaModificacion = DateTime.Now
            };
            //productos9.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 9, EtiquetaID = 8 });
            //productos9.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 9, EtiquetaID = 1 });

            Productos productos10 = new Productos()
            {
                ProductoID = 10,
                Nombre = "Equipos electrónicos",
                Descripcion = "Todo tipo de equipos electronicos",
                Unidad = "UND",
                Precio = 1000,
                TipoProductos = TipoProducto.Producto,
                NegocioID = 5,
                UsuarioID = 9,
                CreadoPor = 9,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 9,
                FechaModificacion = DateTime.Now
            };
            //productos10.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 10, EtiquetaID = 2 });

            Productos productos11 = new Productos()
            {
                ProductoID = 11,
                Nombre = "Bebidas Alcohólicas",
                Descripcion = "Todo tipo de bebidas alcohólicas",
                Unidad = "UND",
                Precio = 1000,
                TipoProductos = TipoProducto.Producto,
                NegocioID = 6,
                UsuarioID = 10,
                CreadoPor = 10,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 10,
                FechaModificacion = DateTime.Now
            };
            //productos11.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 11, EtiquetaID = 7 });

            Productos productos12 = new Productos()
            {
                ProductoID = 12,
                Nombre = "Comidas",
                Descripcion = "Todo tipo de productos alimenticios",
                Unidad = "UND",
                Precio = 1000,
                TipoProductos = TipoProducto.Producto,
                NegocioID = 6,
                UsuarioID = 10,
                CreadoPor = 10,
                FechaCreacion = DateTime.Now,
                ModificadoPor = 10,
                FechaModificacion = DateTime.Now
            };
            //productos12.Etiquetas.Add(new EtiquetasDetails() { ProductoID = 12, EtiquetaID = 10 });

            modelBuilder.Entity<Productos>().HasData(
             productos1, productos2, productos3, productos4, productos5,productos6,productos7,
             productos8,productos9,productos10,productos11,productos12);

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
            var entries = ChangeTracker.Entries();
            foreach (var item in entries)
            {
                if (item.Entity is CamposEstandar camposEstandar)
                {
                    var now = DateTime.Now;

                    switch (item.State)
                    {
                        case EntityState.Modified:
                            camposEstandar.FechaModificacion = now;
                            break;
                        case EntityState.Added:
                            camposEstandar.FechaCreacion = now;
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
        public DbSet<PromYourSelf.ViewModels.ProfileViewModel> ProfileViewModel { get; set; }
        public DbSet<PromYourSelf.Models.TipoClasificacion> TipoClasificacion { get; set; }
    }
}
//https://entityframeworkcore.com/knowledge-base/50862525/seed-entity-with-owned-property