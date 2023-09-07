namespace DemoWebApiProject.Models
{
    /// <summary>
    /// This is a game progress for a specific platform
    /// </summary>
    public class GameProgressOnPlatformDto
    {
        /// <summary>
        /// The platform name
        /// </summary>
        public string? Platform { get; set; }
        public string? RecommendedMouseSpeed { get; set; }
        public int GameProgressOnPlatformId { get; set; }
        /// <summary>
        /// The game progress
        /// </summary>
        public string? ProgressOnThisPlatform { get; set; }
        public string? BugsAndIssues { get; set; }
        public int GameId { get; set; }
    }
}
