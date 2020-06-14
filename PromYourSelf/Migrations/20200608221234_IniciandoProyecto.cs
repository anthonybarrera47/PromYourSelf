using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class IniciandoProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Horarios",
                columns: table => new
                {
                    HorarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lunes = table.Column<string>(nullable: true),
                    Martes = table.Column<string>(nullable: true),
                    Miercoles = table.Column<string>(nullable: true),
                    Jueves = table.Column<string>(nullable: true),
                    viernes = table.Column<string>(nullable: true),
                    Sabado = table.Column<string>(nullable: true),
                    Domingo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HorarioID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Confirmado = table.Column<bool>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Negocios",
                columns: table => new
                {
                    NegocioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: true),
                    HorariosHorarioID = table.Column<int>(nullable: true),
                    NombreComercial = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono1 = table.Column<string>(nullable: true),
                    Telefono2 = table.Column<string>(nullable: true),
                    CiudadID = table.Column<int>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocios", x => x.NegocioID);
                    table.ForeignKey(
                        name: "FK_Negocios_Ciudad_CiudadID",
                        column: x => x.CiudadID,
                        principalTable: "Ciudad",
                        principalColumn: "CiudadID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Negocios_Horarios_HorariosHorarioID",
                        column: x => x.HorariosHorarioID,
                        principalTable: "Horarios",
                        principalColumn: "HorarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Negocios_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CitaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    ClienteUsuarioID = table.Column<int>(nullable: true),
                    NegocioID = table.Column<int>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    CodigoComprobacion = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CitaID);
                    table.ForeignKey(
                        name: "FK_Citas_Usuarios_ClienteUsuarioID",
                        column: x => x.ClienteUsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Negocios_NegocioID",
                        column: x => x.NegocioID,
                        principalTable: "Negocios",
                        principalColumn: "NegocioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    NegocioID = table.Column<int>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Genero = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleados_Negocios_NegocioID",
                        column: x => x.NegocioID,
                        principalTable: "Negocios",
                        principalColumn: "NegocioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensaje",
                columns: table => new
                {
                    MensajeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    ClienteUsuarioID = table.Column<int>(nullable: true),
                    NegociosNegocioID = table.Column<int>(nullable: true),
                    Contenido = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensaje", x => x.MensajeID);
                    table.ForeignKey(
                        name: "FK_Mensaje_Usuarios_ClienteUsuarioID",
                        column: x => x.ClienteUsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensaje_Negocios_NegociosNegocioID",
                        column: x => x.NegociosNegocioID,
                        principalTable: "Negocios",
                        principalColumn: "NegocioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    UsuariosUsuarioID = table.Column<int>(nullable: true),
                    NegociosNegocioID = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    CitaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaID);
                    table.ForeignKey(
                        name: "FK_Ventas_Negocios_NegociosNegocioID",
                        column: x => x.NegociosNegocioID,
                        principalTable: "Negocios",
                        principalColumn: "NegocioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_UsuariosUsuarioID",
                        column: x => x.UsuariosUsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CitasDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CitaID = table.Column<int>(nullable: true),
                    ProductoID = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitasDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CitasDetalle_Citas_CitaID",
                        column: x => x.CitaID,
                        principalTable: "Citas",
                        principalColumn: "CitaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    NegociosNegocioID = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Unidad = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    PrecioOferta = table.Column<decimal>(nullable: false),
                    TipoProductos = table.Column<int>(nullable: false),
                    EmpleadosEmpleadoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Productos_Empleados_EmpleadosEmpleadoID",
                        column: x => x.EmpleadosEmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Negocios_NegociosNegocioID",
                        column: x => x.NegociosNegocioID,
                        principalTable: "Negocios",
                        principalColumn: "NegocioID",
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

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    FotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductosProductoID = table.Column<int>(nullable: true),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosProductos", x => x.FotoId);
                    table.ForeignKey(
                        name: "FK_FotosProductos_Productos_ProductosProductoID",
                        column: x => x.ProductosProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ClienteUsuarioID",
                table: "Citas",
                column: "ClienteUsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_NegocioID",
                table: "Citas",
                column: "NegocioID");

            migrationBuilder.CreateIndex(
                name: "IX_CitasDetalle_CitaID",
                table: "CitasDetalle",
                column: "CitaID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_NegocioID",
                table: "Empleados",
                column: "NegocioID");

            migrationBuilder.CreateIndex(
                name: "IX_Etiquetas_ProductosProductoID",
                table: "Etiquetas",
                column: "ProductosProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_FotosProductos_ProductosProductoID",
                table: "FotosProductos",
                column: "ProductosProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_ClienteUsuarioID",
                table: "Mensaje",
                column: "ClienteUsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_NegociosNegocioID",
                table: "Mensaje",
                column: "NegociosNegocioID");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_CiudadID",
                table: "Negocios",
                column: "CiudadID");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_HorariosHorarioID",
                table: "Negocios",
                column: "HorariosHorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_UsuarioID",
                table: "Negocios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_EmpleadosEmpleadoID",
                table: "Productos",
                column: "EmpleadosEmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_NegociosNegocioID",
                table: "Productos",
                column: "NegociosNegocioID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_NegociosNegocioID",
                table: "Ventas",
                column: "NegociosNegocioID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuariosUsuarioID",
                table: "Ventas",
                column: "UsuariosUsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaID",
                table: "VentasDetalle",
                column: "VentaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitasDetalle");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "FotosProductos");

            migrationBuilder.DropTable(
                name: "Mensaje");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Negocios");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
