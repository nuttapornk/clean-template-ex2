using Application.Process.Weather.Queries.GetWeatherForecast.v1;

namespace Application.UnitTests.Process.Weather.Queries.GetWeatherForecasts.v1
{
    public class GetWaatherForecastTests
    {
        [Fact]
        public async Task Handler_ValidInput_ReturnWeatherForecast()
        {
            //Arrange
            var handler = new GetWeatherForecastHandler();
            var query = new GetWeatherForecastQuery { Days = 5 };

            //Ace
            var results = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(results);
            Assert.Equal(query.Days, results.Count());
        }
    }
}