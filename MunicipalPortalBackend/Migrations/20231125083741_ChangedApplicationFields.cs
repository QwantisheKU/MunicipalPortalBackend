using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalPortalBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedApplicationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Category_CategoryId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Application");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Application",
                newName: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Application",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Category_CategoryId",
                table: "Application",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Category_CategoryId",
                table: "Application");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Application",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Application",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Application",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Category_CategoryId",
                table: "Application",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
