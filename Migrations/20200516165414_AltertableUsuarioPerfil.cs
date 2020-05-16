using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class AltertableUsuarioPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Perfil",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
