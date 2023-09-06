using Application.Common.Interfaces.Repositories;
using MediatR;

namespace Application.Process.Weather.Commands.UpdateWeatherForecasts.v1;

public class UpdateWeatherForecastHandler : IRequestHandler<UpdateWeatherForecastCommand, int>
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public UpdateWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }
    public async Task<int> Handle(UpdateWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        var entity = await _weatherForecastRepository.FindByIdAsync(request.Id)
        ?? throw new Exception("Data not found.");

        entity.Date = request.Date;
        entity.TemperatureC = request.TemperatureC;
        entity.Summaries = request.Summaries;

        await _weatherForecastRepository.UpdateAsync(entity, cancellationToken);
        return entity.Id;
    }
}
