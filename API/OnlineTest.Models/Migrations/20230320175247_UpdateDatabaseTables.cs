using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTest.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMaps_Answers_AnswerId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMaps_Questions_QuestionId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMaps_Tests_TestId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswerMaps",
                table: "QuestionAnswerMaps");

            migrationBuilder.RenameTable(
                name: "QuestionAnswerMaps",
                newName: "QuestionAnswerMapping");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Answers",
                newName: "Ans");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswerMaps_TestId",
                table: "QuestionAnswerMapping",
                newName: "IX_QuestionAnswerMapping_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswerMaps_QuestionId",
                table: "QuestionAnswerMapping",
                newName: "IX_QuestionAnswerMapping_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswerMaps_AnswerId",
                table: "QuestionAnswerMapping",
                newName: "IX_QuestionAnswerMapping_AnswerId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Technologies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswerMapping",
                table: "QuestionAnswerMapping",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMapping_Answers_AnswerId",
                table: "QuestionAnswerMapping",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMapping_Questions_QuestionId",
                table: "QuestionAnswerMapping",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMapping_Tests_TestId",
                table: "QuestionAnswerMapping",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMapping_Answers_AnswerId",
                table: "QuestionAnswerMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMapping_Questions_QuestionId",
                table: "QuestionAnswerMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMapping_Tests_TestId",
                table: "QuestionAnswerMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswerMapping",
                table: "QuestionAnswerMapping");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Technologies");

            migrationBuilder.RenameTable(
                name: "QuestionAnswerMapping",
                newName: "QuestionAnswerMaps");

            migrationBuilder.RenameColumn(
                name: "Ans",
                table: "Answers",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswerMapping_TestId",
                table: "QuestionAnswerMaps",
                newName: "IX_QuestionAnswerMaps_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswerMapping_QuestionId",
                table: "QuestionAnswerMaps",
                newName: "IX_QuestionAnswerMaps_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswerMapping_AnswerId",
                table: "QuestionAnswerMaps",
                newName: "IX_QuestionAnswerMaps_AnswerId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswerMaps",
                table: "QuestionAnswerMaps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMaps_Answers_AnswerId",
                table: "QuestionAnswerMaps",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMaps_Questions_QuestionId",
                table: "QuestionAnswerMaps",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMaps_Tests_TestId",
                table: "QuestionAnswerMaps",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
