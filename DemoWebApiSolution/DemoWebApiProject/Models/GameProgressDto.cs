﻿namespace DemoWebApiProject.Models
{
    public class GameProgressDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ChineseName { get; set; }
        public string? EnglishName { get; set; }
        public string? Description { get; set; }
        public ICollection<GameProgressOnPlatformDto> GameProgressOnPlatforms { get; set; } = new List<GameProgressOnPlatformDto>();
    }
}
