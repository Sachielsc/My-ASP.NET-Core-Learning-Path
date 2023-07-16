using DemoWebApiProject.Models;
using DemoWebApiProject.Utilities;
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
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.Log(LogLevel.Information, "Start testing one of the weather controllers ... \nThis weather controller has nothing to do with my game progress demo ... ");
        }

        [HttpGet(Name = "GetWeatherForecastInObjectFormat")]
        public IEnumerable<WeatherForecastDto> Get() => dummyReturn;

        [HttpGet("getWeatherForecastInJsonFormat", Name = "GetWeatherForecastInJsonFormat")]
        public ActionResult<IEnumerable<WeatherForecastDto>> GetWeatherForecast()
        {
            var methodInfo = typeof(WeatherForecastController).GetMethod("GetWeatherForecast");
            string methodName = (methodInfo == null) ? "N/A" : methodInfo.Name;
            _logger.Log(LogLevel.Information, "Playing around the method info here. Method name: \"" + methodName + "\"\nLog more method information: " + methodInfo?.ToString());
            _logger.Log(LogLevel.Information, "Playing around the helper class: print an integer " + ControllerHelper.ControllerHelperDemoMethod(1, 2));
            return Ok(dummyReturn);
        }
    }
}