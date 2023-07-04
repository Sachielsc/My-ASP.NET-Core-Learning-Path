using DemoWebApiProject.Models;

namespace DemoWebApiProject
{
    public class GameProgressDataStore
    {
        public List<GameProgressDto> GameProgresses { get; set; }
        public static GameProgressDataStore Instance { get; } = new GameProgressDataStore(); // this is a "singleton pattern"

        public GameProgressDataStore()
        {
            // initiate dummy data
            GameProgresses = new List<GameProgressDto>() {
                new GameProgressDto()
                {
                    Id = 1,
                    Name = "心灵终结 Mental Omega",
                    ChineseName = "心灵终结",
                    EnglishName = "Mental Omega"
                },
                new GameProgressDto()
                {
                    Id = 2,
                    Name = "tormented souls",
                    ChineseName = "折磨之魂",
                    EnglishName = "tormented souls"
                }
            };
        }
    }
}
