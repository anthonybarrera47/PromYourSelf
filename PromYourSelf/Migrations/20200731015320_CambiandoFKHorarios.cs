using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class CambiandoFKHorarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Negocios_NegociosNegocioID",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_NegociosNegocioID",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "NegociosNegocioID",
                table: "Horarios");

            migrationBuilder.AddColumn<int>(
                name: "NegociosId",
                table: "Horarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 7, 30, 21, 53, 20, 43, DateTimeKind.Local).AddTicks(1650), new DateTime(2020, 7, 30, 21, 53, 20, 44, DateTimeKind.Local).AddTicks(4190) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegociosId",
                table: "Horarios");

            migrationBuilder.AddColumn<int>(
                name: "NegociosNegocioID",
                table: "Horarios",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 7, 29, 19, 50, 58, 579, DateTimeKind.Local).AddTicks(2853), new DateTime(2020, 7, 29, 19, 50, 58, 580, DateTimeKind.Local).AddTicks(1257) });

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_NegociosNegocioID",
                table: "Horarios",
                column: "NegociosNegocioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Negocios_NegociosNegocioID",
                table: "Horarios",
                column: "NegociosNegocioID",
                principalTable: "Negocios",
                principalColumn: "NegocioID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
