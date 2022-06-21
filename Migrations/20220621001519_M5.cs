using Microsoft.EntityFrameworkCore.Migrations;

namespace Concord_Cougars_Course_Project.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Coachs_CoachId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_CoachId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_LessonId",
                table: "Sessions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Lessons_LessonId",
                table: "Sessions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Lessons_LessonId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_LessonId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CoachId",
                table: "Lessons",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Coachs_CoachId",
                table: "Lessons",
                column: "CoachId",
                principalTable: "Coachs",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
