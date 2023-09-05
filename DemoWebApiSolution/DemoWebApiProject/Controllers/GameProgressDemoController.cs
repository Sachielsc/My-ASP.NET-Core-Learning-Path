using AutoMapper;
using DemoWebApiProject.Entities;
using DemoWebApiProject.Models;
using DemoWebApiProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // or we can hard code it like this: [Route("api/gameProgresses")]
    public class GameProgressDemoController : ControllerBase
    {
        private readonly ILogger<GameProgressDemoController> _logger;
        private readonly IGameProgressRepository _gameProgressRepository; // DI here, thus this has to be an interface, not a class
        private readonly IMapper _mapper;

        public GameProgressDemoController(ILogger<GameProgressDemoController> logger, IGameProgressRepository gameProgressRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameProgressRepository = gameProgressRepository ?? throw new ArgumentNullException(nameof(gameProgressRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get all game progresses with all their game progress on platform subclasses
        /// </summary>
        /// <returns>Return an enumerable of game progress Dtos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameProgressDto>>> GetAllGameProgresses()
        {
            var entityResult = await _gameProgressRepository.GetGameProgressesAsync();

            // There are 2 ways we can do the object mapping here:
            // 1. Use some manual object mapping methods here
            //var dtoResult = ControllerHelper.MannualMapperFromGameProgressEntityToDto(entityResult);

            // 2. Use automapper (The preferred way)
            var dtoResult = _mapper.Map<IEnumerable<GameProgressDto>>(entityResult);

            return Ok(dtoResult);
        }

        /// <summary>
        /// Get a game progress with all its game progress on platform subclasses by the game id. Capable of throwing an exception here to test the Internal Server Error
        /// </summary>
        /// <param name="gameId">The game ID is required</param>
        /// <param name="throwSampleExceptionInThisMethod">Throw an exception here to test the Internal Server Error. Default value is false</param>
        /// <returns>A game progress Dto</returns>
        [HttpGet("{gameId}")]
        public async Task<ActionResult<GameProgressDto>> GetASpecificGameProgress(int gameId, bool throwSampleExceptionInThisMethod = false)
        {
            try
            {
                if (throwSampleExceptionInThisMethod)
                {
                    throw new Exception("This is a sample exception to test status code 500 ...");
                }

                if (!await _gameProgressRepository.GameExistsAsync(gameId))
                {
                    _logger.LogInformation($"The game with game gameId {gameId} does NOT exist ... ");
                    return NotFound($"Status code 404! The game with game gameId {gameId} does NOT exist ... ");
                }

                var entityResult = await _gameProgressRepository.GetGameProgressAsync(gameId);
                var dtoResult = _mapper.Map<GameProgressDto>(entityResult);
                return Ok(dtoResult);
            }

            catch (Exception ex)
            {
                _logger.LogCritical($"Exception detected while getting the game with gameId {gameId}.\nException content: ", ex);
                return StatusCode(500, "Only this message will be returned to the consumer as the API implementation details should not be exposed. ");
            }
        }

        /// <summary>
        /// Get a list of game progress on platform subclasses for a certain game, by game ID. The only difference between this API and "GetASpecificGameProgress" is that this one will return an enumerable of game progress on platform Dtos instead
        /// </summary>
        /// <param name="gameId">The game ID is required</param>
        /// <returns>return an enumerable of game progress on platform Dtos</returns>
        [HttpGet("{gameId}/gameprogressesonplatform")]
        public async Task<ActionResult<IEnumerable<GameProgressOnPlatformDto>>> GetAllGameProgressesOfASpecificGame(int gameId)
        {
            if (!await _gameProgressRepository.GameExistsAsync(gameId))
            {
                _logger.LogInformation($"The game with game ID {gameId} does NOT exist ... ");
                return NotFound($"Status code 404! The game with game ID {gameId} does NOT exist ... ");
            }

            var entityResult = await _gameProgressRepository.GetGameProgressesOnPlatformsAsync(gameId);
            var dtoResult = _mapper.Map<IEnumerable<GameProgressOnPlatformDto>>(entityResult);
            return Ok(dtoResult);
        }

        /// <summary>
        /// Get one specific game progress on platform subclass for a certain game, by game ID and gameProgressOnPlatformId. This API will return 404 if the gameProgressOnPlatformId doesn't match with the game ID
        /// </summary>
        /// <param name="gameId">The game ID is required</param>
        /// <param name="gameProgressOnPlatformId">The gameProgressOnPlatformId is required</param>
        /// <returns>return a game progress on platform Dto</returns>
        [HttpGet("{gameId}/gameprogressesonplatform/{gameProgressOnPlatformId}", Name = "GetASpecificGameProgressOfASpecificGame")]
        public async Task<ActionResult<GameProgressOnPlatformDto>> GetASpecificGameProgressOfASpecificGame(int gameId, int gameProgressOnPlatformId)
        {
            if (!await _gameProgressRepository.GameExistsAsync(gameId))
            {
                _logger.LogInformation($"The game with game ID {gameId} does NOT exist ... ");
                return NotFound($"Status code 404! The game with game ID {gameId} does NOT exist ... ");
            }

            if (!await _gameProgressRepository.GameProgressOnPlatformExistsAsync(gameId, gameProgressOnPlatformId))
            {
                return NotFound($"Status code 404! The game with game ID {gameId} does exist. However, its game progress does NOT exist on the specific platform you requested ... ");
            }

            var entityResult = await _gameProgressRepository.GetGameProgressOnPlatformAsync(gameId, gameProgressOnPlatformId);
            var dtoResult = _mapper.Map<GameProgressOnPlatformDto>(entityResult);
            return Ok(dtoResult);
        }

        // Not used. This should be implemented as a filter/search feature.
        // Btw, in the controller folder, 2 controller methods with the same name will cause an error
        /*
        [HttpGet("{gameId}/gameprogressesonplatform/{platformName}")]
        public async Task<ActionResult<GameProgressOnPlatformDto>> GetASpecificGameProgressOfASpecificGame(int gameId, string platformName)
        {
            if (!await _gameProgressRepository.GameExistsAsync(gameId))
            {
                _logger.LogInformation($"The game with game ID {gameId} does NOT exist ... ");
                return NotFound($"Status code 404! The game with game ID {gameId} does NOT exist ... ");
            }

            if (!await _gameProgressRepository.GameProgressOnPlatformExistsAsync(gameId, platformName))
            {
                return NotFound($"Status code 404! The game with game ID {gameId} does exist. However, its game progress does NOT exist on the platform {platformName} ... ");
            }

            var entityResult = await _gameProgressRepository.GetGameProgressOnPlatformAsync(gameId, platformName);
            var dtoResult = _mapper.Map<GameProgressOnPlatformDto>(entityResult);
            return Ok(dtoResult);
        }
        */

        // Not used. As I don't want to use gameId as another parameter
        //[HttpPost]
        //public async Task<ActionResult<GameProgressOnPlatformDto>> CreateAGameProgressForASpecificGame(int gameId, GameProgressOnPlatformDto gameProgressOnPlatformDto)
        //{
        //    if (!await _gameProgressRepository.GameExistsAsync(gameId))
        //    {
        //        _logger.LogInformation($"The game with game ID {gameId} does NOT exist ... ");
        //        return NotFound($"Status code 404! The game with game ID {gameId} does NOT exist ... ");
        //    }

        //    var createdGameProgressOnPlatformEntity = _mapper.Map<GameProgressOnPlatform>(gameProgressOnPlatformDto);
        //    await _gameProgressRepository.AddProgressOnPlatformAsync(gameId, createdGameProgressOnPlatformEntity);
        //    var createdGameProgressOnPlatformDto = _mapper.Map<GameProgressOnPlatformDto>(createdGameProgressOnPlatformEntity);
        //    return CreatedAtRoute("GetASpecificGameProgressOfASpecificGame",
        //        new
        //        {
        //            gameId = createdGameProgressOnPlatformDto.GameId,
        //            gameProgressOnPlatformId = createdGameProgressOnPlatformDto.GameProgressOnPlatformId
        //        },
        //        createdGameProgressOnPlatformDto);
        //}

        /// <summary>
        /// Post a new gameProgressOnPlatformDto to the database. This API will read the Dto content and decide which Game Progress entity this gameProgressOnPlatformDto belongs to. And update the database.
        /// </summary>
        /// <param name="gameProgressOnPlatformDto">The gameProgressOnPlatformDto to be created</param>
        /// <returns>returns the gameProgressOnPlatformDto to be created</returns>
        [HttpPost("gameprogressesonplatform")]
        public async Task<ActionResult<GameProgressOnPlatformDto>> CreateAGameProgressForASpecificGame(GameProgressOnPlatformDto gameProgressOnPlatformDto)
        {
            int createdGameId = gameProgressOnPlatformDto.GameId;
            if (!await _gameProgressRepository.GameExistsAsync(createdGameId))
            {
                _logger.LogInformation($"The game with game ID {createdGameId} does NOT exist ... ");
                return NotFound($"Status code 404! The game with game ID {createdGameId} does NOT exist ... ");
            }

            var createdGameProgressOnPlatformEntity = _mapper.Map<GameProgressOnPlatform>(gameProgressOnPlatformDto);
            await _gameProgressRepository.AddProgressOnPlatformAsync(createdGameProgressOnPlatformEntity);
            var createdGameProgressOnPlatformDto = _mapper.Map<GameProgressOnPlatformDto>(createdGameProgressOnPlatformEntity);
            return CreatedAtRoute("GetASpecificGameProgressOfASpecificGame",
                new
                {
                    gameId = createdGameId,
                    gameProgressOnPlatformId = createdGameProgressOnPlatformDto.GameProgressOnPlatformId
                },
                createdGameProgressOnPlatformDto);
        }

        /// <summary>
        /// Delete a certain gameProgressOnPlatform record from the database. This API will return 404 if the gameProgressOnPlatformId doesn't match with the game ID
        /// </summary>
        /// <param name="gameId">The game ID is required</param>
        /// <param name="gameProgressOnPlatformId">The gameProgressOnPlatformId is required</param>
        /// <returns>Will return a 204 status code if the deletion is successful</returns>
        [HttpDelete("{gameId}/gameprogressesonplatform/{gameProgressOnPlatformId}")]
        public async Task<ActionResult> DeleteAGameProgressForASpecificGame(int gameId, int gameProgressOnPlatformId)
        {
            if (!await _gameProgressRepository.GameExistsAsync(gameId))
            {
                _logger.LogInformation($"The game with game ID {gameId} does NOT exist ... ");
                return NotFound($"Status code 404! The game with game ID {gameId} does NOT exist ... ");
            }

            if (!await _gameProgressRepository.GameProgressOnPlatformExistsAsync(gameId, gameProgressOnPlatformId))
            {
                return NotFound($"Status code 404! The game with game ID {gameId} does exist. However, its game progress does NOT exist on the specific platform you requested ... ");
            }

            await _gameProgressRepository.DeleteProgressOnPlatformAsync(gameProgressOnPlatformId);
            return NoContent();
        }

        /// <summary>
        /// Delete multiple gameProgressOnPlatform recorsd from the database
        /// </summary>
        /// <returns>Will return a 204 status code if no Internal Servicer Error is found</returns>
        [HttpDelete("gameprogressesonplatform")]
        public async Task<ActionResult> DeleteMultipleGameProgresses(int startGameId, int endGameId)
        {
            for (int i = startGameId; i <= endGameId; i++)
            {
                if (await _gameProgressRepository.GameProgressOnPlatformExistsAsync(i))
                {
                    await _gameProgressRepository.DeleteProgressOnPlatformAsync(i);
                }
                else
                {
                    _logger.LogInformation($"The game progress with game progress on platform ID {i} does NOT exist ... ");
                }
            }
            return NoContent();
        }
    }
}
