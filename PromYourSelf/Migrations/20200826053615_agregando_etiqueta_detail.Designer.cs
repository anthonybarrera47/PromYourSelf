﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace PromYourSelf.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200826053615_agregando_etiqueta_detail")]
    partial class agregando_etiqueta_detail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.Citas", b =>
                {
                    b.Property<int>("CitaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoComprobacion")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("CreadoPor");

                    b.Property<int>("EmpleadoAsignado");

                    b.Property<bool>("EsNulo");

                    b.Property<int>("Estado");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<int>("NegocioID");

                    b.Property<string>("Notas");

                    b.Property<int>("ProductoID");

                    b.Property<int>("UsuarioID");

                    b.HasKey("CitaID");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Models.Ciudad", b =>
                {
                    b.Property<int>("CiudadID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminName");

                    b.Property<string>("Capital");

                    b.Property<string>("City");

                    b.Property<string>("CityAscii");

                    b.Property<string>("Country");

                    b.Property<string>("Iso2");

                    b.Property<string>("Iso3");

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.HasKey("CiudadID");

                    b.ToTable("Ciudad");
                });

            modelBuilder.Entity("Models.Etiquetas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreadoPor");

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<string>("Nombre");

                    b.Property<int>("UsuarioID");

                    b.HasKey("ID");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("Models.FotosProductos", b =>
                {
                    b.Property<int>("FotoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foto");

                    b.Property<int>("ProductoID");

                    b.HasKey("FotoID");

                    b.HasIndex("ProductoID");

                    b.ToTable("FotosProductos");
                });

            modelBuilder.Entity("Models.Horarios", b =>
                {
                    b.Property<int>("HorarioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Domingo");

                    b.Property<string>("Jueves");

                    b.Property<string>("Lunes");

                    b.Property<string>("Martes");

                    b.Property<string>("Miercoles");

                    b.Property<int>("NegociosId");

                    b.Property<string>("Sabado");

                    b.Property<string>("Viernes");

                    b.HasKey("HorarioID");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Models.Mensajes", b =>
                {
                    b.Property<int>("MensajeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("CreadoPor");

                    b.Property<bool>("EsNulo");

                    b.Property<int>("EstadoMensaje");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<int>("ReceptorID");

                    b.Property<int>("Tipo");

                    b.Property<int>("UsuarioID");

                    b.HasKey("MensajeID");

                    b.HasIndex("ReceptorID");

                    b.ToTable("Mensaje");
                });

            modelBuilder.Entity("Models.Negocios", b =>
                {
                    b.Property<int>("NegocioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiudadID");

                    b.Property<int>("CreadoPor");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<string>("Latitud");

                    b.Property<string>("Longitud");

                    b.Property<int>("ModificadoPor");

                    b.Property<string>("NombreComercial")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Telefono1")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Telefono2")
                        .HasMaxLength(20);

                    b.Property<int>("UsuarioID");

                    b.HasKey("NegocioID");

                    b.ToTable("Negocios");

                    b.HasData(
                        new
                        {
                            NegocioID = 1,
                            CiudadID = 2547,
                            CreadoPor = 1,
                            Direccion = "En todas partes , es omnipresente",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 384, DateTimeKind.Local).AddTicks(8645),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3544),
                            Latitud = "1000",
                            Longitud = "2000",
                            ModificadoPor = 1,
                            NombreComercial = "JuanDupreCompany",
                            Telefono1 = "829-123-4567",
                            Telefono2 = "809-123-4567",
                            UsuarioID = 1
                        },
                        new
                        {
                            NegocioID = 2,
                            CiudadID = 2547,
                            CreadoPor = 3,
                            Direccion = "Cenovi, SFM",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3789),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3795),
                            Latitud = "1000",
                            Longitud = "2000",
                            ModificadoPor = 3,
                            NombreComercial = "APAS LABS",
                            Telefono1 = "809-754-0319",
                            Telefono2 = "",
                            UsuarioID = 3
                        },
                        new
                        {
                            NegocioID = 3,
                            CiudadID = 2547,
                            CreadoPor = 4,
                            Direccion = "Centro de la cuidad, SFM",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3802),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3802),
                            Latitud = "1000",
                            Longitud = "2000",
                            ModificadoPor = 4,
                            NombreComercial = "BHTech",
                            Telefono1 = "829-935-9510",
                            Telefono2 = "809-123-4567",
                            UsuarioID = 4
                        });
                });

            modelBuilder.Entity("Models.Pagos", b =>
                {
                    b.Property<int>("PagoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Concepto");

                    b.Property<int>("CreadoPor");

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("Fecha");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<decimal>("Monto");

                    b.Property<int>("NegocioID");

                    b.Property<int?>("TipoClasificacionID");

                    b.Property<int>("UsuarioID");

                    b.HasKey("PagoID");

                    b.HasIndex("TipoClasificacionID");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Models.Productos", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreadoPor");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255);

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<int>("NegocioID");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<decimal>("Precio");

                    b.Property<decimal>("PrecioOferta");

                    b.Property<int>("Stock");

                    b.Property<int>("TipoProductos");

                    b.Property<int>("Unidad");

                    b.Property<int>("UsuarioID");

                    b.HasKey("ProductoID");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoID = 1,
                            CreadoPor = 3,
                            Descripcion = "PrestFast Lite",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6631),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6633),
                            ModificadoPor = 3,
                            NegocioID = 2,
                            Nombre = "App Prestamo",
                            Precio = 10m,
                            PrecioOferta = 0m,
                            Stock = 0,
                            TipoProductos = 0,
                            Unidad = 1,
                            UsuarioID = 3
                        },
                        new
                        {
                            ProductoID = 2,
                            CreadoPor = 3,
                            Descripcion = "Consultoria Informatica",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6659),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6660),
                            ModificadoPor = 3,
                            NegocioID = 2,
                            Nombre = "Consultor Informatico",
                            Precio = 1000m,
                            PrecioOferta = 0m,
                            Stock = 0,
                            TipoProductos = 1,
                            Unidad = 1,
                            UsuarioID = 3
                        },
                        new
                        {
                            ProductoID = 3,
                            CreadoPor = 4,
                            Descripcion = "ASUS Q503",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6661),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6662),
                            ModificadoPor = 4,
                            NegocioID = 3,
                            Nombre = "Laptop",
                            Precio = 15000m,
                            PrecioOferta = 0m,
                            Stock = 0,
                            TipoProductos = 0,
                            Unidad = 1,
                            UsuarioID = 4
                        },
                        new
                        {
                            ProductoID = 4,
                            CreadoPor = 4,
                            Descripcion = "Reparación y Mantenimiento",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6664),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6665),
                            ModificadoPor = 4,
                            NegocioID = 3,
                            Nombre = "Reparación",
                            Precio = 15000m,
                            PrecioOferta = 0m,
                            Stock = 0,
                            TipoProductos = 1,
                            Unidad = 1,
                            UsuarioID = 4
                        },
                        new
                        {
                            ProductoID = 5,
                            CreadoPor = 1,
                            Descripcion = "Brugal Dupre 200mg",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6666),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6666),
                            ModificadoPor = 1,
                            NegocioID = 1,
                            Nombre = "Brugal Dupre",
                            Precio = 15000m,
                            PrecioOferta = 0m,
                            Stock = 0,
                            TipoProductos = 0,
                            Unidad = 1,
                            UsuarioID = 1
                        },
                        new
                        {
                            ProductoID = 6,
                            CreadoPor = 1,
                            Descripcion = "Catar Vinos",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6667),
                            FechaModificacion = new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6667),
                            ModificadoPor = 1,
                            NegocioID = 1,
                            Nombre = "Catador de vinos",
                            Precio = 15000m,
                            PrecioOferta = 0m,
                            Stock = 0,
                            TipoProductos = 1,
                            Unidad = 1,
                            UsuarioID = 1
                        });
                });

            modelBuilder.Entity("Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Apellidos")
                        .IsRequired();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<bool>("Confirmado");

                    b.Property<int>("CreadoPor");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("EsNulo");

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<string>("Foto");

                    b.Property<int>("Genero");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<int>("ModificadoPor");

                    b.Property<string>("Nombres")
                        .IsRequired();

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordRecovery");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Posicion")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("SecurityStamp");

                    b.Property<DateTime>("TimeExpired");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Models.Ventas", b =>
                {
                    b.Property<int>("VentaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CitaID");

                    b.Property<int>("CreadoPor");

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("Fecha");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<decimal>("Monto");

                    b.Property<int>("NegocioID");

                    b.Property<int>("UsuarioClienteID");

                    b.Property<int>("UsuarioID");

                    b.HasKey("VentaID");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Models.VentasDetalle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<decimal>("Precio");

                    b.Property<int>("ProductoID");

                    b.Property<int?>("VentaID");

                    b.HasKey("ID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("VentaID");

                    b.ToTable("VentasDetalle");
                });

            modelBuilder.Entity("PromYourSelf.Models.CodeValidation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("Email");

                    b.Property<DateTime>("TiempoExpiracion");

                    b.Property<int>("UsuarioID");

                    b.HasKey("Id");

                    b.ToTable("CodeValidation");
                });

            modelBuilder.Entity("PromYourSelf.Models.ControlUsers.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimAction");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("PromYourSelf.Models.ControlUsers.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimAction");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("PromYourSelf.Models.ControlUsers.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<int>("CreadoPor");

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("PromYourSelf.Models.EtiquetasDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EtiquetaID");

                    b.Property<int>("ProductoID");

                    b.HasKey("ID");

                    b.HasIndex("EtiquetaID");

                    b.HasIndex("ProductoID");

                    b.ToTable("EtiquetasDetails");
                });

            modelBuilder.Entity("PromYourSelf.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CreadoPor");

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("PromYourSelf.Models.TipoClasificacion", b =>
                {
                    b.Property<int>("TipoClasificacionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreadoPor");

                    b.Property<string>("Descripcion");

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<int>("UsuarioID");

                    b.HasKey("TipoClasificacionID");

                    b.ToTable("TipoClasificacion");
                });

            modelBuilder.Entity("PromYourSelf.ViewModels.ProfileViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos");

                    b.Property<bool>("Confirmado");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<string>("Foto");

                    b.Property<int>("Genero");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefono");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("ProfileViewModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Models.Usuarios")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Models.Usuarios")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.FotosProductos", b =>
                {
                    b.HasOne("Models.Productos")
                        .WithMany("Fotos")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Mensajes", b =>
                {
                    b.HasOne("Models.Usuarios", "Receptor")
                        .WithMany()
                        .HasForeignKey("ReceptorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Pagos", b =>
                {
                    b.HasOne("PromYourSelf.Models.TipoClasificacion", "TipoClasificacion")
                        .WithMany()
                        .HasForeignKey("TipoClasificacionID");
                });

            modelBuilder.Entity("Models.VentasDetalle", b =>
                {
                    b.HasOne("Models.Productos", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Ventas", "Venta")
                        .WithMany("Details")
                        .HasForeignKey("VentaID");
                });

            modelBuilder.Entity("PromYourSelf.Models.ControlUsers.RoleClaim", b =>
                {
                    b.HasOne("PromYourSelf.Models.Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PromYourSelf.Models.ControlUsers.UserClaim", b =>
                {
                    b.HasOne("Models.Usuarios")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PromYourSelf.Models.ControlUsers.UserRole", b =>
                {
                    b.HasOne("PromYourSelf.Models.Roles", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Usuarios", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PromYourSelf.Models.EtiquetasDetails", b =>
                {
                    b.HasOne("Models.Etiquetas", "Etiqueta")
                        .WithMany()
                        .HasForeignKey("EtiquetaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Productos")
                        .WithMany("Etiquetas")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
