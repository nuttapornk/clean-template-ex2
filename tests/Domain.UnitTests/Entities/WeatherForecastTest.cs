using Domain.Entities;
using Newtonsoft.Json;

namespace Domain.UnitTests.Entities;

public class WeatherForecastTest
{

    [Fact]
    public void WeatherForecast_WithSameValue_AreQqual()
    {
        //Arrange
        DateTime date = new(2023, 9, 12);
        int temperatureC = 25;
        string summary = "Sunny";

        WeatherForecast forecast1 = new()
        {
            Date = date,
            TemperatureC = temperatureC,
            Summaries = summary
        };

        WeatherForecast forecast2 = new()
        {
            Date = date,
            TemperatureC = temperatureC,
            Summaries = summary
        };

        //Act

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(forecast1), JsonConvert.SerializeObject(forecast2));
    }

    [Fact]
    public void WeatherForecast_WithDifferentValues_AreNotEqual()
    {
        WeatherForecast forecast1 = new()
        {
            Date = new DateTime(2023, 9, 1),
            TemperatureC = 45,
            Summaries = "Hot"
        };

        WeatherForecast forecast2 = new()
        {
            Date = new DateTime(2023, 9, 1),
            TemperatureC = 10,
            Summaries = "Cool"
        };

        //Act

        //Assert
        Assert.NotEqual(JsonConvert.SerializeObject(forecast1), JsonConvert.SerializeObject(forecast2));
    }
}
