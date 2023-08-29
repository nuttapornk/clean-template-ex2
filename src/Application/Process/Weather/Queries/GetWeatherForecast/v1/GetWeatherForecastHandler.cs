using MediatR;

namespace Application.Process.Weather.Queries.GetWeatherForecast.v1;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<GetWeatherForecastResponse>>
{

    private static readonly string[] Summaries = new[]
    {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

    public Task<IEnumerable<GetWeatherForecastResponse>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var rang = new Random();
        var results = Enumerable.Range(1, request.Days).Select(a => new GetWeatherForecastResponse
        {
            Date = DateTime.Now.AddDays(a),
            TemperatureC = rang.Next(-10, 50),
            Sumrry = Summaries[rang.Next(Summaries.Length)]
        });

        return Task.FromResult(results);
    }
}