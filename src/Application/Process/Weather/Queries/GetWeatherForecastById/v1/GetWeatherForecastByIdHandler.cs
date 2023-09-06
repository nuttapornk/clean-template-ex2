using Application.Common.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Process.Weather.Queries.GetWeatherForecastById.v1;

public class GetWeatherForecastByIdHandler : IRequestHandler<GetWeatherForecastByIdQuery, GetWeatherForecastByIdResponse>
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;
    private readonly IMapper _mapper;

    public GetWeatherForecastByIdHandler(IWeatherForecastRepository weatherForecastRepository, IMapper mapper)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _mapper = mapper;
    }
    public async Task<GetWeatherForecastByIdResponse> Handle(GetWeatherForecastByIdQuery request, CancellationToken cancellationToken)
    {
        var weatherForecast = await _weatherForecastRepository.FindByIdAsync(request.Id);
        return _mapper.Map<GetWeatherForecastByIdResponse>(weatherForecast);
    }
}
