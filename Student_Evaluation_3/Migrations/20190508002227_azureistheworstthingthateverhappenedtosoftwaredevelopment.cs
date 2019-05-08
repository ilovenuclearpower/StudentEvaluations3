using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class azureistheworstthingthateverhappenedtosoftwaredevelopment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Courses_CourseID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Courses_Student_CourseID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CourseID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Student_CourseID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Student_CourseID",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Student_CourseID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CourseID",
                table: "Users",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Student_CourseID",
                table: "Users",
                column: "Student_CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Courses_CourseID",
                table: "Users",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Courses_Student_CourseID",
                table: "Users",
                column: "Student_CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
