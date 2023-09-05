using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Process.Weather.Queries.GetWeatherForecasts.v1;
public record GetWeatherForecastResponse
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summaries { get; set; }


}