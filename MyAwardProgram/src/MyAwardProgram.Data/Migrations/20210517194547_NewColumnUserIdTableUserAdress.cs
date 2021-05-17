using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAwardProgram.Data.Migrations
{
    public partial class NewColumnUserIdTableUserAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_UserAddress_TB_User_UserId",
                table: "TB_UserAddress");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TB_UserAddress",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_UserAddress_TB_User_UserId",
                table: "TB_UserAddress",
                column: "UserId",
                principalTable: "TB_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_UserAddress_TB_User_UserId",
                table: "TB_UserAddress");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TB_UserAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_UserAddress_TB_User_UserId",
                table: "TB_UserAddress",
                column: "UserId",
                principalTable: "TB_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
