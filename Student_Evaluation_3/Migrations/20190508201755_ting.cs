using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class ting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "Stakeholders",
                newName: "FacultyGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FacultyGroupID",
                table: "Stakeholders",
                newName: "GroupID");
        }
    }
}
