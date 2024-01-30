using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parus_test_khokhlov.Migrations
{
    /// <inheritdoc />
    public partial class base_init_vol_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Comments",
                newName: "Project_taskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                newName: "IX_Comments_Project_taskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_Project_taskId",
                table: "Comments",
                column: "Project_taskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_Project_taskId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Project_taskId",
                table: "Comments",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Project_taskId",
                table: "Comments",
                newName: "IX_Comments_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
