using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroProduto.Migrations
{
    public partial class BdInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estoque = table.Column<double>(type: "double", nullable: false),
                    preco = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "codigo", "descricao", "estoque", "preco" },
                values: new object[,]
                {
                    { 1, "Caneta azul", 7.0, 1.7 },
                    { 2, "Lápis", 16.0, 0.59999999999999998 },
                    { 3, "Régua 20cm", 9.0, 3.8999999999999999 },
                    { 4, "Pct sulfite A4 c/ 100", 23.0, 9.8000000000000007 },
                    { 5, "Caneta marca texto amarela", 4.0, 5.2999999999999998 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto");
        }
    }
}
