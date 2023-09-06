using AutoMapper;

namespace Application.Common.Mappings;
public class WeatherForecastAutoMapper : Profile
{
    public WeatherForecastAutoMapper()
    {
        CreateMap<Domain.Entities.WeatherForecast, Process.Weather.Queries.GetWeatherForecasts.v1.GetWeatherForecastResponse>();
        CreateMap<Domain.Entities.WeatherForecast, Process.Weather.Queries.GetWeatherForecastById.v1.GetWeatherForecastByIdResponse>();
    }
}
