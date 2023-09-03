using DemoWebApiProject.Entities;

namespace DemoWebApiProject.Services
{
    public interface IGameProgressRepository
    {
        Task<IEnumerable<GameProgress>> GetGameProgressesAsync();
        Task<GameProgress?> GetGameProgressAsync(int gameId);
        Task<IEnumerable<GameProgressOnPlatform>> GetGameProgressesOnPlatformsAsync(int gameId);
        Task<GameProgressOnPlatform?> GetGameProgressOnPlatformAsync(int gameId, int gameProgressOnThisPlatformId);
        Task<bool> GameExistsAsync(int gameId);
        Task<bool> GameProgressOnPlatformExistsAsync(int gameId, int gameProgressOnPlatformId);
        Task<bool> GameProgressOnPlatformExistsAsync(int gameId, string platformName);

        // Not used. This should be implemented as a filter/search feature.
        // Btw, in the controller folder, 2 controller methods with the same name will cause an error
        // Task<GameProgressOnPlatform?> GetGameProgressOnPlatformAsync(int gameId, string platformName);
    }
}
