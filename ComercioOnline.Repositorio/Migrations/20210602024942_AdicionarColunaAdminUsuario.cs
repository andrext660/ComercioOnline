using Microsoft.EntityFrameworkCore.Migrations;

namespace ComercioOnline.Repositorio.Migrations
{
    public partial class AdicionarColunaAdminUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EhAdministrado",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EhAdministrado",
                table: "Usuarios");
        }
    }
}
