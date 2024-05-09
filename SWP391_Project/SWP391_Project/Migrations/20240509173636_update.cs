using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWP391_Project.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diamond",
                columns: table => new
                {
                    DiamondID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clarity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fluorescence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symmetry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Polish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CutGrade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CutScore = table.Column<double>(type: "float", nullable: false),
                    ClarityCharacteristic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diamond", x => x.DiamondID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestValuationForm",
                columns: table => new
                {
                    RequestValuationFormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestValuationForm", x => x.RequestValuationFormID);
                    table.ForeignKey(
                        name: "FK_RequestValuationForm_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleForm",
                columns: table => new
                {
                    ScheduleFormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultStaffID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestValuationFormID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleForm", x => x.ScheduleFormID);
                    table.ForeignKey(
                        name: "FK_ScheduleForm_RequestValuationForm_RequestValuationFormID",
                        column: x => x.RequestValuationFormID,
                        principalTable: "RequestValuationForm",
                        principalColumn: "RequestValuationFormID");
                    table.ForeignKey(
                        name: "FK_ScheduleForm_User_ConsultStaffID",
                        column: x => x.ConsultStaffID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleForm_User_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestValuationForm_ServiceID",
                table: "RequestValuationForm",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleForm_ConsultStaffID",
                table: "ScheduleForm",
                column: "ConsultStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleForm_CustomerID",
                table: "ScheduleForm",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleForm_RequestValuationFormID",
                table: "ScheduleForm",
                column: "RequestValuationFormID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diamond");

            migrationBuilder.DropTable(
                name: "ScheduleForm");

            migrationBuilder.DropTable(
                name: "RequestValuationForm");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
