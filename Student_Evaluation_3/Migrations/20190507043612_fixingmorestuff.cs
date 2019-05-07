using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class fixingmorestuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Evaluations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Evaluations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
