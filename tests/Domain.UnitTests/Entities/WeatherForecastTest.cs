

using Domain.Entities;

namespace Domain.UnitTests.Entities;

    public class WeatherForecastTest
    {
        
        [Fact]
        public void TemperatureF_CalculatedCorrectly(){
            
            //Arrange
            var weatherForecast = new WeatherForecast{
                TemperatureC = 20
            };

            //Act
            
        }
    }
