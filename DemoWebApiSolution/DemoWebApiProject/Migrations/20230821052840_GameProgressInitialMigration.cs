using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class GameProgressInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameProgresses",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ChineseName = table.Column<string>(type: "TEXT", nullable: true),
                    EnglishName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProgresses", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "GameProgressOnPlatforms",
                columns: table => new
                {
                    GameProgressOnThisPlatformId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Platform = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RecommendedMouseSpeed = table.Column<string>(type: "TEXT", nullable: false),
                    ProgressOnThisPlatform = table.Column<string>(type: "TEXT", nullable: true),
                    BugsAndIssues = table.Column<string>(type: "TEXT", nullable: true),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProgressOnPlatforms", x => x.GameProgressOnThisPlatformId);
                    table.ForeignKey(
                        name: "FK_GameProgressOnPlatforms_GameProgresses_GameId",
                        column: x => x.GameId,
                        principalTable: "GameProgresses",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameProgressOnPlatforms_GameId",
                table: "GameProgressOnPlatforms",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameProgressOnPlatforms");

            migrationBuilder.DropTable(
                name: "GameProgresses");
        }
    }
}
