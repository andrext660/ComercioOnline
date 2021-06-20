using Microsoft.EntityFrameworkCore.Migrations;

namespace ComercioOnline.Repositorio.Migrations
{
    public partial class CorreçaoAtributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EhAdministrado",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "EhAdministrador",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EhAdministrador",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "EhAdministrado",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
