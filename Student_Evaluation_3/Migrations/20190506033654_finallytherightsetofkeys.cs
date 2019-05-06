using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class finallytherightsetofkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Enrollment_EnrollmentID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Users_InstructorUserID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Enrollment_EnrollmentID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_InstructorUserID",
                table: "Enrollments",
                newName: "IX_Enrollments_InstructorUserID");

            migrationBuilder.AddColumn<int>(
                name: "StudentUserID",
                table: "Evaluations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "EnrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StudentUserID",
                table: "Evaluations",
                column: "StudentUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Enrollments_EnrollmentID",
                table: "Courses",
                column: "EnrollmentID",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_InstructorUserID",
                table: "Enrollments",
                column: "InstructorUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Users_StudentUserID",
                table: "Evaluations",
                column: "StudentUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Enrollments_EnrollmentID",
                table: "Users",
                column: "EnrollmentID",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Enrollments_EnrollmentID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_InstructorUserID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Users_StudentUserID",
                table: "Evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Enrollments_EnrollmentID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_StudentUserID",
                table: "Evaluations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "StudentUserID",
                table: "Evaluations");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_InstructorUserID",
                table: "Enrollment",
                newName: "IX_Enrollment_InstructorUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "EnrollmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Enrollment_EnrollmentID",
                table: "Courses",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "EnrollmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Users_InstructorUserID",
                table: "Enrollment",
                column: "InstructorUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Enrollment_EnrollmentID",
                table: "Users",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "EnrollmentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
