using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class CambiandoCamposEstandar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "EsNulo",
                table: "Ventas",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "EsNulo",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "EsNulo",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "EsNulo",
                table: "Negocios",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "EsNulo",
                table: "Mensaje",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "EsNulo",
                table: "Etiquetas",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "EsNulo",
                table: "Empleados",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "EsNulo",
                table: "Citas",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "EsNulo", "FechaCreacion", "FechaModificacion" },
                values: new object[] { false, new DateTime(2020, 6, 26, 17, 52, 10, 321, DateTimeKind.Local).AddTicks(8065), new DateTime(2020, 6, 26, 17, 52, 10, 322, DateTimeKind.Local).AddTicks(5879) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EsNulo",
                table: "Ventas",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "EsNulo",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "EsNulo",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "EsNulo",
                table: "Negocios",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "EsNulo",
                table: "Mensaje",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "EsNulo",
                table: "Etiquetas",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "EsNulo",
                table: "Empleados",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "EsNulo",
                table: "Citas",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "EsNulo", "FechaCreacion", "FechaModificacion" },
                values: new object[] { 0, new DateTime(2020, 6, 24, 19, 47, 59, 987, DateTimeKind.Local).AddTicks(4486), new DateTime(2020, 6, 24, 19, 47, 59, 988, DateTimeKind.Local).AddTicks(2923) });
        }
    }
}
