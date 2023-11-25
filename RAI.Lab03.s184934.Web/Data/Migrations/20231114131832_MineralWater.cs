using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAI.Lab03.s184934.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class MineralWater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packaging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Volume = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packaging", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MineralWaters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProducerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Ph = table.Column<float>(type: "REAL", nullable: false),
                    PackagingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MineralWaters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MineralWaters_Companies_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MineralWaters_Packaging_PackagingId",
                        column: x => x.PackagingId,
                        principalTable: "Packaging",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MineralWaters_WaterTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "WaterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnionMineralWater",
                columns: table => new
                {
                    AnionsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MineralWaterId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnionMineralWater", x => new { x.AnionsId, x.MineralWaterId });
                    table.ForeignKey(
                        name: "FK_AnionMineralWater_Ion_AnionsId",
                        column: x => x.AnionsId,
                        principalTable: "Ion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnionMineralWater_MineralWaters_MineralWaterId",
                        column: x => x.MineralWaterId,
                        principalTable: "MineralWaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CationMineralWater",
                columns: table => new
                {
                    CationsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MineralWaterId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CationMineralWater", x => new { x.CationsId, x.MineralWaterId });
                    table.ForeignKey(
                        name: "FK_CationMineralWater_Ion_CationsId",
                        column: x => x.CationsId,
                        principalTable: "Ion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CationMineralWater_MineralWaters_MineralWaterId",
                        column: x => x.MineralWaterId,
                        principalTable: "MineralWaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnionMineralWater_MineralWaterId",
                table: "AnionMineralWater",
                column: "MineralWaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CationMineralWater_MineralWaterId",
                table: "CationMineralWater",
                column: "MineralWaterId");

            migrationBuilder.CreateIndex(
                name: "IX_MineralWaters_PackagingId",
                table: "MineralWaters",
                column: "PackagingId");

            migrationBuilder.CreateIndex(
                name: "IX_MineralWaters_ProducerId",
                table: "MineralWaters",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_MineralWaters_TypeId",
                table: "MineralWaters",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnionMineralWater");

            migrationBuilder.DropTable(
                name: "CationMineralWater");

            migrationBuilder.DropTable(
                name: "Ion");

            migrationBuilder.DropTable(
                name: "MineralWaters");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Packaging");

            migrationBuilder.DropTable(
                name: "WaterTypes");
        }
    }
}
