using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class forrealthistime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Instructors_InstructorID",
                table: "Enrollment");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_InstructorID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Enrollment");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StakeholderID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Student_CourseID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Student_DepartmentID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_PhoneNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Student_UserID1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorUserID",
                table: "Enrollment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StakeholderID",
                table: "Users",
                column: "StakeholderID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Student_CourseID",
                table: "Users",
                column: "Student_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Student_DepartmentID",
                table: "Users",
                column: "Student_DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Student_UserID1",
                table: "Users",
                column: "Student_UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_InstructorUserID",
                table: "Enrollment",
                column: "InstructorUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Users_InstructorUserID",
                table: "Enrollment",
                column: "InstructorUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stakeholders_StakeholderID",
                table: "Users",
                column: "StakeholderID",
                principalTable: "Stakeholders",
                principalColumn: "StakeholderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Courses_Student_CourseID",
                table: "Users",
                column: "Student_CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Department_Student_DepartmentID",
                table: "Users",
                column: "Student_DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_Student_UserID1",
                table: "Users",
                column: "Student_UserID1",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Users_InstructorUserID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stakeholders_StakeholderID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Courses_Student_CourseID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Department_Student_DepartmentID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_Student_UserID1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StakeholderID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Student_CourseID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Student_DepartmentID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Student_UserID1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_InstructorUserID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StakeholderID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Student_CourseID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Student_DepartmentID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Student_PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Student_UserID1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstructorUserID",
                table: "Enrollment");

            migrationBuilder.AddColumn<string>(
                name: "InstructorID",
                table: "Enrollment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorID = table.Column<string>(nullable: false),
                    CourseID = table.Column<int>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    StakeholderID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Stakeholders_StakeholderID",
                        column: x => x.StakeholderID,
                        principalTable: "Stakeholders",
                        principalColumn: "StakeholderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_InstructorID",
                table: "Enrollment",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CourseID",
                table: "Instructors",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentID",
                table: "Instructors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_StakeholderID",
                table: "Instructors",
                column: "StakeholderID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserID",
                table: "Instructors",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Instructors_InstructorID",
                table: "Enrollment",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "InstructorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
