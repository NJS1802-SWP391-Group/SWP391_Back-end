using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations.Diamond
{
    public partial class CreateDiamond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diamond",
                columns: table => new
                {
                    DiamondId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carat = table.Column<double>(type: "float", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clarity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fluorescence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symmetry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Polish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CutGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diamond", x => x.DiamondId);
                });

            migrationBuilder.CreateTable(
                name: "DiamondCheck",
                columns: table => new
                {
                    DiamondCheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carat = table.Column<double>(type: "float", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clarity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fluorescence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symmetry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Polish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CutGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CutScore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClarityCharacteristic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiamondCheck", x => x.DiamondCheckId);
                });

            migrationBuilder.CreateTable(
                name: "DiamondCheckValue",
                columns: table => new
                {
                    DiamondCheckValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdateDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DiamondCheckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiamondCheckValue", x => x.DiamondCheckValueId);
                    table.ForeignKey(
                        name: "FK_DiamondCheckValue_DiamondCheck_DiamondCheckId",
                        column: x => x.DiamondCheckId,
                        principalTable: "DiamondCheck",
                        principalColumn: "DiamondCheckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiamondCheckValue_DiamondCheckId",
                table: "DiamondCheckValue",
                column: "DiamondCheckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diamond");

            migrationBuilder.DropTable(
                name: "DiamondCheckValue");

            migrationBuilder.DropTable(
                name: "DiamondCheck");
        }
    }
}
