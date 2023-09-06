using Application.Common.Models;
using Application.Process.Weather.Commands.CreateWeatherForecasts.v1;
using Application.Process.Weather.Commands.DeleteWeatherForecasts.v1;
using Application.Process.Weather.Commands.UpdateWeatherForecasts.v1;
using Application.Process.Weather.Queries.GetWeatherForecastById.v1;
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
    public async Task<IActionResult> Create(CreateWeatherForecastCommand request)
    {
        try
        {
            var result = await Mediator.Send(request);
            return StatusCode(200, BaseResponse.Ok(result));
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
            return StatusCode(200, BaseResponse.Ok(results));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(Get));
            return StatusCode(500, BaseResponse.Error500(
                errorCode: "202309060119", devErrorMessage: ex.Message));
        }
    }
    [HttpGet("v1/GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var query = new GetWeatherForecastByIdQuery { Id = id };
            var result = await Mediator.Send(query);
            return StatusCode(200, BaseResponse.Ok(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(Get));
            return StatusCode(500, BaseResponse.Error500(
                errorCode: "202309062329", devErrorMessage: ex.Message));
        }
    }

    [HttpPost("v1/Update")]
    public async Task<IActionResult> Update(UpdateWeatherForecastCommand request)
    {
        try
        {
            var result = await Mediator.Send(request);
            return StatusCode(200, BaseResponse.Ok(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(Get));
            return StatusCode(500, BaseResponse.Error500(
                errorCode: "202309070018", devErrorMessage: ex.Message));
        }
    }

    [HttpPost("v1/Delete")]
    public async Task<IActionResult> Delete(DeleteWeatherForecastCommand request)
    {
        try
        {
            var result = await Mediator.Send(request);
            return StatusCode(200, BaseResponse.Ok(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(Get));
            return StatusCode(500, BaseResponse.Error500(
                errorCode: "202309070110", devErrorMessage: ex.Message));
        }
    }
}