using MediatR;

namespace Application.Process.Weather.Queries.GetWeatherForecastById.v1;

public record GetWeatherForecastByIdQuery : IRequest<GetWeatherForecastByIdResponse>
{
    public int Id { get; set; }
}
