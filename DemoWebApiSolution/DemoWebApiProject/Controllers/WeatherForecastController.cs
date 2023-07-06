using DemoWebApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEnumerable<WeatherForecastDto> dummyReturn = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToArray();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastInObjectFormat")]
        public IEnumerable<WeatherForecastDto> Get() => dummyReturn;

        [HttpGet("getWeatherForecastInJsonFormat", Name = "GetWeatherForecastInJsonFormat")]
        public ActionResult<IEnumerable<WeatherForecastDto>> GetWeatherForecast() => Ok(dummyReturn);

        [HttpGet("getWeatherForecastAndTestLogger")]
        public ActionResult<IEnumerable<WeatherForecastDto>> GetWeatherForecastAndTestLogger()
        {
            _logger.Log(LogLevel.Information, "This weather controller has nothing to do with my game progress demo ... ");
            return Ok(dummyReturn);
        }
    }
}