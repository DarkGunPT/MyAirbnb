using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TPPweb2122.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81ee9110-1e73-45bb-b8c4-5a6f7893c1bb", "AQAAAAEAACcQAAAAECulFETGG5pbwOH1jfyiW46Y7296BVPPl1NXbTd01BxZVvbyWR7z947UfJIGqWdogA==", "6ad1cbf1-0afd-4724-854c-99481a3b2cfa" });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ImovelId",
                table: "Reserva",
                column: "ImovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9b0e09e-ee83-4bba-ae43-8922f7d0c99a", "AQAAAAEAACcQAAAAELtoW4blr7viRgbfmp53rcp9Q4ZEJ3Jrm/r9du1lH6CKBOLUPB+WpR3zJmcKzuNmEg==", "dc2ece6a-34a7-4f2e-ab27-f1cc562d8dda" });
        }
    }
}
