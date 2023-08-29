using MediatR;

namespace Application.Process.Weather.Queries.GetWeatherForecast.v1;

public record GetWeatherForecastQuery : IRequest<IEnumerable<GetWeatherForecastResponse>>
{
    public int Days { get; set; }
}


