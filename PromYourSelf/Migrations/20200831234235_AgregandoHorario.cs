using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class AgregandoHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 57, DateTimeKind.Local).AddTicks(4706), new DateTime(2020, 8, 31, 19, 42, 35, 58, DateTimeKind.Local).AddTicks(4887) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 58, DateTimeKind.Local).AddTicks(5605), new DateTime(2020, 8, 31, 19, 42, 35, 58, DateTimeKind.Local).AddTicks(5615) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 58, DateTimeKind.Local).AddTicks(5626), new DateTime(2020, 8, 31, 19, 42, 35, 58, DateTimeKind.Local).AddTicks(5628) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6171), new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6182) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6268), new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6274), new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6275) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6279), new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6283), new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6284) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6287), new DateTime(2020, 8, 31, 19, 42, 35, 59, DateTimeKind.Local).AddTicks(6288) });

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_NegociosId",
                table: "Horarios",
                column: "NegociosId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Negocios_NegociosId",
                table: "Horarios",
                column: "NegociosId",
                principalTable: "Negocios",
                principalColumn: "NegocioID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Negocios_NegociosId",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_NegociosId",
                table: "Horarios");

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 468, DateTimeKind.Local).AddTicks(1912), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(1274) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(1889), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(1898) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(1908), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(1909) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9754), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9808), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9809) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9811), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9814), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9815) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9816), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9818) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9820), new DateTime(2020, 8, 28, 19, 33, 40, 469, DateTimeKind.Local).AddTicks(9820) });
        }
    }
}
