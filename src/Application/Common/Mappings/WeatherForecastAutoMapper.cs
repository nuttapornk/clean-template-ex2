using Application.Process.Weather.Queries.GetWeatherForecastById.v1;
using Application.Process.Weather.Queries.GetWeatherForecasts.v1;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;
public class WeatherForecastAutoMapper : Profile
{
    public WeatherForecastAutoMapper()
    {
        CreateMap<WeatherForecast, GetWeatherForecastResponse>();
        CreateMap<WeatherForecast, GetWeatherForecastByIdResponse>();
    }
}
