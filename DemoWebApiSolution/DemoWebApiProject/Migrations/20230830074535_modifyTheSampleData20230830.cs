using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class modifyTheSampleData20230830 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GameProgressOnPlatforms",
                keyColumn: "GameProgressOnThisPlatformId",
                keyValue: 2,
                column: "ProgressOnThisPlatform",
                value: "联机模式下七职业慢慢交易以及慢慢刷。单机模式下普通模式正在打造最强配置，硬核模式下考虑导入极品黄以及老版本暗金进行娱乐");

            migrationBuilder.UpdateData(
                table: "GameProgresses",
                keyColumn: "GameId",
                keyValue: 3,
                column: "Description",
                value: "童年经典的完美重现。而且现在还在更新平衡性补丁以及新内容");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "Description",
                value: "童年经典的完美重现\n而且现在还在更新平衡性补丁以及新内容");
        }
    }
}
