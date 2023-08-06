using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuberMICManager.Infrastructure.DataAccess.Migrations
{
    public partial class AddMICPortfolioHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MICPortfolioHistory",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MICPortfolioHistory", x => x.RecId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MICPortfolioHistory_Category",
                table: "MICPortfolioHistory",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_MICPortfolioHistory_CreatedDate",
                table: "MICPortfolioHistory",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_MICPortfolioHistory_Key",
                table: "MICPortfolioHistory",
                column: "Key");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MICPortfolioHistory");
        }
    }
}
