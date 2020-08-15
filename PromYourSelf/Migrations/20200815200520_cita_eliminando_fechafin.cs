using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class cita_eliminando_fechafin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Citas");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "8/15/2020 4:05:19 PM", new DateTime(2020, 8, 15, 16, 5, 19, 856, DateTimeKind.Local).AddTicks(8264), new DateTime(2020, 8, 15, 16, 5, 19, 857, DateTimeKind.Local).AddTicks(2866) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "8/15/2020 4:05:19 PM", new DateTime(2020, 8, 15, 16, 5, 19, 860, DateTimeKind.Local).AddTicks(7265), new DateTime(2020, 8, 15, 16, 5, 19, 860, DateTimeKind.Local).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "8/15/2020 4:05:19 PM", new DateTime(2020, 8, 15, 16, 5, 19, 860, DateTimeKind.Local).AddTicks(7809), new DateTime(2020, 8, 15, 16, 5, 19, 860, DateTimeKind.Local).AddTicks(7809) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(1607), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(1986) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(2198), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(2210), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(2211) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4020), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4022) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4051), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4053), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4055), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4055) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4056), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4058), new DateTime(2020, 8, 15, 16, 5, 19, 861, DateTimeKind.Local).AddTicks(4058) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Citas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "14/08/2020 9:05:43 PM", new DateTime(2020, 8, 14, 21, 5, 43, 756, DateTimeKind.Local).AddTicks(9271), new DateTime(2020, 8, 14, 21, 5, 43, 757, DateTimeKind.Local).AddTicks(7702) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "14/08/2020 9:05:43 PM", new DateTime(2020, 8, 14, 21, 5, 43, 766, DateTimeKind.Local).AddTicks(1368), new DateTime(2020, 8, 14, 21, 5, 43, 766, DateTimeKind.Local).AddTicks(1379) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "14/08/2020 9:05:43 PM", new DateTime(2020, 8, 14, 21, 5, 43, 766, DateTimeKind.Local).AddTicks(2524), new DateTime(2020, 8, 14, 21, 5, 43, 766, DateTimeKind.Local).AddTicks(2525) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(2029), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(3032) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(3581), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(3603), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(3604) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8083), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8088) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8127), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8128) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8130), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8131) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8205), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8206) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8209), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8210) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8212), new DateTime(2020, 8, 14, 21, 5, 43, 767, DateTimeKind.Local).AddTicks(8213) });
        }
    }
}
