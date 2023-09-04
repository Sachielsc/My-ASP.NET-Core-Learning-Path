using DemoWebApiProject.DbContexts;
using DemoWebApiProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApiProject.Services
{
    public class GameProgressRepository : IGameProgressRepository
    {
        private readonly GameProgressContext _gameProgressContext;

        public GameProgressRepository(GameProgressContext gameProgressContext)
        {
            _gameProgressContext = gameProgressContext ?? throw new ArgumentNullException(nameof(gameProgressContext));
        }

        public async Task<IEnumerable<GameProgress>> GetGameProgressesAsync()
        {
            return await _gameProgressContext.GameProgresses.OrderBy(g => g.Name)
                .Include(g => g.GameProgressOnPlatforms)
                .ToListAsync();
        }

        public async Task<GameProgress?> GetGameProgressAsync(int gameId)
        {
            return await _gameProgressContext.GameProgresses.Include(g => g.GameProgressOnPlatforms)
                .Where(g => g.GameId == gameId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GameProgressOnPlatform>> GetGameProgressesOnPlatformsAsync(int gameId)
        {
            return await _gameProgressContext.GameProgressOnPlatforms
                .Where(g => g.GameId == gameId)
                .ToListAsync();
        }

        public async Task<GameProgressOnPlatform?> GetGameProgressOnPlatformAsync(int gameId, int gameProgressOnThisPlatformId)
        {
            return await _gameProgressContext.GameProgressOnPlatforms
                .Where(g => g.GameId == gameId && g.GameProgressOnThisPlatformId == gameProgressOnThisPlatformId)
                .FirstOrDefaultAsync();
        }

        // Not used. This should be implemented as a filter/search feature.
        // Btw, in the controller folder, 2 controller methods with the same name will cause an error
        //public async Task<GameProgressOnPlatform?> GetGameProgressOnPlatformAsync(int gameId, string platformName)
        //{
        //    return await _gameProgressContext.GameProgressOnPlatforms
        //        .Where(g => g.GameId == gameId && g.Platform == platformName)
        //        .FirstOrDefaultAsync();
        //}

        public async Task AddProgressOnPlatformAsync(int gameId, GameProgressOnPlatform gameProgressOnPlatform)
        {
            var gameProgress = await GetGameProgressAsync(gameId);
            if (gameProgress != null)
            {
                gameProgress.GameProgressOnPlatforms.Add(gameProgressOnPlatform);
                await ApplyDbContextChangeToDatabaseAsync();
            }
        }

        public async Task AddProgressOnPlatformAsync(GameProgressOnPlatform gameProgressOnPlatform)
        {
            int gameId = gameProgressOnPlatform.GameId;
            var gameProgress = await GetGameProgressAsync(gameId);
            if (gameProgress != null)
            {
                gameProgress.GameProgressOnPlatforms.Add(gameProgressOnPlatform);
                await ApplyDbContextChangeToDatabaseAsync();
            }
        }

        public async Task<int> ApplyDbContextChangeToDatabaseAsync()
        {
            return await _gameProgressContext.SaveChangesAsync();
        }

        public async Task<bool> GameExistsAsync(int gameId)
        {
            return await _gameProgressContext.GameProgresses.AnyAsync(g => g.GameId == gameId);
        }

        public async Task<bool> GameProgressOnPlatformExistsAsync(int gameId, string platformName)
        {
            return await _gameProgressContext.GameProgressOnPlatforms.AnyAsync(g => g.GameId == gameId && g.Platform == platformName);
        }

        public async Task<bool> GameProgressOnPlatformExistsAsync(int gameId, int gameProgressOnPlatformId)
        {
            return await _gameProgressContext.GameProgressOnPlatforms.AnyAsync(g => g.GameId == gameId && g.GameProgressOnThisPlatformId == gameProgressOnPlatformId);
        }
    }
}
