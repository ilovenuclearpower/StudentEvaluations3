using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class maybesomeday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupAssignments_GroupAssignmentID",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupAssignments_GroupAssignmentID",
                table: "Users",
                column: "GroupAssignmentID",
                principalTable: "GroupAssignments",
                principalColumn: "GroupAssignmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupAssignments_GroupAssignmentID",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupAssignments_GroupAssignmentID",
                table: "Users",
                column: "GroupAssignmentID",
                principalTable: "GroupAssignments",
                principalColumn: "GroupAssignmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
