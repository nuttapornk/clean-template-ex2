using MediatR;

namespace Application.Process.Weather.Queries.GetWeatherForecasts.v1;

public class GetWeatherForecastsQuery : IRequest<IEnumerable<GetWeatherForecastsResponse>>
{
    public class GetWeatherForecastsHandler : RequestHandler<GetWeatherForecastsQuery, IEnumerable<GetWeatherForecastsResponse>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        protected override IEnumerable<GetWeatherForecastsResponse> Handle(GetWeatherForecastsQuery request)
        {

            var rang = new Random();
            return Enumerable.Range(1, 5).Select(a => new GetWeatherForecastsResponse
            {
                Date = DateTime.Now.AddDays(a),
                TemperatureC = rang.Next(-10, 50),
                Sumrry = Summaries[rang.Next(Summaries.Length)]
            });

        }
    }
}
