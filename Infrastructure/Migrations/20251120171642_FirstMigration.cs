using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TiposProdutoInvestimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProdutoInvestimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoInvestimento",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoProdutoInvestimento = table.Column<long>(type: "bigint", nullable: false),
                    PrazoMinimoMeses = table.Column<int>(type: "int", nullable: false),
                    PrazoMaximoMeses = table.Column<int>(type: "int", nullable: false),
                    Rentabilidade = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Risco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoInvestimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoInvestimento_TiposProdutoInvestimentos_IdTipoProdutoInvestimento",
                        column: x => x.IdTipoProdutoInvestimento,
                        principalTable: "TiposProdutoInvestimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoInvestimento_IdTipoProdutoInvestimento",
                schema: "dbo",
                table: "ProdutoInvestimento",
                column: "IdTipoProdutoInvestimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoInvestimento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TiposProdutoInvestimentos");
        }
    }
}
