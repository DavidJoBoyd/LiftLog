using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftLog.Migrations
{
    /// <inheritdoc />
    public partial class NextMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_WorkoutPrograms_WorkoutProgramId",
                table: "Sets");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_WorkoutPrograms_WorkoutProgramId",
                table: "Sets",
                column: "WorkoutProgramId",
                principalTable: "WorkoutPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_WorkoutPrograms_WorkoutProgramId",
                table: "Sets");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_WorkoutPrograms_WorkoutProgramId",
                table: "Sets",
                column: "WorkoutProgramId",
                principalTable: "WorkoutPrograms",
                principalColumn: "Id");
        }
    }
}
