using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapStore.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_usuario_senha_permissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Passaword",
                table: "User",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Permission",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passaword",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");
        }
    }
}
