using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class PRUEBA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 7, 7, 15, 4, 30, 774, DateTimeKind.Local).AddTicks(9158), new DateTime(2020, 7, 7, 15, 4, 30, 775, DateTimeKind.Local).AddTicks(6192) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 7, 2, 20, 16, 15, 424, DateTimeKind.Local).AddTicks(3557), new DateTime(2020, 7, 2, 20, 16, 15, 425, DateTimeKind.Local).AddTicks(2667) });
        }
    }
}
