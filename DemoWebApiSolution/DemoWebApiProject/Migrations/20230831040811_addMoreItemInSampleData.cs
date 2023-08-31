using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class addMoreItemInSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GameProgressOnPlatforms",
                columns: new[] { "GameProgressOnThisPlatformId", "BugsAndIssues", "GameId", "Platform", "ProgressOnThisPlatform", "RecommendedMouseSpeed" },
                values: new object[] { 3, "Nintendo Switch平台的画质真的差，优化不敢想象", 3, "Nintendo Switch", "有趣的地方在于，Nintendo Switch平台和PC平台共用暴雪账户，因此战网游戏存档是共通的。然而Nintendo Switch平台需要开通会员才能进行线上游戏", "Undecided mouse speed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameProgressOnPlatforms",
                keyColumn: "GameProgressOnThisPlatformId",
                keyValue: 3);
        }
    }
}
