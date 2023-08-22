using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTheSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GameProgressOnPlatforms",
                keyColumn: "GameProgressOnThisPlatformId",
                keyValue: 2,
                column: "ProgressOnThisPlatform",
                value: "联机模式下七职业慢慢交易以及慢慢刷\n单机模式下普通模式正在打造最强配置，硬核模式下考虑导入极品黄以及老版本暗金进行娱乐");

            migrationBuilder.UpdateData(
                table: "GameProgresses",
                keyColumn: "GameId",
                keyValue: 3,
                column: "EnglishName",
                value: "Diablo® II: Resurrected");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GameProgressOnPlatforms",
                keyColumn: "GameProgressOnThisPlatformId",
                keyValue: 2,
                column: "ProgressOnThisPlatform",
                value: "联机模式下七职业慢慢交易以及慢慢刷\r\n单机模式下普通模式正在打造最强配置，硬核模式下考虑导入极品黄以及老版本暗金进行娱乐");

            migrationBuilder.UpdateData(
                table: "GameProgresses",
                keyColumn: "GameId",
                keyValue: 3,
                column: "EnglishName",
                value: null);
        }
    }
}
