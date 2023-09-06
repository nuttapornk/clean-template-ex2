using MediatR;

namespace Application.Process.Weather.Commands.DeleteWeatherForecasts.v1;
public record DeleteWeatherForecastCommand(int Id) : IRequest;
