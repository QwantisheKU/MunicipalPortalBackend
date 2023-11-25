using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MunicipalPortalBackend.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationStatusAndDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_MunicipalDepartment_MunicipalBranchId",
                table: "Application");

            migrationBuilder.RenameColumn(
                name: "MunicipalBranchId",
                table: "Application",
                newName: "MunicipalDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_MunicipalBranchId",
                table: "Application",
                newName: "IX_Application_MunicipalDepartmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "MunicipalDepartmentReview",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ApplicationComplaint",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Application",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationStatus_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationStatus_ApplicationId",
                table: "ApplicationStatus",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_MunicipalDepartment_MunicipalDepartmentId",
                table: "Application",
                column: "MunicipalDepartmentId",
                principalTable: "MunicipalDepartment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_MunicipalDepartment_MunicipalDepartmentId",
                table: "Application");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "MunicipalDepartmentReview");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ApplicationComplaint");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Application");

            migrationBuilder.RenameColumn(
                name: "MunicipalDepartmentId",
                table: "Application",
                newName: "MunicipalBranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_MunicipalDepartmentId",
                table: "Application",
                newName: "IX_Application_MunicipalBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_MunicipalDepartment_MunicipalBranchId",
                table: "Application",
                column: "MunicipalBranchId",
                principalTable: "MunicipalDepartment",
                principalColumn: "Id");
        }
    }
}
