using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class QuitandoGenerador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordGenerators");

            migrationBuilder.AddColumn<string>(
                name: "PasswordRecovery",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeExpired",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion", "PasswordRecovery", "TimeExpired" },
                values: new object[] { "17/08/2020 6:51:49 PM", new DateTime(2020, 8, 17, 18, 51, 49, 788, DateTimeKind.Local).AddTicks(2034), new DateTime(2020, 8, 17, 18, 51, 49, 788, DateTimeKind.Local).AddTicks(3043), "", new DateTime(2020, 8, 17, 18, 51, 49, 787, DateTimeKind.Local).AddTicks(2853) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion", "PasswordRecovery", "TimeExpired" },
                values: new object[] { "17/08/2020 6:51:49 PM", new DateTime(2020, 8, 17, 18, 51, 49, 793, DateTimeKind.Local).AddTicks(8830), new DateTime(2020, 8, 17, 18, 51, 49, 793, DateTimeKind.Local).AddTicks(8837), "", new DateTime(2020, 8, 17, 18, 51, 49, 793, DateTimeKind.Local).AddTicks(8811) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion", "PasswordRecovery", "TimeExpired" },
                values: new object[] { "17/08/2020 6:51:49 PM", new DateTime(2020, 8, 17, 18, 51, 49, 793, DateTimeKind.Local).AddTicks(9756), new DateTime(2020, 8, 17, 18, 51, 49, 793, DateTimeKind.Local).AddTicks(9757), "", new DateTime(2020, 8, 17, 18, 51, 49, 793, DateTimeKind.Local).AddTicks(9755) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 794, DateTimeKind.Local).AddTicks(7970), new DateTime(2020, 8, 17, 18, 51, 49, 794, DateTimeKind.Local).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 794, DateTimeKind.Local).AddTicks(9451), new DateTime(2020, 8, 17, 18, 51, 49, 794, DateTimeKind.Local).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 794, DateTimeKind.Local).AddTicks(9468), new DateTime(2020, 8, 17, 18, 51, 49, 794, DateTimeKind.Local).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3873), new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3876) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3915), new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3916) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3918), new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3919) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3921), new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3921) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3923), new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3924) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3925), new DateTime(2020, 8, 17, 18, 51, 49, 795, DateTimeKind.Local).AddTicks(3926) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordRecovery",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TimeExpired",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "PasswordGenerators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPor = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EsNulo = table.Column<bool>(nullable: false),
                    FakePassWord = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    TimeExpire = table.Column<DateTime>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
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
                values: new object[] { "8/15/2020 4:16:11 PM", new DateTime(2020, 8, 15, 16, 16, 11, 132, DateTimeKind.Local).AddTicks(209), new DateTime(2020, 8, 15, 16, 16, 11, 132, DateTimeKind.Local).AddTicks(4871) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "8/15/2020 4:16:11 PM", new DateTime(2020, 8, 15, 16, 16, 11, 135, DateTimeKind.Local).AddTicks(9443), new DateTime(2020, 8, 15, 16, 16, 11, 135, DateTimeKind.Local).AddTicks(9451) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FechaCreacion", "FechaModificacion" },
                values: new object[] { "8/15/2020 4:16:11 PM", new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(8), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(8) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(3820), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(4515), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(4522) });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(4528), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(4529) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6294), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6296) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6321), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6322) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6323), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6324) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6325), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6325) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6326), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6327) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoID",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6328), new DateTime(2020, 8, 15, 16, 16, 11, 136, DateTimeKind.Local).AddTicks(6328) });
        }
    }
}
