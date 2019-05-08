using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class hihihi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Stakeholders",
                newName: "GroupID");

            migrationBuilder.AddColumn<int>(
                name: "FacultyGroupID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupAssignments",
                columns: table => new
                {
                    GroupAssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstructorID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAssignments", x => x.GroupAssignmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupAssignments");

            migrationBuilder.DropColumn(
                name: "FacultyGroupID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "Stakeholders",
                newName: "InstructorID");
        }
    }
}
