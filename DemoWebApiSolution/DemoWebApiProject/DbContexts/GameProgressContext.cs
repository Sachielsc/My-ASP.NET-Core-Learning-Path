using DemoWebApiProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApiProject.DbContexts
{
    public class GameProgressContext : DbContext
    {
        public DbSet<GameProgress> GameProgresses { get; set; }
        public DbSet<GameProgressOnPlatform> GameProgressOnPlatforms { get; set; }

        public GameProgressContext(DbContextOptions<GameProgressContext> dbContextOptions) : base(dbContextOptions) { }
    }
}
