using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTest.Models.Migrations
{
    /// <inheritdoc />
    public partial class fkChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_UserNavigationId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_UserNavigationId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "UserNavigationId",
                table: "Tests");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CreatedBy",
                table: "Tests",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_CreatedBy",
                table: "Tests",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_CreatedBy",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_CreatedBy",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "UserNavigationId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserNavigationId",
                table: "Tests",
                column: "UserNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_UserNavigationId",
                table: "Tests",
                column: "UserNavigationId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
