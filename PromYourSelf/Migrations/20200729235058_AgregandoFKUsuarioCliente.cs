using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class AgregandoFKUsuarioCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_AspNetUsers_UsuariosId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_UsuariosId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Ventas");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioClienteID",
                table: "Ventas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 7, 29, 19, 50, 58, 579, DateTimeKind.Local).AddTicks(2853), new DateTime(2020, 7, 29, 19, 50, 58, 580, DateTimeKind.Local).AddTicks(1257) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioClienteID",
                table: "Ventas");

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Ventas",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Negocios",
                keyColumn: "NegocioID",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2020, 7, 25, 16, 1, 48, 643, DateTimeKind.Local).AddTicks(1459), new DateTime(2020, 7, 25, 16, 1, 48, 643, DateTimeKind.Local).AddTicks(9408) });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuariosId",
                table: "Ventas",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_AspNetUsers_UsuariosId",
                table: "Ventas",
                column: "UsuariosId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
