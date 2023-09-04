using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Process.Weather.Commands.CreateWeatherForcasts.v1;
public class CreateWeatherForecastHandler : IRequestHandler<CreateWeatherForcastCommand, int>
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public CreateWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<int> Handle(CreateWeatherForcastCommand request, CancellationToken cancellationToken)
    {
        WeatherForecast entity = new()
        {
            Date = request.Date,
            TemperatureC = request.TemperatureC,
            Summaries = request.Summaries
        };

        entity.AddDomainEvent(new WeatherForecastCreatedEvent(entity));

        await _weatherForecastRepository.CreateAsync(entity, cancellationToken);
        return entity.Id;

    }
}
