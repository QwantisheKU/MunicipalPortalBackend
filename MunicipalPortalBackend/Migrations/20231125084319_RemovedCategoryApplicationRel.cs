using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalPortalBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCategoryApplicationRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Category_CategoryId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_CategoryId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Application");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Application",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_CategoryId",
                table: "Application",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Category_CategoryId",
                table: "Application",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
