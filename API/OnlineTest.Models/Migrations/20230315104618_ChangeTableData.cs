using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTest.Models.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Users_CreatedBy",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Users_ModifiedBy",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_CreatedBy",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_CreatedBy",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_CreatedBy",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_ModifiedBy",
                table: "Technologies");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Tests",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "datetime",
                nullable: false
                );

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Tests",
                newName: "CreatedTime");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CreatedBy",
                table: "Tests",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_CreatedBy",
                table: "Technologies",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_ModifiedBy",
                table: "Technologies",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Users_CreatedBy",
                table: "Technologies",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Users_ModifiedBy",
                table: "Technologies",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_CreatedBy",
                table: "Tests",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
