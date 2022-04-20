using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCrudGame.Migrations
{
    public partial class Sel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Pasword",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "damage",
                table: "ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "devilHunterRank",
                table: "ranks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "itemUse",
                table: "ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "orbs",
                table: "ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rankBonus",
                table: "ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "stylishPTS",
                table: "ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "time",
                table: "ranks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pasword",
                table: "users");

            migrationBuilder.DropColumn(
                name: "damage",
                table: "ranks");

            migrationBuilder.DropColumn(
                name: "devilHunterRank",
                table: "ranks");

            migrationBuilder.DropColumn(
                name: "itemUse",
                table: "ranks");

            migrationBuilder.DropColumn(
                name: "orbs",
                table: "ranks");

            migrationBuilder.DropColumn(
                name: "rankBonus",
                table: "ranks");

            migrationBuilder.DropColumn(
                name: "stylishPTS",
                table: "ranks");

            migrationBuilder.DropColumn(
                name: "time",
                table: "ranks");

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
