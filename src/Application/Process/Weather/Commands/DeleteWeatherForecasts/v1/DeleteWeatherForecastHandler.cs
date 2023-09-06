using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using MediatR;

namespace Application.Process.Weather.Commands.DeleteWeatherForecasts.v1;

public class DeleteWeatherForecastHandler : IRequestHandler<DeleteWeatherForecastCommand>
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public DeleteWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }
    public async Task<Unit> Handle(DeleteWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        // var entity = await _weatherForecastRepository.FindByIdAsync(request.Id)
        // ?? throw new NotFoundException();

        await _weatherForecastRepository.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
