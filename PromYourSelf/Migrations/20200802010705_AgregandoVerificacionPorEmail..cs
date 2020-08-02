using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class AgregandoVerificacionPorEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeValidation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeValidation", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 1, 21, 7, 5, 176, DateTimeKind.Local).AddTicks(5267), new DateTime(2020, 8, 1, 21, 7, 5, 177, DateTimeKind.Local).AddTicks(2829) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeValidation");

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 7, 30, 21, 53, 20, 43, DateTimeKind.Local).AddTicks(1650), new DateTime(2020, 7, 30, 21, 53, 20, 44, DateTimeKind.Local).AddTicks(4190) });
        }
    }
}
