using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class godhatessql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "GroupAssignments",
                newName: "FacultyGroupID");

            migrationBuilder.AddColumn<int>(
                name: "GroupAssignmentID",
                table: "FacultyGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupAssignmentID",
                table: "Users",
                column: "GroupAssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyGroups_GroupAssignmentID",
                table: "FacultyGroups",
                column: "GroupAssignmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyGroups_GroupAssignments_GroupAssignmentID",
                table: "FacultyGroups",
                column: "GroupAssignmentID",
                principalTable: "GroupAssignments",
                principalColumn: "GroupAssignmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupAssignments_GroupAssignmentID",
                table: "Users",
                column: "GroupAssignmentID",
                principalTable: "GroupAssignments",
                principalColumn: "GroupAssignmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacultyGroups_GroupAssignments_GroupAssignmentID",
                table: "FacultyGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupAssignments_GroupAssignmentID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupAssignmentID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_FacultyGroups_GroupAssignmentID",
                table: "FacultyGroups");

            migrationBuilder.DropColumn(
                name: "GroupAssignmentID",
                table: "FacultyGroups");

            migrationBuilder.RenameColumn(
                name: "FacultyGroupID",
                table: "GroupAssignments",
                newName: "GroupID");
        }
    }
}
