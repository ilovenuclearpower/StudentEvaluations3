using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class UpdatedStakeHolderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StakeholderID",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StakeholderID",
                table: "Courses",
                column: "StakeholderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Stakeholders_StakeholderID",
                table: "Courses",
                column: "StakeholderID",
                principalTable: "Stakeholders",
                principalColumn: "StakeholderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Stakeholders_StakeholderID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StakeholderID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StakeholderID",
                table: "Courses");
        }
    }
}
