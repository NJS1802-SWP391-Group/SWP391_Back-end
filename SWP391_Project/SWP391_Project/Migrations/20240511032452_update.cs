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
                name: "DiamondPrice",
                columns: table => new
                {
                    DiamondPriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiamondID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiamondPrice", x => x.DiamondPriceID);
                    table.ForeignKey(
                        name: "FK_DiamondPrice_Diamond_DiamondID",
                        column: x => x.DiamondID,
                        principalTable: "Diamond",
                        principalColumn: "DiamondID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Blog",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blog_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
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

            migrationBuilder.CreateTable(
                name: "ValuationReceipts",
                columns: table => new
                {
                    ValuationReceiptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValuationStaffID = table.Column<int>(type: "int", nullable: false),
                    ConsultStaffID = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleFormID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationReceipts", x => x.ValuationReceiptID);
                    table.ForeignKey(
                        name: "FK_ValuationReceipts_ScheduleForm_ScheduleFormID",
                        column: x => x.ScheduleFormID,
                        principalTable: "ScheduleForm",
                        principalColumn: "ScheduleFormID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValuationReceipts_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValuationReceipts_User_ConsultStaffID",
                        column: x => x.ConsultStaffID,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationReceipts_User_ValuationStaffID",
                        column: x => x.ValuationStaffID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ValuationResult",
                columns: table => new
                {
                    ValuationResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiamondID = table.Column<int>(type: "int", nullable: false),
                    ValuationReceiptID = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValuationStaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationResult", x => x.ValuationResultID);
                    table.ForeignKey(
                        name: "FK_ValuationResult_Diamond_DiamondID",
                        column: x => x.DiamondID,
                        principalTable: "Diamond",
                        principalColumn: "DiamondID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValuationResult_User_ValuationStaffID",
                        column: x => x.ValuationStaffID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValuationResult_ValuationReceipts_ValuationReceiptID",
                        column: x => x.ValuationReceiptID,
                        principalTable: "ValuationReceipts",
                        principalColumn: "ValuationReceiptID");
                });

            migrationBuilder.CreateTable(
                name: "FinalReceipt",
                columns: table => new
                {
                    FinalReceiptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValuationResultID = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalReceipt", x => x.FinalReceiptID);
                    table.ForeignKey(
                        name: "FK_FinalReceipt_ValuationResult_ValuationResultID",
                        column: x => x.ValuationResultID,
                        principalTable: "ValuationResult",
                        principalColumn: "ValuationResultID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserID",
                table: "Blog",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DiamondPrice_DiamondID",
                table: "DiamondPrice",
                column: "DiamondID");

            migrationBuilder.CreateIndex(
                name: "IX_FinalReceipt_ValuationResultID",
                table: "FinalReceipt",
                column: "ValuationResultID");

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

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReceipts_ConsultStaffID",
                table: "ValuationReceipts",
                column: "ConsultStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReceipts_ScheduleFormID",
                table: "ValuationReceipts",
                column: "ScheduleFormID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReceipts_ServiceID",
                table: "ValuationReceipts",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReceipts_ValuationStaffID",
                table: "ValuationReceipts",
                column: "ValuationStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationResult_DiamondID",
                table: "ValuationResult",
                column: "DiamondID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationResult_ValuationReceiptID",
                table: "ValuationResult",
                column: "ValuationReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationResult_ValuationStaffID",
                table: "ValuationResult",
                column: "ValuationStaffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "DiamondPrice");

            migrationBuilder.DropTable(
                name: "FinalReceipt");

            migrationBuilder.DropTable(
                name: "ValuationResult");

            migrationBuilder.DropTable(
                name: "Diamond");

            migrationBuilder.DropTable(
                name: "ValuationReceipts");

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
