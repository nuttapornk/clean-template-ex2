using MediatR;

namespace Application.Process.Weather.Commands.UpdateWeatherForecasts.v1;
public class UpdateWeatherForecastCommand : IRequest<int>
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summaries { get; set; } = string.Empty;
}