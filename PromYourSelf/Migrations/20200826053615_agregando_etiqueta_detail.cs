using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class agregando_etiqueta_detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etiquetas_Productos_ProductosProductoID",
                table: "Etiquetas");

            migrationBuilder.DropIndex(
                name: "IX_Etiquetas_ProductosProductoID",
                table: "Etiquetas");

            migrationBuilder.DropColumn(
                name: "ProductosProductoID",
                table: "Etiquetas");

            migrationBuilder.CreateTable(
                name: "EtiquetasDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductoID = table.Column<int>(nullable: false),
                    EtiquetaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetasDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EtiquetasDetails_Etiquetas_EtiquetaID",
                        column: x => x.EtiquetaID,
                        principalTable: "Etiquetas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetasDetails_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 384, DateTimeKind.Local).AddTicks(8645), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3544) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3789), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3795) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3802), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(3802) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6631), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6633) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6659), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6661), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6662) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6664), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6665) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion", "NegocioID" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6666), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6666), 1 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion", "NegocioID" },
                values: new object[] { new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6667), new DateTime(2020, 8, 26, 1, 36, 15, 385, DateTimeKind.Local).AddTicks(6667), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_ProductoID",
                table: "VentasDetalle",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetasDetails_EtiquetaID",
                table: "EtiquetasDetails",
                column: "EtiquetaID");

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetasDetails_ProductoID",
                table: "EtiquetasDetails",
                column: "ProductoID");

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalle_Productos_ProductoID",
                table: "VentasDetalle",
                column: "ProductoID",
                principalTable: "Productos",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalle_Productos_ProductoID",
                table: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "EtiquetasDetails");

            migrationBuilder.DropIndex(
                name: "IX_VentasDetalle_ProductoID",
                table: "VentasDetalle");

            migrationBuilder.AddColumn<int>(
                name: "ProductosProductoID",
                table: "Etiquetas",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 317, DateTimeKind.Local).AddTicks(2277), new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(3456), new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(3475), new DateTime(2020, 8, 20, 23, 7, 2, 318, DateTimeKind.Local).AddTicks(3476) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1667), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1671) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1711), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1712) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1714), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1715) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1717), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1717) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion", "NegocioID" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1719), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1720), 3 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion", "NegocioID" },
                values: new object[] { new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1721), new DateTime(2020, 8, 20, 23, 7, 2, 319, DateTimeKind.Local).AddTicks(1722), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Etiquetas_ProductosProductoID",
                table: "Etiquetas",
                column: "ProductosProductoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Etiquetas_Productos_ProductosProductoID",
                table: "Etiquetas",
                column: "ProductosProductoID",
                principalTable: "Productos",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
