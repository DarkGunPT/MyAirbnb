using Microsoft.EntityFrameworkCore.Migrations;

namespace TPPweb2122.Migrations
{
    public partial class SeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87d573a7-d8ed-4a78-8dc3-0f45cefe1769", "AQAAAAEAACcQAAAAEOpvfez9wLSMsmXeGgbr+fxLSN5lIAsEUQEwpCRLpAW2gDgrgvdYkA23A2u3pz12LQ==", "f786487d-d1b2-4b49-a14d-40defb737dfe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12473b27-5466-49ab-9b51-73e6cf393dfa", "AQAAAAEAACcQAAAAEL4ddVfvYFPDOy6Jq36lg4ngYO+MluLlynK17DX9i6r5fSsM/Oi7QfXpm+0gh2qU3Q==", "59bcb561-d6d5-4819-bced-a35d1e60ee78" });
        }
    }
}
