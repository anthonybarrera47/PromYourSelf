using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromYourSelf.Migrations
{
    public partial class cita_productoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitasDetalle");

            migrationBuilder.AddColumn<int>(
                name: "ProductoID",
                table: "Citas",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoID",
                table: "Citas");

            migrationBuilder.CreateTable(
                name: "CitasDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    CitaID = table.Column<int>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitasDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CitasDetalle_Citas_CitaID",
                        column: x => x.CitaID,
                        principalTable: "Citas",
                        principalColumn: "CitaID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CitasDetalle_CitaID",
                table: "CitasDetalle",
                column: "CitaID");
        }
    }
}
