using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class try2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Stakeholders_StakeholderID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StakeholderID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FacultyGroupID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StakeholderID",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "FacultyGroups",
                columns: table => new
                {
                    FacultyGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true),
                    StakeholderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyGroups", x => x.FacultyGroupID);
                    table.ForeignKey(
                        name: "FK_FacultyGroups_Stakeholders_StakeholderID",
                        column: x => x.StakeholderID,
                        principalTable: "Stakeholders",
                        principalColumn: "StakeholderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacultyGroups_StakeholderID",
                table: "FacultyGroups",
                column: "StakeholderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyGroups");

            migrationBuilder.AddColumn<int>(
                name: "FacultyGroupID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StakeholderID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StakeholderID",
                table: "Users",
                column: "StakeholderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Stakeholders_StakeholderID",
                table: "Users",
                column: "StakeholderID",
                principalTable: "Stakeholders",
                principalColumn: "StakeholderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
