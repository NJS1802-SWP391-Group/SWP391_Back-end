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
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clarity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fluorescence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symmetry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Polish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CutGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CutScore = table.Column<double>(type: "float", nullable: true),
                    ClarityCharacteristic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diamond", x => x.DiamondID);
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestValuationForm", x => x.RequestValuationFormID);
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
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Blog",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Diamond_ValuationStaff",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValuationStaffID = table.Column<int>(type: "int", nullable: false),
                    DiamondID = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diamond_ValuationStaff", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Diamond_ValuationStaff_Diamond_DiamondID",
                        column: x => x.DiamondID,
                        principalTable: "Diamond",
                        principalColumn: "DiamondID");
                    table.ForeignKey(
                        name: "FK_Diamond_ValuationStaff_User_ValuationStaffID",
                        column: x => x.ValuationStaffID,
                        principalTable: "User",
                        principalColumn: "Id");
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
                    ConsultStaffID = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleFormID = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_ValuationReceipts_User_ConsultStaffID",
                        column: x => x.ConsultStaffID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ValuationReceiptDetails",
                columns: table => new
                {
                    ValuationReceiptDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiamondID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    ValuationReceiptID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatePrice = table.Column<double>(type: "float", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationReceiptDetails", x => x.ValuationReceiptDetailID);
                    table.ForeignKey(
                        name: "FK_ValuationReceiptDetails_Diamond_DiamondID",
                        column: x => x.DiamondID,
                        principalTable: "Diamond",
                        principalColumn: "DiamondID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValuationReceiptDetails_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValuationReceiptDetails_ValuationReceipts_ValuationReceiptID",
                        column: x => x.ValuationReceiptID,
                        principalTable: "ValuationReceipts",
                        principalColumn: "ValuationReceiptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValuationResult",
                columns: table => new
                {
                    ValuationResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValuationReceiptDetailID = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValuationStaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationResult", x => x.ValuationResultID);
                    table.ForeignKey(
                        name: "FK_ValuationResult_User_ValuationStaffID",
                        column: x => x.ValuationStaffID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValuationResult_ValuationReceiptDetails_ValuationReceiptDetailID",
                        column: x => x.ValuationReceiptDetailID,
                        principalTable: "ValuationReceiptDetails",
                        principalColumn: "ValuationReceiptDetailID");
                });

            migrationBuilder.CreateTable(
                name: "FinalReceipt",
                columns: table => new
                {
                    FinalReceiptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValuationResultID = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalReceipt", x => x.FinalReceiptID);
                    table.ForeignKey(
                        name: "FK_FinalReceipt_User_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalReceipt_ValuationResult_ValuationResultID",
                        column: x => x.ValuationResultID,
                        principalTable: "ValuationResult",
                        principalColumn: "ValuationResultID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserID",
                table: "Blog",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Diamond_ValuationStaff_DiamondID",
                table: "Diamond_ValuationStaff",
                column: "DiamondID");

            migrationBuilder.CreateIndex(
                name: "IX_Diamond_ValuationStaff_ValuationStaffID",
                table: "Diamond_ValuationStaff",
                column: "ValuationStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_DiamondPrice_DiamondID",
                table: "DiamondPrice",
                column: "DiamondID");

            migrationBuilder.CreateIndex(
                name: "IX_FinalReceipt_ManagerID",
                table: "FinalReceipt",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_FinalReceipt_ValuationResultID",
                table: "FinalReceipt",
                column: "ValuationResultID");

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
                name: "IX_ValuationReceiptDetails_DiamondID",
                table: "ValuationReceiptDetails",
                column: "DiamondID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReceiptDetails_ServiceID",
                table: "ValuationReceiptDetails",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReceiptDetails_ValuationReceiptID",
                table: "ValuationReceiptDetails",
                column: "ValuationReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReceipts_ConsultStaffID",
                table: "ValuationReceipts",
                column: "ConsultStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReceipts_ScheduleFormID",
                table: "ValuationReceipts",
                column: "ScheduleFormID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationResult_ValuationReceiptDetailID",
                table: "ValuationResult",
                column: "ValuationReceiptDetailID");

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
                name: "Diamond_ValuationStaff");

            migrationBuilder.DropTable(
                name: "DiamondPrice");

            migrationBuilder.DropTable(
                name: "FinalReceipt");

            migrationBuilder.DropTable(
                name: "ValuationResult");

            migrationBuilder.DropTable(
                name: "ValuationReceiptDetails");

            migrationBuilder.DropTable(
                name: "Diamond");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ValuationReceipts");

            migrationBuilder.DropTable(
                name: "ScheduleForm");

            migrationBuilder.DropTable(
                name: "RequestValuationForm");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
