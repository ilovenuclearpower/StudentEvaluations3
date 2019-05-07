using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class tryagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_CourseID",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Evaluations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Evaluations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_CourseID",
                table: "Evaluations",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
