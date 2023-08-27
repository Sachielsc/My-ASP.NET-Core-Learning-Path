using DemoWebApiProject.Entities;

namespace DemoWebApiProject.Services
{
    public interface IGameProgressRepository
    {
        Task<IEnumerable<GameProgress>> GetGameProgressesAsync();
        Task<GameProgress?> GetGameProgressAsync(int gameId);
        Task<IEnumerable<GameProgressOnPlatform>> GetGameProgressesOnPlatformsAsync(int gameId);
        Task<GameProgressOnPlatform?> GetGameProgressOnPlatformAsync(int gameId, int gameProgressOnThisPlatformId);
    }
}
