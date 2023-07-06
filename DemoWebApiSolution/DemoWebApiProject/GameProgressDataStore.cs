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
                    EnglishName = "Mental Omega",
                    Description = "红警2最好的资料片没有之一。单线剧情完整严谨，兵种与剧情挂钩。高难度下的关卡有焕然一新的设计。科技树与种族特性相结合。多达四个族都有完整战役，而且还有额外战役，联机合作战役等。模式极其丰富"
                },
                new GameProgressDto()
                {
                    Id = 2,
                    Name = "tormented souls",
                    ChineseName = "折磨之魂",
                    GameProgressOnPlatformDtos = new List<GameProgressOnPlatformDto>()
                    {
                        new GameProgressOnPlatformDto() {
                            Platform = "PC",
                            ProgressOnThisPlatform = "修改器修改了存档磁带数量通关，在游戏末期才入手隐藏武器"
                        }
                    },
                    Description = "很优秀的老生化型作品"
                }
            };
        }
    }
}
