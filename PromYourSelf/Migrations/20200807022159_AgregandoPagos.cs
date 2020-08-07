using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class AgregandoPagos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 6, 22, 21, 59, 214, DateTimeKind.Local).AddTicks(3941), new DateTime(2020, 8, 6, 22, 21, 59, 215, DateTimeKind.Local).AddTicks(3971) });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TipoClasificacionID",
                table: "Pagos",
                column: "TipoClasificacionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "TipoClasificacion");

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 4, 20, 39, 49, 398, DateTimeKind.Local).AddTicks(3251), new DateTime(2020, 8, 4, 20, 39, 49, 398, DateTimeKind.Local).AddTicks(8486) });
        }
    }
}
