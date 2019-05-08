using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Evaluation_3.Migrations
{
    public partial class changeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Stakeholders_StakeHolderID",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_StakeHolderID",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "StakeHolderID",
                table: "Evaluations");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationID",
                table: "Stakeholders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholders_EvaluationID",
                table: "Stakeholders",
                column: "EvaluationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stakeholders_Evaluations_EvaluationID",
                table: "Stakeholders",
                column: "EvaluationID",
                principalTable: "Evaluations",
                principalColumn: "EvaluationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stakeholders_Evaluations_EvaluationID",
                table: "Stakeholders");

            migrationBuilder.DropIndex(
                name: "IX_Stakeholders_EvaluationID",
                table: "Stakeholders");

            migrationBuilder.DropColumn(
                name: "EvaluationID",
                table: "Stakeholders");

            migrationBuilder.AddColumn<int>(
                name: "StakeHolderID",
                table: "Evaluations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StakeHolderID",
                table: "Evaluations",
                column: "StakeHolderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Stakeholders_StakeHolderID",
                table: "Evaluations",
                column: "StakeHolderID",
                principalTable: "Stakeholders",
                principalColumn: "StakeholderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
