using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391_Project.Migrations.Diamond
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diamond",
                columns: table => new
                {
                    DiamondId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clarity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fluorescence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symmetry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Polish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CutGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diamond", x => x.DiamondId);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: true),
                    DayUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiamondId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_Price_Diamond_DiamondId",
                        column: x => x.DiamondId,
                        principalTable: "Diamond",
                        principalColumn: "DiamondId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Price_DiamondId",
                table: "Price",
                column: "DiamondId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Diamond");
        }
    }
}
