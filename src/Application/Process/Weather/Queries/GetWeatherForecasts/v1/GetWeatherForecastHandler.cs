using Application.Common.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Process.Weather.Queries.GetWeatherForecasts.v1;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<GetWeatherForecastResponse>>
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;
    private readonly IMapper _mapper;

    public GetWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository, IMapper mapper)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetWeatherForecastResponse>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var weatherForecasts = await _weatherForecastRepository.FindAllAsync();
        var result = _mapper.Map<IEnumerable<GetWeatherForecastResponse>>(weatherForecasts);
        // var results = weatherForecasts.Select(a => new GetWeatherForecastResponse
        // {
        //     Date = a.Date,
        //     TemperatureC = a.TemperatureC,
        //     Summaries = a.Summaries
        // }).ToList();
        return result;
    }
}