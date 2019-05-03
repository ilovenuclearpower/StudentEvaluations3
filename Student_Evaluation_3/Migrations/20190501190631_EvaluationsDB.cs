using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class EvaluationsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    UserID1 = table.Column<int>(nullable: true),
                    StudentID = table.Column<int>(nullable: true),
                    GraduationYear = table.Column<DateTime>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<int>(nullable: true),
                    CourseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    instructorUserID = table.Column<int>(nullable: true),
                    CourseID = table.Column<int>(nullable: true),
                    why_course = table.Column<string>(nullable: true),
                    hours_week = table.Column<string>(nullable: true),
                    life_connection = table.Column<string>(nullable: true),
                    grade = table.Column<string>(nullable: true),
                    clear_goals = table.Column<string>(nullable: true),
                    helpful_assignments = table.Column<string>(nullable: true),
                    reading_helpful = table.Column<string>(nullable: true),
                    relevant_materials = table.Column<string>(nullable: true),
                    challenged_learn = table.Column<string>(nullable: true),
                    clear_syllabus = table.Column<string>(nullable: true),
                    instructor_prepared = table.Column<string>(nullable: true),
                    instructor_knowledgeable = table.Column<string>(nullable: true),
                    effective_teaching = table.Column<string>(nullable: true),
                    timely_manner = table.Column<string>(nullable: true),
                    suggested_improvement = table.Column<string>(nullable: true),
                    grading_fair = table.Column<string>(nullable: true),
                    enthusiastic_teaching = table.Column<string>(nullable: true),
                    concern_understanding = table.Column<string>(nullable: true),
                    instructor_interaction = table.Column<string>(nullable: true),
                    different_views = table.Column<string>(nullable: true),
                    student_improved = table.Column<string>(nullable: true),
                    successful_in = table.Column<string>(nullable: true),
                    good_because = table.Column<string>(nullable: true),
                    improved_by = table.Column<string>(nullable: true),
                    good_job = table.Column<string>(nullable: true),
                    teaching_improved = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_Users_instructorUserID",
                        column: x => x.instructorUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: true),
                    InstructorID = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: true),
                    DepartmentID = table.Column<int>(nullable: true)
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
                        name: "FK_Instructors_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    InstructorID = table.Column<int>(nullable: false),
                    InstructorID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Instructors_InstructorID1",
                        column: x => x.InstructorID1,
                        principalTable: "Instructors",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_InstructorID1",
                table: "Enrollment",
                column: "InstructorID1");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_CourseID",
                table: "Evaluations",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_instructorUserID",
                table: "Evaluations",
                column: "instructorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CourseID",
                table: "Instructors",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentID",
                table: "Instructors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserID",
                table: "Instructors",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CourseID",
                table: "Users",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentID",
                table: "Users",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID1",
                table: "Users",
                column: "UserID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
