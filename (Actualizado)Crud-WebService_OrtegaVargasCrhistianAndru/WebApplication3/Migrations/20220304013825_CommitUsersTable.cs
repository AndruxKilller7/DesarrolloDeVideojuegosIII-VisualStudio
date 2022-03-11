using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class CommitUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "CellPhone",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gmail",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Gmail",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
