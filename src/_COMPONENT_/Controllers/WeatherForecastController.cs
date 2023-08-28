using Application.Common.Models;
using Application.Process.Weather.Queries.GetWeatherForecasts.v1;
using Microsoft.AspNetCore.Mvc;

namespace _COMPONENT_.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ApiControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("v1/GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await Mediator.Send(new GetWeatherForecastsQuery());
            return Ok(BaseResponse.Ok(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(Get));
            return BadRequest();
        }

    }
}