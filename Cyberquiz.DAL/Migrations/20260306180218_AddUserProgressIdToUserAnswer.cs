using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberquiz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProgressIdToUserAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProgressId",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_UserProgressId",
                table: "UserAnswers",
                column: "UserProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserProgress_UserProgressId",
                table: "UserAnswers",
                column: "UserProgressId",
                principalTable: "UserProgress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserProgress_UserProgressId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_UserProgressId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "UserProgressId",
                table: "UserAnswers");
        }
    }
}
