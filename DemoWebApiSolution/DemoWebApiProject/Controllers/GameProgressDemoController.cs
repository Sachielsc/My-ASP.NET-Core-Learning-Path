using DemoWebApiProject.Entities;
using DemoWebApiProject.MockData;
using DemoWebApiProject.Models;
using DemoWebApiProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    [Route("api/gameprogresses")]
    public class GameProgressDemoController : ControllerBase
    {
        private readonly ILogger<GameProgressDemoController> _logger;
        private readonly IGameProgressRepository _gameProgressRepository; // DI here, thus this has to be an interface, not a class

        public GameProgressDemoController(ILogger<GameProgressDemoController> logger, IGameProgressRepository gameProgressRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameProgressRepository = gameProgressRepository ?? throw new ArgumentNullException(nameof(gameProgressRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameProgressDto>>> GetAllGameProgresses()
        {
            var entityResult = await _gameProgressRepository.GetGameProgressesAsync();
            var dtoResult = MannualMapperFromGameProgressEntityToDto(entityResult);
            return Ok(dtoResult);
        }

        // Some manual object mapping methods
        private List<GameProgressDto> MannualMapperFromGameProgressEntityToDto(IEnumerable<GameProgress> entities) {
            var dtoResult = new List<GameProgressDto>();
            foreach (var entity in entities)
            {
                dtoResult.Add(new GameProgressDto
                {
                    Id = entity.GameId
                    ,Name = entity.Name
                    ,ChineseName = entity.ChineseName
                    ,EnglishName = entity.EnglishName
                    ,Description = entity.Description
                    ,GameProgressOnPlatforms = MannualMapperFromGameProgressOnPlatformEntityToDto(entity.GameProgressOnPlatforms)
                });
            }
            return dtoResult;
        }

        private List<GameProgressOnPlatformDto> MannualMapperFromGameProgressOnPlatformEntityToDto ( IEnumerable<GameProgressOnPlatform> entities ) {
            var dtoResult = new List<GameProgressOnPlatformDto>();
            foreach ( var entity in entities )
            {
                dtoResult.Add(new GameProgressOnPlatformDto
                {
                    Id = entity.GameProgressOnThisPlatformId,
                    Platform = entity.Platform,
                    RecommendedMouseSpeed = entity.RecommendedMouseSpeed,
                    BugsAndIssues = entity.BugsAndIssues,
                    ProgressOnThisPlatform = entity.ProgressOnThisPlatform
                });
            }
            return dtoResult;
        }

        /*
        [HttpGet("{id}")]
        public ActionResult<GameProgressDto> GetASpecificGameProgress(int id)
        {
            try {
                // throw new Exception("Sample exception ...");
                var gameProgressToReturn = _gameProgressRepository.GameProgresses.FirstOrDefault(
    c => c.Id == id
    );
                if (gameProgressToReturn == null)
                {
                    _logger.LogInformation($"The city with city id {id} cannot be found ... ");
                    return NotFound();
                }
                else return Ok(gameProgressToReturn);
            }
            catch (Exception ex) {
                _logger.LogCritical($"Exception detected while getting the city with id {id}.\nException content: ", ex);
                return StatusCode(500, "Only this message will be returned to the consumer as the API implementation details should not be exposed. ");
            }
        }

        [HttpGet("{id}/gameprogressesonplatform")]
        public ActionResult<IEnumerable<GameProgressOnPlatformDto>> GetAllGameProgressesOfASpecificGame(int id)
        {
            var gameProgressToReturn = _gameProgressRepository.GameProgresses.FirstOrDefault(
                c => c.Id == id
                );
            if (gameProgressToReturn == null) { return NotFound(); }
            else return Ok(gameProgressToReturn.GameProgressOnPlatforms);
        }

        [HttpGet("{id}/gameprogressesonplatform/{platformName}")]
        public ActionResult<GameProgressOnPlatformDto> GetASpecificGameProgressOfASpecificGame(int id, string platformName)
        {
            var gameProgressToReturn = _gameProgressRepository.GameProgresses.FirstOrDefault(c => c.Id == id);
            if (gameProgressToReturn == null) { return NotFound(); }
            else
            {
                var gameProgressOnPlatformToReturn = gameProgressToReturn.GameProgressOnPlatforms.FirstOrDefault(c => c.Platform == platformName);
                if (gameProgressOnPlatformToReturn == null) { return NotFound(); }
                else
                    return gameProgressOnPlatformToReturn;
            }
        }
        */
    }
}
