using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftLog.Migrations
{
    /// <inheritdoc />
    public partial class NextMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutProgramId",
                table: "Sets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sets_WorkoutProgramId",
                table: "Sets",
                column: "WorkoutProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_WorkoutPrograms_WorkoutProgramId",
                table: "Sets",
                column: "WorkoutProgramId",
                principalTable: "WorkoutPrograms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_WorkoutPrograms_WorkoutProgramId",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Sets_WorkoutProgramId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "WorkoutProgramId",
                table: "Sets");
        }
    }
}
