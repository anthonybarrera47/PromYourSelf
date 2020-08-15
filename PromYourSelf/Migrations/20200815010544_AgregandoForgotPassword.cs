using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class AgregandoForgotPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordGenerators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    EsNulo = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FakePassWord = table.Column<string>(nullable: true),
                    TimeExpire = table.Column<DateTime>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordGenerators", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordGenerators");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "13/08/2020 7:59:12 PM", new DateTime(2020, 8, 13, 19, 59, 12, 523, DateTimeKind.Local).AddTicks(4210), new DateTime(2020, 8, 13, 19, 59, 12, 525, DateTimeKind.Local).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "13/08/2020 7:59:12 PM", new DateTime(2020, 8, 13, 19, 59, 12, 533, DateTimeKind.Local).AddTicks(8234), new DateTime(2020, 8, 13, 19, 59, 12, 533, DateTimeKind.Local).AddTicks(8245) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "13/08/2020 7:59:12 PM", new DateTime(2020, 8, 13, 19, 59, 12, 533, DateTimeKind.Local).AddTicks(9264), new DateTime(2020, 8, 13, 19, 59, 12, 533, DateTimeKind.Local).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 534, DateTimeKind.Local).AddTicks(9843), new DateTime(2020, 8, 13, 19, 59, 12, 535, DateTimeKind.Local).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 535, DateTimeKind.Local).AddTicks(1934), new DateTime(2020, 8, 13, 19, 59, 12, 535, DateTimeKind.Local).AddTicks(1946) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 535, DateTimeKind.Local).AddTicks(1957), new DateTime(2020, 8, 13, 19, 59, 12, 535, DateTimeKind.Local).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(106), new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(113) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(164), new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(165) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(168), new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(169) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(171), new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(171) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(173), new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(174) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(177), new DateTime(2020, 8, 13, 19, 59, 12, 536, DateTimeKind.Local).AddTicks(178) });
        }
    }
}
