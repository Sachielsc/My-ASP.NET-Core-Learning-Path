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
            return await _gameProgressContext.GameProgresses.ToListAsync();
        }
        public Task<GameProgress?> GetGameProgressAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameProgressOnPlatform>> GetGameProgressesOnPlatformsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GameProgressOnPlatform?> GetGameProgressOnPlatformAsync(int gameId, int gameProgressOnThisPlatformId)
        {
            throw new NotImplementedException();
        }
    }
}
