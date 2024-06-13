using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class createAppDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateStatus",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Result");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiveDay",
                table: "Order",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ReceiveDay",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "CertificateStatus",
                table: "Result",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Result",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Result",
                type: "datetime2",
                nullable: true);
        }
    }
}
