using Microsoft.EntityFrameworkCore.Migrations;

namespace ComercioOnline.Repositorio.Migrations
{
    public partial class CargaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Descricao", "Nome", "Preco" },
                values: new object[] { 1, "Calabresa Defumada", "Calabresa", 12m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
