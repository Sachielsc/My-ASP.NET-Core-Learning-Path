namespace DemoWebApiProject.Models
{
    public class GameProgressOnPlatformDto
    {
        public string? Platform { get; set; }
        public string? RecommendedMouseSpeed { get; set; }
        public int GameProgressOnPlatformId { get; set; }
        public string? ProgressOnThisPlatform { get; set; }
        public string? BugsAndIssues { get; set; }
        public int GameId { get; set; }
    }
}
