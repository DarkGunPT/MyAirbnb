using Microsoft.EntityFrameworkCore.Migrations;

namespace TPPweb2122.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "083cff70-8f97-4de3-a5a9-dfeb06018c4c", "AQAAAAEAACcQAAAAEMpAsyH3rkFkstWjURA45i+8XY1k5HTiWO+eT8OW1WBY9TOFkJ6oa3fo7Sfs116SuA==", "454b8f81-f684-4920-a0b3-94111c694d0f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72cdbc68-50c0-4e8a-b3f7-2c3478dc5a6b", "AQAAAAEAACcQAAAAEOmnmtLxBSnc3sTK2hQDcZ40pNskHw0xSmG7bR13BybrHWlblYJ/BVNQFCI/fw7yUQ==", "e1a28468-1d88-4653-b2de-a10a7301b092" });
        }
    }
}
