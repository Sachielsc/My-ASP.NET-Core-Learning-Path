using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTheSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GameProgresses",
                columns: new[] { "GameId", "ChineseName", "Description", "EnglishName", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "心灵终结", "红警2最好的资料片没有之一。单线剧情完整严谨，兵种与剧情挂钩。高难度下的关卡有焕然一新的设计。科技树与种族特性相结合。多达四个族都有完整战役，而且还有额外战役，联机合作战役等。模式极其丰富", "Mental Omega", "心灵终结 Mental Omega", 2022 },
                    { 2, "折磨之魂", "很优秀的老生化型作品", null, "tormented souls", 2022 },
                    { 3, "暗黑破坏神2重制版", "童年经典的完美重现\n而且现在还在更新平衡性补丁以及新内容", null, "暗黑破坏神2重制版 D2R", 2022 }
                });

            migrationBuilder.InsertData(
                table: "GameProgressOnPlatforms",
                columns: new[] { "GameProgressOnThisPlatformId", "BugsAndIssues", "GameId", "Platform", "ProgressOnThisPlatform", "RecommendedMouseSpeed" },
                values: new object[,]
                {
                    { 1, null, 2, "PC", "修改器修改了存档磁带数量通关，在游戏末期才入手隐藏武器", "Undecided mouse speed" },
                    { 2, "坑爹的暴雪大幅下调了暴率", 3, "PC", "联机模式下七职业慢慢交易以及慢慢刷\r\n单机模式下普通模式正在打造最强配置，硬核模式下考虑导入极品黄以及老版本暗金进行娱乐", "Undecided mouse speed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameProgressOnPlatforms",
                keyColumn: "GameProgressOnThisPlatformId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameProgressOnPlatforms",
                keyColumn: "GameProgressOnThisPlatformId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameProgresses",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameProgresses",
                keyColumn: "GameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameProgresses",
                keyColumn: "GameId",
                keyValue: 3);
        }
    }
}
