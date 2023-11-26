using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAI.Lab03.s184934.Web.Migrations
{
    /// <inheritdoc />
    public partial class SalesDeliveriesPalletes : Migration
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
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<uint>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
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
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfPallets = table.Column<uint>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    User = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Companies_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SizeOfPallet = table.Column<uint>(type: "INTEGER", nullable: false),
                    WaterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pallets_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pallets_MineralWaters_WaterId",
                        column: x => x.WaterId,
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
                name: "IX_Deliveries_SupplierId",
                table: "Deliveries",
                column: "SupplierId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_DeliveryId",
                table: "Pallets",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_WaterId",
                table: "Pallets",
                column: "WaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnionMineralWater");

            migrationBuilder.DropTable(
                name: "CationMineralWater");

            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Ion");

            migrationBuilder.DropTable(
                name: "Deliveries");

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
