using DemoWebApiProject.Entities;
using DemoWebApiProject.Models;

namespace DemoWebApiProject.Utilities
{
    public static class ControllerHelper
    {
        public static string ControllerHelperDemoMethod(int input1, int input2) => (input1 + input2).ToString();

        public static List<GameProgressDto> MannualMapperFromGameProgressEntityToDto(IEnumerable<GameProgress> entities)
        {
            var dtoList = new List<GameProgressDto>();
            foreach (var entity in entities)
            {
                dtoList.Add(new GameProgressDto
                {
                    Id = entity.GameId
                    ,Name = entity.Name
                    ,ChineseName = entity.ChineseName
                    ,EnglishName = entity.EnglishName
                    ,Description = entity.Description
                    ,GameProgressOnPlatforms = MannualMapperFromGameProgressOnPlatformEntityToDto(entity.GameProgressOnPlatforms)
                });
            }
            return dtoList;
        }

        public static List<GameProgressOnPlatformDto> MannualMapperFromGameProgressOnPlatformEntityToDto(IEnumerable<GameProgressOnPlatform> entities)
        {
            var dtoList = new List<GameProgressOnPlatformDto>();
            foreach (var entity in entities)
            {
                dtoList.Add(new GameProgressOnPlatformDto
                {
                    Id = entity.GameProgressOnThisPlatformId
                    ,Platform = entity.Platform
                    ,RecommendedMouseSpeed = entity.RecommendedMouseSpeed
                    ,BugsAndIssues = entity.BugsAndIssues
                    ,ProgressOnThisPlatform = entity.ProgressOnThisPlatform
                });
            }
            return dtoList;
        }
    }
}
