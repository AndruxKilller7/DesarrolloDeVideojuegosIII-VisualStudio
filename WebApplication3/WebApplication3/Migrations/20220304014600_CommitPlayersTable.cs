using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class CommitPlayersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointsXP = table.Column<int>(type: "int", nullable: false),
                    Ranking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skins = table.Column<int>(type: "int", nullable: false),
                    Achivements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Items = table.Column<int>(type: "int", nullable: false),
                    Lifes = table.Column<int>(type: "int", nullable: false),
                    CurrentStateOfProgress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.IdUser);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
