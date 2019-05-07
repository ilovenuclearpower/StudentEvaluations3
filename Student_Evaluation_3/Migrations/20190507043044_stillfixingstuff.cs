using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class stillfixingstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Users_StudentUserID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Users_instructorUserID",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_StudentUserID",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_instructorUserID",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "StudentUserID",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "instructorUserID",
                table: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Evaluations",
                newName: "EvaluationID");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationID",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Evaluations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Evaluations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EvaluationID",
                table: "Users",
                column: "EvaluationID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StudentID",
                table: "Evaluations",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Users_StudentID",
                table: "Evaluations",
                column: "StudentID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Evaluations_EvaluationID",
                table: "Users",
                column: "EvaluationID",
                principalTable: "Evaluations",
                principalColumn: "EvaluationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Users_StudentID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Evaluations_EvaluationID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EvaluationID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_StudentID",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "EvaluationID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "EvaluationID",
                table: "Evaluations",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Evaluations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StudentUserID",
                table: "Evaluations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "instructorUserID",
                table: "Evaluations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StudentUserID",
                table: "Evaluations",
                column: "StudentUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_instructorUserID",
                table: "Evaluations",
                column: "instructorUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Users_StudentUserID",
                table: "Evaluations",
                column: "StudentUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Users_instructorUserID",
                table: "Evaluations",
                column: "instructorUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
