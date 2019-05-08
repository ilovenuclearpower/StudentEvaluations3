using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class ihateazure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserID1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserID1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID1",
                table: "Users",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserID1",
                table: "Users",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
