using Microsoft.EntityFrameworkCore.Migrations;

namespace TPPweb2122.Migrations
{
    public partial class RelacoesRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_AspNetUsers_userId",
                table: "Imoveis");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Imoveis",
                newName: "gestorId");

            migrationBuilder.RenameIndex(
                name: "IX_Imoveis_userId",
                table: "Imoveis",
                newName: "IX_Imoveis_gestorId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gestorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Morada", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Telefone", "TwoFactorEnabled", "UserName" },
                values: new object[] { 4, 0, "f9b0e09e-ee83-4bba-ae43-8922f7d0c99a", "Utilizador", "admin@airbnb.com", true, true, null, null, null, "ADMIN@AIRBNB.COM", "ADMIN@AIRBNB.COM", "AQAAAAEAACcQAAAAELtoW4blr7viRgbfmp53rcp9Q4ZEJ3Jrm/r9du1lH6CKBOLUPB+WpR3zJmcKzuNmEg==", null, false, "dc2ece6a-34a7-4f2e-ab27-f1cc562d8dda", null, false, "admin@airbnb.com" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_gestorId",
                table: "AspNetUsers",
                column: "gestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_gestorId",
                table: "AspNetUsers",
                column: "gestorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_AspNetUsers_gestorId",
                table: "Imoveis",
                column: "gestorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_gestorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_AspNetUsers_gestorId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_gestorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Morada",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "gestorId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "gestorId",
                table: "Imoveis",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Imoveis_gestorId",
                table: "Imoveis",
                newName: "IX_Imoveis_userId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87d573a7-d8ed-4a78-8dc3-0f45cefe1769", "AQAAAAEAACcQAAAAEOpvfez9wLSMsmXeGgbr+fxLSN5lIAsEUQEwpCRLpAW2gDgrgvdYkA23A2u3pz12LQ==", "f786487d-d1b2-4b49-a14d-40defb737dfe" });

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_AspNetUsers_userId",
                table: "Imoveis",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
