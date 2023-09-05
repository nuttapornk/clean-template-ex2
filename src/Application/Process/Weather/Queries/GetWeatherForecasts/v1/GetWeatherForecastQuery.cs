using MediatR;

namespace Application.Process.Weather.Queries.GetWeatherForecasts.v1;

public record GetWeatherForecastQuery : IRequest<IEnumerable<GetWeatherForecastResponse>>
{

}