using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parus_test_khokhlov.Migrations
{
    /// <inheritdoc />
    public partial class base_init_vol_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_Project_taskId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_Project_taskId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ProjectTaskId",
                table: "Comments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProjectTaskId",
                table: "Comments",
                column: "ProjectTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_ProjectTaskId",
                table: "Comments",
                column: "ProjectTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_ProjectTaskId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProjectTaskId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Project_taskId",
                table: "Comments",
                column: "Project_taskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_Project_taskId",
                table: "Comments",
                column: "Project_taskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
