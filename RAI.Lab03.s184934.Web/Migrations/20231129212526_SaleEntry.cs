using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAI.Lab03.s184934.Web.Migrations
{
    /// <inheritdoc />
    public partial class SaleEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<uint>(type: "INTEGER", nullable: false),
                    WaterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SaleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleEntry_MineralWaters_WaterId",
                        column: x => x.WaterId,
                        principalTable: "MineralWaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleEntry_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterMagazine",
                columns: table => new
                {
                    WaterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterMagazine", x => x.WaterId);
                    table.ForeignKey(
                        name: "FK_WaterMagazine_MineralWaters_WaterId",
                        column: x => x.WaterId,
                        principalTable: "MineralWaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleEntry_SaleId",
                table: "SaleEntry",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleEntry_WaterId",
                table: "SaleEntry",
                column: "WaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleEntry");

            migrationBuilder.DropTable(
                name: "WaterMagazine");
        }
    }
}
