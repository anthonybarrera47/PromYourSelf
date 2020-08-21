using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Design;

namespace PromYourSelf.Migrations
{
    public partial class DataInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 256, nullable: false),
                    Confirmado = table.Column<bool>(nullable: false),
                    Posicion = table.Column<string>(maxLength: 40, nullable: false),
                    PasswordRecovery = table.Column<string>(nullable: true),
                    TimeExpired = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    NegocioID = table.Column<int>(nullable: false),
                    EmpleadoAsignado = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    CodigoComprobacion = table.Column<string>(maxLength: 15, nullable: false),
                    Notas = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaID);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    CityAscii = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Lng = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Iso2 = table.Column<string>(nullable: true),
                    Iso3 = table.Column<string>(nullable: true),
                    AdminName = table.Column<string>(nullable: true),
                    Capital = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadID);
                });

            migrationBuilder.CreateTable(
                name: "CodeValidation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TiempoExpiracion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeValidation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HorarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lunes = table.Column<string>(nullable: true),
                    Martes = table.Column<string>(nullable: true),
                    Miercoles = table.Column<string>(nullable: true),
                    Jueves = table.Column<string>(nullable: true),
                    Viernes = table.Column<string>(nullable: true),
                    Sabado = table.Column<string>(nullable: true),
                    Domingo = table.Column<string>(nullable: true),
                    NegociosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HorarioID);
                });

            migrationBuilder.CreateTable(
                name: "Negocios",
                columns: table => new
                {
                    NegocioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    NombreComercial = table.Column<string>(maxLength: 255, nullable: false),
                    Direccion = table.Column<string>(maxLength: 255, nullable: false),
                    Telefono1 = table.Column<string>(maxLength: 20, nullable: false),
                    Telefono2 = table.Column<string>(maxLength: 20, nullable: true),
                    CiudadID = table.Column<int>(nullable: false),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocios", x => x.NegocioID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    NegocioID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 255, nullable: true),
                    Unidad = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    PrecioOferta = table.Column<decimal>(nullable: false),
                    TipoProductos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                });

            migrationBuilder.CreateTable(
                name: "ProfileViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Confirmado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoClasificacion",
                columns: table => new
                {
                    TipoClasificacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoClasificacion", x => x.TipoClasificacionID);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    UsuarioClienteID = table.Column<int>(nullable: false),
                    NegocioID = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    CitaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    ClaimAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    ClaimAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensaje",
                columns: table => new
                {
                    MensajeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    ReceptorID = table.Column<int>(nullable: false),
                    Contenido = table.Column<string>(maxLength: 255, nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    EstadoMensaje = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensaje", x => x.MensajeID);
                    table.ForeignKey(
                        name: "FK_Mensaje_AspNetUsers_ReceptorID",
                        column: x => x.ReceptorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    ProductosProductoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Etiquetas_Productos_ProductosProductoID",
                        column: x => x.ProductosProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FotosProductos",
                columns: table => new
                {
                    FotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductoID = table.Column<int>(nullable: false),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosProductos", x => x.FotoID);
                    table.ForeignKey(
                        name: "FK_FotosProductos_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    NegocioID = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    TipoClasificacionID = table.Column<int>(nullable: true),
                    Concepto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoID);
                    table.ForeignKey(
                        name: "FK_Pagos_TipoClasificacion_TipoClasificacionID",
                        column: x => x.TipoClasificacionID,
                        principalTable: "TipoClasificacion",
                        principalColumn: "TipoClasificacionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VentaID = table.Column<int>(nullable: true),
                    ProductoID = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Ventas_VentaID",
                        column: x => x.VentaID,
                        principalTable: "Ventas",
                        principalColumn: "VentaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Negocios",
                columns: new[] { "NegocioID", "CiudadID", "CreadoPor", "Direccion", "EsNulo", "FechaCreacion", "FechaModificacion", "Latitud", "Longitud", "ModificadoPor", "NombreComercial", "Telefono1", "Telefono2", "UsuarioID" },
                values: new object[,]
                {
                    { 1, 2547, 1, "En todas partes , es omnipresente", false, new DateTime(2020, 8, 20, 23, 7, 2, 317, DateTimeKind.Local).AddTicks(2277), new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(2849), "1000", "2000", 1, "JuanDupreCompany", "829-123-4567", "809-123-4567", 1 },
                    { 2, 2547, 3, "Cenovi, SFM", false, new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(3456), new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(3465), "1000", "2000", 3, "APAS LABS", "809-754-0319", "", 3 },
                    { 3, 2547, 4, "Centro de la cuidad, SFM", false, new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(3475), new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(3476), "1000", "2000", 4, "BHTech", "829-935-9510", "809-123-4567", 4 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoID", "CreadoPor", "Descripcion", "EsNulo", "FechaCreacion", "FechaModificacion", "ModificadoPor", "NegocioID", "Nombre", "Precio", "PrecioOferta", "Stock", "TipoProductos", "Unidad", "UsuarioID" },
                values: new object[,]
                {
                    { 1, 3, "PrestFast Lite", false, new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1667), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1671), 3, 2, "App Prestamo", 10m, 0m, 0, 0, 1, 3 },
                    { 2, 3, "Consultoria Informatica", false, new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1711), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1712), 3, 2, "Consultor Informatico", 1000m, 0m, 0, 1, 1, 3 },
                    { 3, 4, "ASUS Q503", false, new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1714), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1715), 4, 3, "Laptop", 15000m, 0m, 0, 0, 1, 4 },
                    { 4, 4, "Reparación y Mantenimiento", false, new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1717), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1717), 4, 3, "Reparación", 15000m, 0m, 0, 1, 1, 4 },
                    { 5, 1, "Brugal Dupre 200mg", false, new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1719), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1720), 1, 3, "Brugal Dupre", 15000m, 0m, 0, 0, 1, 1 },
                    { 6, 1, "Catar Vinos", false, new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1721), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1722), 1, 3, "Catador de vinos", 15000m, 0m, 0, 1, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Etiquetas_ProductosProductoID",
                table: "Etiquetas",
                column: "ProductosProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_FotosProductos_ProductoID",
                table: "FotosProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_ReceptorID",
                table: "Mensaje",
                column: "ReceptorID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TipoClasificacionID",
                table: "Pagos",
                column: "TipoClasificacionID");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaID",
                table: "VentasDetalle",
                column: "VentaID");
            Utils.Utils.SeedCuidades(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "CodeValidation");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "FotosProductos");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Mensaje");

            migrationBuilder.DropTable(
                name: "Negocios");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "ProfileViewModel");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TipoClasificacion");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
