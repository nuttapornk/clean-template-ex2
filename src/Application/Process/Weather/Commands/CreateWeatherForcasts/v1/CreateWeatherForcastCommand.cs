using MediatR;

namespace Application.Process.Weather.Commands.CreateWeatherForcasts.v1;

public record CreateWeatherForcastCommand : IRequest<int>
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summaries { get; set; } = string.Empty;
}
