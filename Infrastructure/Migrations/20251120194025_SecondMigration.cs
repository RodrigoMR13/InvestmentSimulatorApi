using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CREATED_AT",
                schema: "dbo",
                table: "ProdutoInvestimento",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorMaximoInvestimento",
                schema: "dbo",
                table: "ProdutoInvestimento",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorMinimoInvestimento",
                schema: "dbo",
                table: "ProdutoInvestimento",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorMaximoInvestimento",
                schema: "dbo",
                table: "ProdutoInvestimento");

            migrationBuilder.DropColumn(
                name: "ValorMinimoInvestimento",
                schema: "dbo",
                table: "ProdutoInvestimento");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "dbo",
                table: "ProdutoInvestimento",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }
    }
}
