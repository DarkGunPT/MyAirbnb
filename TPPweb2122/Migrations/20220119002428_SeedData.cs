using Microsoft.EntityFrameworkCore.Migrations;

namespace TPPweb2122.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "1", "Admin", "ADMIN" },
                    { 2, "2", "Gestor", "GESTOR" },
                    { 3, "3", "Funcionario", "FUNCIONARIO" },
                    { 4, "4", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 4, 0, "12473b27-5466-49ab-9b51-73e6cf393dfa", "admin@airbnb.com", true, true, null, "ADMIN@AIRBNB.COM", "ADMIN@AIRBNB.COM", "AQAAAAEAACcQAAAAEL4ddVfvYFPDOy6Jq36lg4ngYO+MluLlynK17DX9i6r5fSsM/Oi7QfXpm+0gh2qU3Q==", null, false, "59bcb561-d6d5-4819-bced-a35d1e60ee78", false, "admin@airbnb.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_userId",
                table: "Imoveis",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_AspNetUsers_userId",
                table: "Imoveis",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_AspNetUsers_userId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_userId",
                table: "Imoveis");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Imoveis");
        }
    }
}
