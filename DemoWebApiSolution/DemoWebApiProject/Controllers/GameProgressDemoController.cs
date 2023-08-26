using DemoWebApiProject.MockData;
using DemoWebApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    [Route("api/gameprogresses")]
    public class GameProgressDemoController : ControllerBase
    {
        private readonly ILogger<GameProgressDemoController> _logger;
        private readonly GameProgressDataStore _gameProgressDataStore;
        public GameProgressDemoController(ILogger<GameProgressDemoController> logger, GameProgressDataStore gameProgressDataStore)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameProgressDataStore = gameProgressDataStore ?? throw new ArgumentNullException(nameof(gameProgressDataStore));
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameProgressDto>> GetAllGameProgresses()
        {
            return Ok(_gameProgressDataStore.GameProgresses);
        }

        [HttpGet("{id}")]
        public ActionResult<GameProgressDto> GetASpecificGameProgress(int id)
        {
            try
            {
                // throw new Exception("Sample exception ...");
                var gameProgressToReturn = _gameProgressDataStore.GameProgresses.FirstOrDefault(
    g => g.Id == id
    );
                if (gameProgressToReturn == null)
                {
                    _logger.LogInformation($"The city with city id {id} cannot be found ... ");
                    return NotFound();
                }
                else return Ok(gameProgressToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception detected while getting the city with id {id}.\nException content: ", ex);
                return StatusCode(500, "Only this message will be returned to the consumer as the API implementation details should not be exposed. ");
            }
        }

        [HttpGet("{id}/gameprogressesonplatform")]
        public ActionResult<IEnumerable<GameProgressOnPlatformDto>> GetAllGameProgressesOfASpecificGame(int id)
        {
            var gameProgressToReturn = _gameProgressDataStore.GameProgresses.FirstOrDefault(
                g => g.Id == id
                );
            if (gameProgressToReturn == null) { return NotFound(); }
            else return Ok(gameProgressToReturn.GameProgressOnPlatforms);
        }

        [HttpGet("{id}/gameprogressesonplatform/{platformName}")]
        public ActionResult<GameProgressOnPlatformDto> GetASpecificGameProgressOfASpecificGame(int id, string platformName)
        {
            var gameProgressToReturn = _gameProgressDataStore.GameProgresses.FirstOrDefault(g => g.Id == id);
            if (gameProgressToReturn == null) { return NotFound(); }
            else
            {
                var gameProgressOnPlatformToReturn = gameProgressToReturn.GameProgressOnPlatforms.FirstOrDefault(g => g.Platform == platformName);
                if (gameProgressOnPlatformToReturn == null) { return NotFound(); }
                else
                    return gameProgressOnPlatformToReturn;
            }
        }
    }
}
