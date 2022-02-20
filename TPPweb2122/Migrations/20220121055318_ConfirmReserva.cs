using Microsoft.EntityFrameworkCore.Migrations;

namespace TPPweb2122.Migrations
{
    public partial class ConfirmReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmacao",
                table: "Reserva",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "426b3f08-e990-4c8d-bfc1-11a350138d77", "AQAAAAEAACcQAAAAEFjGMOTNCi+vMB78gzCV3yHmDe37usXUFeDz+PQYKFlcRSO9BYzRXBHcoj4npfxZHw==", "c103c12d-ad5c-4183-8783-fc59ffefaeac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmacao",
                table: "Reserva");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "083cff70-8f97-4de3-a5a9-dfeb06018c4c", "AQAAAAEAACcQAAAAEMpAsyH3rkFkstWjURA45i+8XY1k5HTiWO+eT8OW1WBY9TOFkJ6oa3fo7Sfs116SuA==", "454b8f81-f684-4920-a0b3-94111c694d0f" });
        }
    }
}
