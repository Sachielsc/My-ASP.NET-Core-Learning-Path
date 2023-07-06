using DemoWebApiProject.MockData;
using DemoWebApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    [Route("api/gameprogresses")]
    public class GameProgressDemoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<GameProgressDto>> GetAllGameProgresses()
        {
            return Ok(GameProgressDataStore.Instance.GameProgresses);
        }

        [HttpGet("{id}")]
        public ActionResult<GameProgressDto> GetASpecificGameProgress(int id)
        {
            var gameProgressToReturn = GameProgressDataStore.Instance.GameProgresses.FirstOrDefault(
                c => c.Id == id
                );
            if (gameProgressToReturn == null) { return NotFound(); }
            else return Ok(gameProgressToReturn);
        }

        [HttpGet("{id}/gameprogressesonplatform")]
        public ActionResult<IEnumerable<GameProgressOnPlatformDto>> GetAllGameProgressesOfASpecificGame(int id)
        {
            var gameProgressToReturn = GameProgressDataStore.Instance.GameProgresses.FirstOrDefault(
                c => c.Id == id
                );
            if (gameProgressToReturn == null) { return NotFound(); }
            else return Ok(gameProgressToReturn.GameProgressOnPlatforms);
        }

        [HttpGet("{id}/gameprogressesonplatform/{platformName}")]
        public ActionResult<GameProgressOnPlatformDto> GetASpecificGameProgressOfASpecificGame(int id, string platformName)
        {
            var gameProgressToReturn = GameProgressDataStore.Instance.GameProgresses.FirstOrDefault(c => c.Id == id);
            if (gameProgressToReturn == null) { return NotFound(); }
            else
            {
                var gameProgressOnPlatformToReturn = gameProgressToReturn.GameProgressOnPlatforms.FirstOrDefault(c => c.Platform == platformName);
                if (gameProgressOnPlatformToReturn == null) { return NotFound(); }
                else
                    return gameProgressOnPlatformToReturn;
            }
        }
    }
}
