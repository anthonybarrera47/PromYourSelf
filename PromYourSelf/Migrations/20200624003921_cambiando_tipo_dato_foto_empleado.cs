using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class cambiando_tipo_dato_foto_empleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Empleados",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 6, 23, 20, 39, 21, 798, DateTimeKind.Local).AddTicks(3846), new DateTime(2020, 6, 23, 20, 39, 21, 798, DateTimeKind.Local).AddTicks(9455) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "Empleados",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 6, 23, 20, 8, 36, 581, DateTimeKind.Local).AddTicks(5490), new DateTime(2020, 6, 23, 20, 8, 36, 582, DateTimeKind.Local).AddTicks(3598) });
        }
    }
}
