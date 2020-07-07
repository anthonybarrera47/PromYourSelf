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
    [Migration("20200707190431_PRUEBA")]
    partial class PRUEBA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<int>("NegocioID");

                    b.Property<string>("Notas");

                    b.Property<int>("UsuarioID");

                    b.HasKey("CitaID");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Models.CitasDetalle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<int?>("CitaID");

                    b.Property<decimal>("Precio");

                    b.Property<int>("ProductoID");

                    b.HasKey("ID");

                    b.HasIndex("CitaID");

                    b.ToTable("CitasDetalle");
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

            modelBuilder.Entity("Models.Empleados", b =>
                {
                    b.Property<int>("EmpleadoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired();

                    b.Property<int>("CreadoPor");

                    b.Property<bool>("EsNulo");

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<string>("Foto");

                    b.Property<int>("Genero");

                    b.Property<int>("ModificadoPor");

                    b.Property<int>("NegocioID");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("UsuarioID");

                    b.HasKey("EmpleadoID");

                    b.ToTable("Empleados");
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

                    b.Property<int?>("ProductosProductoID");

                    b.Property<int>("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("ProductosProductoID");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("Models.FotosProductos", b =>
                {
                    b.Property<int>("FotoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foto");

                    b.Property<int?>("ProductosProductoID");

                    b.HasKey("FotoID");

                    b.HasIndex("ProductosProductoID");

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

                    b.Property<int?>("NegociosNegocioID");

                    b.Property<string>("Sabado");

                    b.Property<string>("Viernes");

                    b.HasKey("HorarioID");

                    b.HasIndex("NegociosNegocioID");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Models.Mensajes", b =>
                {
                    b.Property<int>("MensajeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("CreadoPor");

                    b.Property<bool>("EsNulo");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaModificacion");

                    b.Property<int>("ModificadoPor");

                    b.Property<int>("NegocioID");

                    b.Property<int>("Tipo");

                    b.Property<int>("UsuarioID");

                    b.HasKey("MensajeID");

                    b.HasIndex("ClienteId");

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
                            CiudadID = 1,
                            CreadoPor = 1,
                            Direccion = "En todas partes , es omnipresente",
                            EsNulo = false,
                            FechaCreacion = new DateTime(2020, 7, 7, 15, 4, 30, 774, DateTimeKind.Local).AddTicks(9158),
                            FechaModificacion = new DateTime(2020, 7, 7, 15, 4, 30, 775, DateTimeKind.Local).AddTicks(6192),
                            Latitud = "1000",
                            Longitud = "2000",
                            ModificadoPor = 1,
                            NombreComercial = "JuanDupreCompany",
                            Telefono1 = "829-123-4567",
                            Telefono2 = "809-123-4567",
                            UsuarioID = 0
                        });
                });

            modelBuilder.Entity("Models.Productos", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreadoPor");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255);

                    b.Property<int?>("EmpleadosEmpleadoID");

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

                    b.HasIndex("EmpleadosEmpleadoID");

                    b.ToTable("Productos");
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

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TipoUsuario");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("UsuarioID");

                    b.HasKey("Id");

                    b.HasAlternateKey("UsuarioID");

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

                    b.Property<int>("UsuarioID");

                    b.Property<int?>("UsuariosId");

                    b.HasKey("VentaID");

                    b.HasIndex("UsuariosId");

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

                    b.HasIndex("VentaID");

                    b.ToTable("VentasDetalle");
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

                    b.Property<int>("UsuarioID");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("PromYourSelf.Models.Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Models.Usuarios")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Models.Usuarios")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("PromYourSelf.Models.Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity("Models.CitasDetalle", b =>
                {
                    b.HasOne("Models.Citas", "Cita")
                        .WithMany("Details")
                        .HasForeignKey("CitaID");
                });

            modelBuilder.Entity("Models.Etiquetas", b =>
                {
                    b.HasOne("Models.Productos")
                        .WithMany("Etiquetas")
                        .HasForeignKey("ProductosProductoID");
                });

            modelBuilder.Entity("Models.FotosProductos", b =>
                {
                    b.HasOne("Models.Productos", "Productos")
                        .WithMany("Fotos")
                        .HasForeignKey("ProductosProductoID");
                });

            modelBuilder.Entity("Models.Horarios", b =>
                {
                    b.HasOne("Models.Negocios", "Negocios")
                        .WithMany()
                        .HasForeignKey("NegociosNegocioID");
                });

            modelBuilder.Entity("Models.Mensajes", b =>
                {
                    b.HasOne("Models.Usuarios", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("Models.Productos", b =>
                {
                    b.HasOne("Models.Empleados")
                        .WithMany("Productos")
                        .HasForeignKey("EmpleadosEmpleadoID");
                });

            modelBuilder.Entity("Models.Ventas", b =>
                {
                    b.HasOne("Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosId");
                });

            modelBuilder.Entity("Models.VentasDetalle", b =>
                {
                    b.HasOne("Models.Ventas", "Venta")
                        .WithMany("Details")
                        .HasForeignKey("VentaID");
                });
#pragma warning restore 612, 618
        }
    }
}
