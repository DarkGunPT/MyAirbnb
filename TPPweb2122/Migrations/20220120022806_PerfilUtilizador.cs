using Microsoft.EntityFrameworkCore.Migrations;

namespace TPPweb2122.Migrations
{
    public partial class PerfilUtilizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Morada", "Nome", "PasswordHash", "SecurityStamp", "Telefone" },
                values: new object[] { "72cdbc68-50c0-4e8a-b3f7-2c3478dc5a6b", "454", "344", "AQAAAAEAACcQAAAAEOmnmtLxBSnc3sTK2hQDcZ40pNskHw0xSmG7bR13BybrHWlblYJ/BVNQFCI/fw7yUQ==", "e1a28468-1d88-4653-b2de-a10a7301b092", "945" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Morada", "Nome", "PasswordHash", "SecurityStamp", "Telefone" },
                values: new object[] { "3e00f522-3665-42a8-9bf5-da27f07bcce7", "", "", "AQAAAAEAACcQAAAAEJ4NHqRTxWBW/Y7HMyp2mV6tWKDfm7Ln6PVPwsvntARvPso41/TdnOaE7U70mx+5NQ==", "614057f5-ffdc-4138-97a1-ed013854be76", "" });
        }
    }
}
