using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAI.Lab03.s184934.Web.Migrations
{
    /// <inheritdoc />
    public partial class SaleEntryDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleEntry_MineralWaters_WaterId",
                table: "SaleEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleEntry_Sales_SaleId",
                table: "SaleEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleEntry",
                table: "SaleEntry");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "SaleEntry",
                newName: "SaleEntries");

            migrationBuilder.RenameIndex(
                name: "IX_SaleEntry_WaterId",
                table: "SaleEntries",
                newName: "IX_SaleEntries_WaterId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleEntry_SaleId",
                table: "SaleEntries",
                newName: "IX_SaleEntries_SaleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleEntries",
                table: "SaleEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleEntries_MineralWaters_WaterId",
                table: "SaleEntries",
                column: "WaterId",
                principalTable: "MineralWaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleEntries_Sales_SaleId",
                table: "SaleEntries",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleEntries_MineralWaters_WaterId",
                table: "SaleEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleEntries_Sales_SaleId",
                table: "SaleEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleEntries",
                table: "SaleEntries");

            migrationBuilder.RenameTable(
                name: "SaleEntries",
                newName: "SaleEntry");

            migrationBuilder.RenameIndex(
                name: "IX_SaleEntries_WaterId",
                table: "SaleEntry",
                newName: "IX_SaleEntry_WaterId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleEntries_SaleId",
                table: "SaleEntry",
                newName: "IX_SaleEntry_SaleId");

            migrationBuilder.AddColumn<uint>(
                name: "Quantity",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleEntry",
                table: "SaleEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleEntry_MineralWaters_WaterId",
                table: "SaleEntry",
                column: "WaterId",
                principalTable: "MineralWaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleEntry_Sales_SaleId",
                table: "SaleEntry",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
