using DemoWebApiProject.DbContexts;
using DemoWebApiProject.Entities;
using DemoWebApiProject.Services;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApiProject.Repositories
{
    public class GameProgressRepository : IGameProgressRepository
    {
        private readonly GameProgressContext _gameProgressContext;
        private readonly IDummyCustomizedServices _dummyCustomizedServices;

        public GameProgressRepository(GameProgressContext gameProgressContext, IDummyCustomizedServices dummyCustomizedServices)
        {
            _gameProgressContext = gameProgressContext ?? throw new ArgumentNullException(nameof(gameProgressContext));
            _dummyCustomizedServices = dummyCustomizedServices;

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
        public async Task<GameProgressOnPlatform?> GetGameProgressOnPlatformAsync(int gameId, string platformName)
        {
            return await _gameProgressContext.GameProgressOnPlatforms
                .Where(g => g.GameId == gameId && g.Platform == platformName)
                .FirstOrDefaultAsync();
        }

        public async Task AddProgressOnPlatformAsync(GameProgressOnPlatform gameProgressOnPlatform)
        {
            await AddProgressOnPlatformAsync(gameProgressOnPlatform.GameId, gameProgressOnPlatform);
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

        public async Task<bool> GameProgressOnPlatformExistsAsync(int gameProgressOnThisPlatformId)
        {
            return await _gameProgressContext.GameProgressOnPlatforms.AnyAsync(g => g.GameProgressOnThisPlatformId == gameProgressOnThisPlatformId);
        }

        public async Task DeleteProgressOnPlatformAsync(int gameProgressOnPlatformId)
        {
            GameProgressOnPlatform? gameProgressOnPlatformToBeRemoved = await GetGameProgressOnPlatformAsync(gameProgressOnPlatformId);
            if (gameProgressOnPlatformToBeRemoved != null)
            {
                _gameProgressContext.GameProgressOnPlatforms.Remove(gameProgressOnPlatformToBeRemoved);
                await ApplyDbContextChangeToDatabaseAsync();
                _dummyCustomizedServices.Send("Progress on platform deleted!", $"The game progress with a gameProgressOnPlatformId {gameProgressOnPlatformId} has been deleted!");
            }
        }

        private async Task<int> ApplyDbContextChangeToDatabaseAsync()
        {
            return await _gameProgressContext.SaveChangesAsync();
        }

        // Not used. As I don't want to use gameId as another parameter
        private async Task AddProgressOnPlatformAsync(int gameId, GameProgressOnPlatform gameProgressOnPlatform)
        {
            var gameProgress = await GetGameProgressAsync(gameId);
            if (gameProgress != null)
            {
                gameProgress.GameProgressOnPlatforms.Add(gameProgressOnPlatform);
                await ApplyDbContextChangeToDatabaseAsync();
            }
        }

        private async Task<GameProgressOnPlatform?> GetGameProgressOnPlatformAsync(int gameProgressOnThisPlatformId)
        {
            return await _gameProgressContext.GameProgressOnPlatforms
                .Where(g => g.GameProgressOnThisPlatformId == gameProgressOnThisPlatformId)
                .FirstOrDefaultAsync();
        }
    }
}
