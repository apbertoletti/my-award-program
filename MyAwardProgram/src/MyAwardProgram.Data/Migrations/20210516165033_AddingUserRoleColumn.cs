using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAwardProgram.Data.Migrations
{
    public partial class AddingUserRoleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "TB_User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "TB_User");
        }
    }
}
