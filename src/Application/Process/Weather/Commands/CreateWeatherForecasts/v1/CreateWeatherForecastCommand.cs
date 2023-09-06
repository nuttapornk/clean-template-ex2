using MediatR;

namespace Application.Process.Weather.Commands.CreateWeatherForecasts.v1;

public record CreateWeatherForecastCommand : IRequest<int>
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summaries { get; set; } = string.Empty;
}
