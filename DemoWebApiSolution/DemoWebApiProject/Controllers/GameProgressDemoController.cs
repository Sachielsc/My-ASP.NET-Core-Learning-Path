using DemoWebApiProject.Entities;
using DemoWebApiProject.MockData;
using DemoWebApiProject.Models;
using DemoWebApiProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DemoWebApiProject.Utilities;
using AutoMapper;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    [Route("api/gameprogresses")]
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameProgressDto>>> GetAllGameProgresses()
        {
            var entityResult = await _gameProgressRepository.GetGameProgressesAsync();

            // There are 2 ways we can do the object mapping here:
            // 1. Use some manual object mapping methods here
            //var dtoResult = ControllerHelper.MannualMapperFromGameProgressEntityToDto(entityResult);

            // 2. Use automapper
            var dtoResult = _mapper.Map<IEnumerable<GameProgressDto>>(entityResult);

            return Ok(dtoResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameProgressDto>> GetASpecificGameProgress(int id, bool throwSampleExceptionInThisMethod = false)
        {
            try
            {
                if (throwSampleExceptionInThisMethod)
                {
                    throw new Exception("This is a sample exception to test status code 500 ...");
                }

                if (!await _gameProgressRepository.GameExistsAsync(id))
                {
                    _logger.LogInformation($"The game with game progress id {id} does NOT exist ... ");
                    return NotFound($"Status code 404! The game with game progress id {id} does NOT exist ... ");
                }

                var entityResult = await _gameProgressRepository.GetGameProgressAsync(id);
                var dtoResult = _mapper.Map<GameProgressDto>(entityResult);
                return Ok(dtoResult);
            }

            catch (Exception ex)
            {
                _logger.LogCritical($"Exception detected while getting the game with id {id}.\nException content: ", ex);
                return StatusCode(500, "Only this message will be returned to the consumer as the API implementation details should not be exposed. ");
            }
        }

        [HttpGet("{id}/gameprogressesonplatform")]
        public async Task <ActionResult<IEnumerable<GameProgressOnPlatformDto>>> GetAllGameProgressesOfASpecificGame(int id)
        {
            if (!await _gameProgressRepository.GameExistsAsync(id))
            {
                _logger.LogInformation($"The game with game progress id {id} does NOT exist ... ");
                return NotFound($"Status code 404! The game with game progress id {id} does NOT exist ... ");
            }

            var entityResult = await _gameProgressRepository.GetGameProgressesOnPlatformsAsync(id);
            var dtoResult = _mapper.Map<IEnumerable<GameProgressOnPlatformDto>>(entityResult);
            return Ok(dtoResult);
        }

        [HttpGet("{id}/gameprogressesonplatform/{platformName}")]
        public async Task<ActionResult<GameProgressOnPlatformDto>> GetASpecificGameProgressOfASpecificGame(int id, string platformName)
        {
            if (!await _gameProgressRepository.GameExistsAsync(id))
            {
                _logger.LogInformation($"The game with game progress id {id} does NOT exist ... ");
                return NotFound($"Status code 404! The game with game progress id {id} does NOT exist ... ");
            }

            //var gameProgressOnPlatformEntity = await _gameProgressRepository.GetGameProgressesOnPlatformsAsync(id);

            //bool targetExists = gameProgressOnPlatformEntity.Any(entity => entity.Platform == platformName);

            if (!await _gameProgressRepository.GameProgressOnPlatformExistsAsync(id, platformName))
            {
                return NotFound($"Status code 404! The game with game progress id {id} does exist. However, its game progress does NOT exist on the platform {platformName} ... ");
            }

            var entityResult = await _gameProgressRepository.GetGameProgressOnPlatformAsync(id, platformName);
            var dtoResult = _mapper.Map<GameProgressOnPlatformDto>(entityResult);
            return Ok(dtoResult);
        }
    }
}
