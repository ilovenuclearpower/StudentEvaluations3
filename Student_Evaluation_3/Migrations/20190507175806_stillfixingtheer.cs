using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class stillfixingtheer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EvaluationID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Evaluations",
                newName: "StakeHolderID");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_StudentID",
                table: "Evaluations",
                newName: "IX_Evaluations_StakeHolderID");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Evaluations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentID",
                table: "Evaluations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_EnrollmentID",
                table: "Evaluations",
                column: "EnrollmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Enrollments_EnrollmentID",
                table: "Evaluations",
                column: "EnrollmentID",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Stakeholders_StakeHolderID",
                table: "Evaluations",
                column: "StakeHolderID",
                principalTable: "Stakeholders",
                principalColumn: "StakeholderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Enrollments_EnrollmentID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Stakeholders_StakeHolderID",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_EnrollmentID",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "EnrollmentID",
                table: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "StakeHolderID",
                table: "Evaluations",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluations_StakeHolderID",
                table: "Evaluations",
                newName: "IX_Evaluations_StudentID");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationID",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Evaluations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Users_EvaluationID",
                table: "Users",
                column: "EvaluationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Courses_CourseID",
                table: "Evaluations",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);

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
    }
}
