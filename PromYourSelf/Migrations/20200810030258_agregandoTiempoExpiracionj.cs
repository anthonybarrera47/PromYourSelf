using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class agregandoTiempoExpiracionj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TiempoExpiracion",
                table: "CodeValidation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 9, 23, 2, 58, 460, DateTimeKind.Local).AddTicks(4661), new DateTime(2020, 8, 9, 23, 2, 58, 461, DateTimeKind.Local).AddTicks(3512) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TiempoExpiracion",
                table: "CodeValidation");

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 7, 20, 11, 57, 668, DateTimeKind.Local).AddTicks(6509), new DateTime(2020, 8, 7, 20, 11, 57, 669, DateTimeKind.Local).AddTicks(4352) });
        }
    }
}
