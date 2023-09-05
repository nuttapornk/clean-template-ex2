using Application.Common.Models;
using Application.Process.Weather.Commands.CreateWeatherForcasts.v1;
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

    [HttpPost("v1/Create")]
    public async Task<IActionResult> Create(CreateWeatherForcastCommand request)
    {
        try
        {
            var result = await Mediator.Send(request);
            return StatusCode(201, BaseResponse.Ok(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(Create));
            return StatusCode(500, BaseResponse.Error500(
                errorCode: "202309060031", devErrorMessage: ex.Message));
        }
    }

    [HttpGet("v1/Get")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var query = new GetWeatherForecastQuery();
            var results = await Mediator.Send(query);
            return StatusCode(201, BaseResponse.Ok(results));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(Get));
            return StatusCode(500, BaseResponse.Error500(
                errorCode: "202309060119", devErrorMessage: ex.Message));
        }

    }
}