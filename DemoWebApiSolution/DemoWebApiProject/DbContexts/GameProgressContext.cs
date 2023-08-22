using DemoWebApiProject.Entities;
using DemoWebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApiProject.DbContexts
{
    public class GameProgressContext : DbContext
    {
        public DbSet<GameProgress> GameProgresses { get; set; }
        public DbSet<GameProgressOnPlatform> GameProgressOnPlatforms { get; set; }

        public GameProgressContext(DbContextOptions<GameProgressContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameProgress>().HasData(
                new GameProgress() {
                    GameId = 1,
                    Name = "心灵终结 Mental Omega",
                    ChineseName = "心灵终结",
                    EnglishName = "Mental Omega",
                    Description = "红警2最好的资料片没有之一。单线剧情完整严谨，兵种与剧情挂钩。高难度下的关卡有焕然一新的设计。科技树与种族特性相结合。多达四个族都有完整战役，而且还有额外战役，联机合作战役等。模式极其丰富",
                    Year = 2022
                },
                new GameProgress() {
                    GameId = 2,
                    Name = "tormented souls",
                    ChineseName = "折磨之魂",
                    Description = "很优秀的老生化型作品",
                    Year = 2022
                },
                new GameProgress() {
                    GameId = 3,
                    Name = "暗黑破坏神2重制版 D2R",
                    ChineseName = "暗黑破坏神2重制版",
                    Description = "童年经典的完美重现\n而且现在还在更新平衡性补丁以及新内容",
                    Year = 2022
                }
                );
            modelBuilder.Entity<GameProgressOnPlatform>().HasData(
                new GameProgressOnPlatform() {
                    GameProgressOnThisPlatformId = 1,
                    GameId = 2,
                    Platform = "PC",
                    ProgressOnThisPlatform = "修改器修改了存档磁带数量通关，在游戏末期才入手隐藏武器"
                },
                new GameProgressOnPlatform() {
                    GameProgressOnThisPlatformId = 2,
                    GameId = 3,
                    Platform = "PC",
                    ProgressOnThisPlatform = "联机模式下七职业慢慢交易以及慢慢刷\r\n单机模式下普通模式正在打造最强配置，硬核模式下考虑导入极品黄以及老版本暗金进行娱乐",
                    BugsAndIssues = "坑爹的暴雪大幅下调了暴率"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
