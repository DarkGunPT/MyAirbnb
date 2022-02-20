using Microsoft.EntityFrameworkCore.Migrations;

namespace TPPweb2122.Migrations
{
    public partial class Avaliacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_AspNetUsers_ClienteId",
                table: "Reserva");

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PontuacaoAvaliacao = table.Column<int>(type: "int", nullable: false),
                    DescricaoAvaliacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImovelId = table.Column<int>(type: "int", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_AspNetUsers_clienteId",
                        column: x => x.clienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Imoveis_ImovelId",
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
                values: new object[] { "64d2d733-0d83-43da-9e9f-3b7af3faf7dd", "AQAAAAEAACcQAAAAEBMEbPy77RNVP3uJzgMMyNXTglUeN58rhIw9LSue/tItgWt/HcQj5ATLrRV1n8kTPw==", "e091186b-e645-45cc-869e-6e12368eb791" });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_clienteId",
                table: "Avaliacoes",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ImovelId",
                table: "Avaliacoes",
                column: "ImovelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_AspNetUsers_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_AspNetUsers_ClienteId",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "426b3f08-e990-4c8d-bfc1-11a350138d77", "AQAAAAEAACcQAAAAEFjGMOTNCi+vMB78gzCV3yHmDe37usXUFeDz+PQYKFlcRSO9BYzRXBHcoj4npfxZHw==", "c103c12d-ad5c-4183-8783-fc59ffefaeac" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_AspNetUsers_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
