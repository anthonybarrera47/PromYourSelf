using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class mensaje_receptor_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensaje_AspNetUsers_ClienteId",
                table: "Mensaje");

            migrationBuilder.DropIndex(
                name: "IX_Mensaje_ClienteId",
                table: "Mensaje");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Mensaje");

            migrationBuilder.RenameColumn(
                name: "NegocioID",
                table: "Mensaje",
                newName: "ReceptorID");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmado",
                table: "ProfileViewModel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 4, 20, 39, 49, 398, DateTimeKind.Local).AddTicks(3251), new DateTime(2020, 8, 4, 20, 39, 49, 398, DateTimeKind.Local).AddTicks(8486) });

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_ReceptorID",
                table: "Mensaje",
                column: "ReceptorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensaje_AspNetUsers_ReceptorID",
                table: "Mensaje",
                column: "ReceptorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensaje_AspNetUsers_ReceptorID",
                table: "Mensaje");

            migrationBuilder.DropIndex(
                name: "IX_Mensaje_ReceptorID",
                table: "Mensaje");

            migrationBuilder.DropColumn(
                name: "Confirmado",
                table: "ProfileViewModel");

            migrationBuilder.RenameColumn(
                name: "ReceptorID",
                table: "Mensaje",
                newName: "NegocioID");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Mensaje",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 8, 1, 21, 7, 5, 176, DateTimeKind.Local).AddTicks(5267), new DateTime(2020, 8, 1, 21, 7, 5, 177, DateTimeKind.Local).AddTicks(2829) });

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_ClienteId",
                table: "Mensaje",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensaje_AspNetUsers_ClienteId",
                table: "Mensaje",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
