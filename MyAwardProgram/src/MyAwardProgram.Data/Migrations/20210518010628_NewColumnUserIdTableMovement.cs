using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAwardProgram.Data.Migrations
{
    public partial class NewColumnUserIdTableMovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Movement_TB_User_UserId",
                table: "TB_Movement");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TB_Movement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Movement_TB_User_UserId",
                table: "TB_Movement",
                column: "UserId",
                principalTable: "TB_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Movement_TB_User_UserId",
                table: "TB_Movement");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TB_Movement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Movement_TB_User_UserId",
                table: "TB_Movement",
                column: "UserId",
                principalTable: "TB_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
