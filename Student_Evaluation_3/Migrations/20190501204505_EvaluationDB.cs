using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class EvaluationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Instructors_InstructorID1",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Users_StudentID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_InstructorID1",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "InstructorID1",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StakeholderID",
                table: "Instructors",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstructorID",
                table: "Enrollment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentID",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stakeholders",
                columns: table => new
                {
                    StakeholderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable: false),
                    InstructorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stakeholders", x => x.StakeholderID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EnrollmentID",
                table: "Users",
                column: "EnrollmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_StakeholderID",
                table: "Instructors",
                column: "StakeholderID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_InstructorID",
                table: "Enrollment",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EnrollmentID",
                table: "Courses",
                column: "EnrollmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Enrollment_EnrollmentID",
                table: "Courses",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "EnrollmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Instructors_InstructorID",
                table: "Enrollment",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "InstructorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Stakeholders_StakeholderID",
                table: "Instructors",
                column: "StakeholderID",
                principalTable: "Stakeholders",
                principalColumn: "StakeholderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Enrollment_EnrollmentID",
                table: "Users",
                column: "EnrollmentID",
                principalTable: "Enrollment",
                principalColumn: "EnrollmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Enrollment_EnrollmentID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Instructors_InstructorID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Stakeholders_StakeholderID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Enrollment_EnrollmentID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Stakeholders");

            migrationBuilder.DropIndex(
                name: "IX_Users_EnrollmentID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_StakeholderID",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_InstructorID",
                table: "Enrollment");

            migrationBuilder.DropIndex(
                name: "IX_Courses_EnrollmentID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EnrollmentID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StakeholderID",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "EnrollmentID",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorID",
                table: "Enrollment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorID1",
                table: "Enrollment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_InstructorID1",
                table: "Enrollment",
                column: "InstructorID1");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Instructors_InstructorID1",
                table: "Enrollment",
                column: "InstructorID1",
                principalTable: "Instructors",
                principalColumn: "InstructorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Users_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
