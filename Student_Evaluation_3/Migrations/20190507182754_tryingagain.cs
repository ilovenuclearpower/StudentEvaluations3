using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class tryingagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_InstructorUserID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_Student_UserID1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Student_UserID1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_InstructorUserID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Student_UserID1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstructorUserID",
                table: "Enrollments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Student_UserID1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorUserID",
                table: "Enrollments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Student_UserID1",
                table: "Users",
                column: "Student_UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_InstructorUserID",
                table: "Enrollments",
                column: "InstructorUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_InstructorUserID",
                table: "Enrollments",
                column: "InstructorUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_Student_UserID1",
                table: "Users",
                column: "Student_UserID1",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
